using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;
using PokemonCoRNGLibrary;

using static COSearch.Util;
using PokemonCoRNGLibrary.AdvanceSource;
using PokemonCoRNGLibrary.ProvidedData;

namespace COSearch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += $" v{version.Major}.{version.Minor}+{version.Build}";
        }

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

        private void Form1_Load(object sender, EventArgs e)
        {
            var dpName = ProvidedCoDarkPokemonData.GetAll().Select(_ => _.Slot.Species.Name).ToArray();
            darkPokemonBox.Items.AddRange(dpName.Take(dpName.Length).ToArray());
            findTargetFromSeedCriteriaArea.MaximizeIVs();

            darkPokemonBox.SelectedIndex = 0;
            advanceModeBox_ListUp.SelectedIndex = 0;
        }

        private void SelectedIndexChanged__DarkPokemonBox(object sender, EventArgs e)
        {
            forcedAdvancesBox.Value = ForcedAdvancesData.GetForcedAdvances(darkPokemonBox.Text);

            var poke = ProvidedCoDarkPokemonData.Get(darkPokemonBox.SelectedIndex).Slot.Species;
            forcedAdvancesBox.Value = ForcedAdvancesData.GetForcedAdvances(poke.Name);

            findTargetFromNearbyCriteriaArea.ResetItems(poke);
            findTargetFromSeedCriteriaArea.ResetItems(poke);

            checkAfterEnding.Visible = poke.Name == "ヘラクロス" || poke.Name == "ヤミカラス";
            
        }

        private ProvidedCoDarkPokemonData GetDarkPokemonData()
        {
            var poke = ProvidedCoDarkPokemonData.Get(darkPokemonBox.SelectedIndex);
            return (checkAfterEnding.Visible && checkAfterEnding.Checked)
                ? poke.OverridePreGeneratePokemons(Array.Empty<FixedSlot>())
                : poke;
        }

        // # FindTarget --------------------

        private void Click__CalcButton_FindTarget_FromNearBy(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox_FindTarget_FromNearby.Seed;

            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);
            var criteria = findTargetFromNearbyCriteriaArea.BuildCriteria(tsv);

            var min = (int)minAdvances_FindTarget_FromNearBy.Value;
            var max = (int)maxAdvances_FindTarget_FromNearBy.Value;
            var forcedAdvances = (uint)forcedAdvancesBox.Value;
            if (min > max) return;

            var poke = GetDarkPokemonData();
            var generator = poke.GetGenerator().WithOffset(forcedAdvances);
            var results = currentSeed.EnumerateSeed().Skip(min).Take(max - min + 1)
                .Select(generator.Generate).WithIndex()
                .Where(_ => criteria.CheckConditions(_.Element.Content))
                .Select((res) => new ListViewBinder((uint)res.Index, res.Element.HeadSeed, res.Element.Content, tsv))
                .ToArray();

            new ResultWindow<ListViewBinder>(
                results,
                title: $"{darkPokemonBox.Text} - {results.Length}件",
                onFormatCell: (_, _e) =>
                {
                    if (results[_e.RowIndex].IsShiny) _e.CellStyle.BackColor = Color.Gold;
                },
                onDoubleClickCell: (_, _e) =>
                {
                    if (_e.RowIndex < 0) return;

                    var targetSeed = Convert.ToUInt32(results[_e.RowIndex].Seed, 16);
                    new PathCalculationForm(poke, currentSeed, targetSeed, forcedAdvances).Show();
                },
                modifier: (_) => _.SetColumnVisible("Frame", false)
            ).Show();
        }

        private void Click__CalcButton_FindTarget_FromSeed(object sender, EventArgs e)
        {
            // カードe組はこちらの機能を使う意味がない
            if (darkPokemonBox.SelectedIndex >= darkPokemonBox.Items.Count - 3) return;

            var poke = GetDarkPokemonData();
            var slot = poke.GetGenerator();

            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);

            var criteria = findTargetFromSeedCriteriaArea.BuildCriteria(tsv, containsIVsCriteria: false);
            var forcedAdvances = (uint)forcedAdvancesBox.Value;

            var results = new List<TargetSearchBinder>();
            foreach (var (h, a, b, c, d, s) in findTargetFromSeedCriteriaArea.EnumerateIVs())
            {
                var r = slot.CalcBack(h, a, b, c, d, s, checkDeduplication.Checked).Where(_ => criteria.CheckConditions(_.Individual));
                // CalcBackは強制消費ぶんを考慮しないseedを返すので、強制消費ぶん戻したseedを目標seedとする
                results.AddRange(r.Select(_ => new TargetSearchBinder(_.Seed.PrevSeed(forcedAdvances), _.Individual, tsv)));
            }

            new ResultWindow<TargetSearchBinder>(results, title: $"{darkPokemonBox.Text} - {results.Count}件",
                onFormatCell: (_, _e) =>
                {
                    if (results[_e.RowIndex].IsShiny) _e.CellStyle.BackColor = Color.Gold;
                },
                onDoubleClickCell: (_, _e) =>
                {
                    if (_e.RowIndex < 0) return;

                    var targetSeed = Convert.ToUInt32(results[_e.RowIndex].Seed, 16);
                    new PathCalculationForm(poke, 0, targetSeed, forcedAdvances).Show();
                }).Show();
        }

        // # ListUp --------------------

        private IEnumerable<uint> GetEnumerator_ListUp(uint currentSeed)
        {
            switch (advanceModeBox_ListUp.SelectedIndex)
            {
                case 0:
                default:
                    return currentSeed.EnumerateSeed();
                case 1:
                    return currentSeed.EnumerateSeed(new PyriteTown().Apply((_, c) => c.SimulateNextFrame(_.NextSeed(4))));
                case 2:
                    return currentSeed.EnumerateSeed(new PyriteCave().Apply((_, c) => c.SimulateNextFrame(_.NextSeed(4))));
                case 3:
                    return currentSeed.EnumerateSeed(new CipherLabB2F());
                case 4:
                    return currentSeed.EnumerateSeed(new CipherLabB3F());
                case 5:
                    return currentSeed.EnumerateSeed(new OutskirtStand().Apply((_, c) => c.SimulateNextFrame(_.NextSeed(4))));
                case 6:
                    return currentSeed.EnumerateSeed(
                        new BlinkObjectEnumeratorHanlder(
                            new BlinkObject(10, 10),
                            new BlinkObject(10, 10),
                        new BlinkObject((int)numericUpDown2.Value, 10))
                    );
                case 7:
                    return currentSeed.EnumerateSeed(
                        new BlinkObjectEnumeratorHanlder(
                            new BlinkObject(10, 10),
                            new BlinkObject((int)numericUpDown2.Value, 10))
                    );
            }
        }

        private void Click__CalcButton_ListUp(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox_ListUp.Seed;
            var max = (int)maxFrameBox_ListUp.Value;
            var slot = GetDarkPokemonData().GetGenerator();

            var seedEnumerator = GetEnumerator_ListUp(currentSeed);

            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);

            var forcedAdvances = (uint)forcedAdvancesBox.Value;

            var temp = seedEnumerator.Take(max + 1)
                .Select(_ => slot.Generate(_.NextSeed(forcedAdvances))).WithIndex();

            var results = (advanceModeBox_ListUp.SelectedIndex == 0 ? 
                temp.Select((res) => new ListViewBinder((uint)res.Index, res.Element.HeadSeed, res.Element.Content, tsv)) :
                temp.Select((res) => new ListViewBinder((uint)res.Index, res.Element.HeadSeed.GetIndex(currentSeed), res.Element.HeadSeed, res.Element.Content, tsv))).ToArray();

            new ResultWindow<ListViewBinder>(
                results, 
                onFormatCell: (_, _e) =>
                {
                    if (results[_e.RowIndex].IsShiny) _e.CellStyle.BackColor = Color.Gold; 
                },
                modifier: (_) => _.SetColumnVisible("Frame", advanceModeBox_ListUp.SelectedIndex != 0)
            ).Show();
        }

        private void SelectedIndexChanged__AdvanceModeBox_ListUp(object sender, EventArgs e)
        {
            label87.Visible = label88.Visible = numericUpDown2.Visible 
                = advanceModeBox_ListUp.SelectedIndex == 5 || advanceModeBox_ListUp.SelectedIndex == 6;
        }

        private void OnClick__StarterRNGToolStripMenuItem(object sender, EventArgs e)
        {
            new StarterRNGForm().Show();
        }
    }

}
