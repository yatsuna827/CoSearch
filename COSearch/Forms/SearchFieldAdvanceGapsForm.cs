using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;
using PokemonStandardLibrary.CommonExtension;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.Criteria;
using PokemonCoRNGLibrary.ProvidedData;
using PokemonCoRNGLibrary.AdvanceSource;

using static COSearch.Util;

namespace COSearch
{
    public enum FieldAdvanceType
    {
        PyriteCave,
        CipherLabB2F,
        CipherLabB3F,
        OutskirtStand,
    }

    public partial class SearchFieldAdvanceGapsForm : Form
    {
        public SearchFieldAdvanceGapsForm(
            ProvidedCoDarkPokemonData pokemon, FieldAdvanceType fieldAdvanceType, uint currentSeed, uint targetSeed, uint targetBlinkFrames, uint targetFrames, uint forcedAdvances = 0)
        {
            InitializeComponent();

            _darkPokemon = pokemon;
            _fieldAdvanceSource = new ISeedEnumeratorHandler[] { new PyriteCave(), new CipherLabB2F(), new CipherLabB3F(), new OutskirtStand() }[(int)fieldAdvanceType];
            _currentSeed = currentSeed;
            _targetBlinkFrames = targetBlinkFrames;
            _targetFrames = targetFrames;

            var field = new[] { "パイラの洞窟", "ダークポケモン研究所B2F", "ダークポケモン研究所B3F", "町外れのスタンド" }[(int)fieldAdvanceType];
            this.Text = $"ズレ検索 - {pokemon.Slot.Species.Name} @ {field}";
            this.currentSeedBox.Text = $"{currentSeed:X8}";
            this.targetSeedBox.Text = $"{targetSeed:X8}";
            this.blinkFramesBox.Value = _targetBlinkFrames;
            this.framesBox.Value = _targetFrames;

            this.forcedAdvancesBox.Value = forcedAdvances;

            _wrapper = new DataGridViewWrapper<SearchFieldAdvanceGapsFormResultBinder>(dataGridView1);
        }

        private readonly DataGridViewWrapper<SearchFieldAdvanceGapsFormResultBinder> _wrapper;

        private readonly ProvidedCoDarkPokemonData _darkPokemon;
        private readonly ISeedEnumeratorHandler _fieldAdvanceSource;

        private uint _currentSeed;

        private uint _targetBlinkFrames;
        private uint _targetFrames;

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

        public void SetValues(uint currentSeed, uint targetSeed, uint targetBlinkFrames, uint targetFrames) 
        {
            _currentSeed = currentSeed;
            _targetBlinkFrames = targetBlinkFrames;
            _targetFrames = targetFrames;

            this.currentSeedBox.Text = $"{currentSeed:X8}";
            this.targetSeedBox.Text = $"{targetSeed:X8}";
            this.blinkFramesBox.Value = _targetBlinkFrames;
            this.framesBox.Value = _targetFrames;
        }

        private ICriteria<GCIndividual> BuildCriteria()
        {
            var builder = new List<ICriteria<GCIndividual>>();
            var targetStats = new uint[]
            {
                checkStatH.Checked ? GetValueDec(statBoxH) : 0,
                checkStatA.Checked ? GetValueDec(statBoxA) : 0,
                checkStatB.Checked ? GetValueDec(statBoxB) : 0,
                checkStatC.Checked ? GetValueDec(statBoxC) : 0,
                checkStatD.Checked ? GetValueDec(statBoxD) : 0,
                checkStatS.Checked ? GetValueDec(statBoxS) : 0,
            };
            builder.Add(new StatsCriteria(targetStats));

            return Criteria.AND(builder.ToArray());
        }

        private void Click__CalcButton(object sender, EventArgs e)
        {
            var currentSeed = _currentSeed;
            var forcedAdvances = (uint)forcedAdvancesBox.Value;
            var max = (int)fieldAdvanceErrorFramesBox.Value;
            var generator = _darkPokemon.GetGenerator().WithOffset(forcedAdvances);

            var criteria = BuildCriteria();

            var blinkFrames = _targetBlinkFrames;
            var minBlinkFrames = (int)(blinkFrames - blinkErrorFramesBox.Value);
            var blinkRange = 2 * (int)blinkErrorFramesBox.Value + 1;

            var targetFrames = _targetFrames;
            var minFrames = (int)(targetFrames - fieldAdvanceErrorFramesBox.Value);
            var range = 2 * (int)fieldAdvanceErrorFramesBox.Value + 1;

            var blinkHandler = new BlinkObjectEnumeratorHanlder(new BlinkObject((int)coolTimeBox.Value, 10));

            var results = new List<SearchFieldAdvanceGapsFormResultBinder>();
            foreach (var (f, stoppedSeed) in currentSeed.EnumerateSeed(blinkHandler).WithIndex().Skip(minBlinkFrames).Take(blinkRange))
            {
                var blinkGaps = (int)(f - blinkFrames);

                results.AddRange(
                    stoppedSeed.EnumerateSeed(_fieldAdvanceSource)
                    .Select(generator.Generate).WithIndex()
                    .Skip(minFrames)
                    .Take(range)
                    .Where(_ => criteria.CheckConditions(_.Element.Content))
                    .Select((res) => new SearchFieldAdvanceGapsFormResultBinder(blinkGaps, res.Index, (int)(res.Index - targetFrames), res.Element))
                );
            }

            _wrapper.SetColumnVisible("BlinkGaps", blinkRange != 1);
            _wrapper.SetData(results);
        }

        private void OnValidated__StatBoxH(object sender, EventArgs e)
        {
            if (statBoxH.Text == "")
            {
                statBoxH.Value = 0;
                statBoxH.Text = "0";
            }
            checkStatH.Checked = statBoxH.Value > 0;
        }

        private void OnValidated__StatBoxA(object sender, EventArgs e)
        {
            if (statBoxA.Text == "")
            {
                statBoxA.Value = 0;
                statBoxA.Text = "0";
            }
            checkStatA.Checked = statBoxA.Value > 0;
        }

        private void OnValidated__StatBoxB(object sender, EventArgs e)
        {
            if (statBoxB.Text == "")
            {
                statBoxB.Value = 0;
                statBoxB.Text = "0";
            }
            checkStatB.Checked = statBoxB.Value > 0;
        }

        private void OnValidated__StatBoxC(object sender, EventArgs e)
        {
            if (statBoxC.Text == "")
            {
                statBoxC.Value = 0;
                statBoxC.Text = "0";
            }
            checkStatC.Checked = statBoxC.Value > 0;
        }

        private void OnValidated__StatBoxD(object sender, EventArgs e)
        {
            if (statBoxD.Text == "")
            {
                statBoxD.Value = 0;
                statBoxD.Text = "0";
            }
            checkStatD.Checked = statBoxD.Value > 0;
        }

        private void OnValidated__StatBoxS(object sender, EventArgs e)
        {
            if (statBoxS.Text == "")
            {
                statBoxS.Value = 0;
                statBoxS.Text = "0";
            }
            checkStatS.Checked = statBoxS.Value > 0;
        }
    }

    class SearchFieldAdvanceGapsFormResultBinder
    {
        private readonly GCIndividual _result;

        [DataGridViewRowHeader(88, "瞬きズレ")]
        public int BlinkGaps { get; }

        [DataGridViewRowHeader(88, "不定消費")]
        public uint Frames { get; }

        [DataGridViewRowHeader(88, "ズレ")]
        public int Gaps { get; }

        [DataGridViewRowHeader(88, "seed")]
        public string Seed { get; }

        [DataGridViewRowHeader(88, "性格値")]
        public string PID { get => $"{_result.PID:X8}"; }

        [DataGridViewRowHeader(64, "性格")]
        public string Nature { get => _result.Nature.ToJapanese(); }

        [DataGridViewRowHeader(40, "H")]
        public uint IVs_H { get => _result.IVs[0]; }
        [DataGridViewRowHeader(40, "A")]
        public uint IVs_A { get => _result.IVs[1]; }
        [DataGridViewRowHeader(40, "B")]
        public uint IVs_B { get => _result.IVs[2]; }
        [DataGridViewRowHeader(40, "C")]
        public uint IVs_C { get => _result.IVs[3]; }
        [DataGridViewRowHeader(40, "D")]
        public uint IVs_D { get => _result.IVs[4]; }
        [DataGridViewRowHeader(40, "S")]
        public uint IVs_S { get => _result.IVs[5]; }

        [DataGridViewRowHeader(100, "特性", true)]
        public string Ability { get => _result.Ability; }

        [DataGridViewRowHeader(100, "XD特性", true)]
        public string XDAbility { get => _result.GCAbility; }

        [DataGridViewRowHeader(66, "性別", false, "ＭＳ ゴシック")]
        public string Gender { get => _result.Gender.ToSymbol(); }

        [DataGridViewRowHeader(40, "H")]
        public uint Stats_H { get => _result.Stats[0]; }
        [DataGridViewRowHeader(40, "A")]
        public uint Stats_A { get => _result.Stats[1]; }
        [DataGridViewRowHeader(40, "B")]
        public uint Stats_B { get => _result.Stats[2]; }
        [DataGridViewRowHeader(40, "C")]
        public uint Stats_C { get => _result.Stats[3]; }
        [DataGridViewRowHeader(40, "D")]
        public uint Stats_D { get => _result.Stats[4]; }
        [DataGridViewRowHeader(40, "S")]
        public uint Stats_S { get => _result.Stats[5]; }

        [DataGridViewRowHeader(60, "めざパ")]
        public string HiddenPower { get => $"{_result.HiddenPowerType.ToKanji()}{_result.HiddenPower}"; }

        public SearchFieldAdvanceGapsFormResultBinder(int blinkGaps, int frames, int gaps, RNGResult<GCIndividual> result)
        {
            BlinkGaps = blinkGaps;
            Frames = (uint)frames;
            Gaps = gaps;
            (Seed, _result) = ($"{result.HeadSeed:X8}", result.Content);
        }
    }

}
