using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonCoRNGLibrary;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;
using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;
using static COSearch.Util;

namespace COSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += $" v{version.Major}.{version.Minor}.{version.Build}";

            var dgvPropertyInfo = typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(dataGridView1, true, null);
            dgvPropertyInfo.SetValue(dataGridView2, true, null);
            dgvPropertyInfo.SetValue(dataGridView3, true, null);
            dgvPropertyInfo.SetValue(DGV_seed, true, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dpName = CoDarkPokemon.GetAllCoDarkPokemons().Select(_ => _.slot.Pokemon.Name).ToArray();
            DarkPokemonBox.Items.AddRange(dpName);
            DarkPokemonBox_seed.Items.AddRange(dpName);

            natureBox1.Initialize();
            natureBox2.Initialize();
            
            hiddePowerTypeBox1.Initialize();

            var slot = CoDarkPokemon.GetDarkPokemon("マクノシタ");
            DarkPokemonBox.SelectedIndex = 0;
            DarkPokemonBox_seed.SelectedIndex = 0;
            modeBox.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox1.Seed;

            var targetStep = (uint)TargetStepBox.Value;

            if (targetStep > 500000)
            {
                MessageBox.Show($"目標seedが遠すぎます.\r\n{targetStep}消費をとにかくバトルだけで消費するのはやめましょう.");
                return;
            }

            var range = (uint)RangeBox.Value;

            int count = 0;
            var seed = currentSeed;
            if (dataGridView1.Columns[2].Visible = RoughlyButton.Checked)
            {
                (count, seed) = BattleNowAdvance.AdvanceRoughly(seed, targetStep, (uint)RoughlyRangeBox.Value);
            }

            var res = BattleNowAdvance.Advance(seed, targetStep - seed.GetIndex(currentSeed), range).OrderByDescending(_ => _.Seed.GetIndex(currentSeed)).ToArray();
            displayingResult = res;

            var items = new List<AdvanceCalcDGVItem1>();
            for (int i = 0; i < res.Length; i++)
            {
                var idx = res[i].Seed.GetIndex(currentSeed);
                items.Add(new AdvanceCalcDGVItem1(res[i].Seed, idx, targetStep - idx, count, res[i].Count, string.Join("→", res[i].GetProcedure(true))));
            }
            dataGridView1.DataSource = items;

            tabControl2.SelectedIndex = 0;
        }


        private IReadOnlyList<BattleNowAdvanceResult> displayingResult;
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var rules = new Dictionary<string, RentalPartyRank>()
            {
                { BattleNow.SingleBattle.Ultimate.RuleName, BattleNow.SingleBattle.Ultimate },
                { BattleNow.SingleBattle.Hard.RuleName, BattleNow.SingleBattle.Hard },
                { BattleNow.SingleBattle.Normal.RuleName, BattleNow.SingleBattle.Normal },
                { BattleNow.SingleBattle.Easy.RuleName, BattleNow.SingleBattle.Easy },

                { BattleNow.DoubleBattle.Ultimate.RuleName, BattleNow.DoubleBattle.Ultimate },
                { BattleNow.DoubleBattle.Hard.RuleName, BattleNow.DoubleBattle.Hard },
                { BattleNow.DoubleBattle.Normal.RuleName, BattleNow.DoubleBattle.Normal },
                { BattleNow.DoubleBattle.Easy.RuleName, BattleNow.DoubleBattle.Easy },
            };

            var currentSeed = currentSeedBox1.Seed;
            var target = (uint)TargetStepBox.Value;
            var pro = displayingResult[e.RowIndex].GetProcedure();

            var seed = currentSeed;
            dataGridView2.Rows.Clear();

            for (int i = 0; i < (int)dataGridView1[2, e.RowIndex].Value; i++)
            {
                var res = BattleNow.SingleBattle.Ultimate.Generate(seed);
                seed = res.TailSeed;
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                var idx = seed.GetIndex(currentSeed);
                row.SetValues($"{seed:X8}", idx, target - idx, BattleNow.SingleBattle.Ultimate.RuleName, $"{res.PlayerName} {res.PlayerTeam[0].Name}");
                dataGridView2.Rows.Add(row);
            }
            for (int i = 0; i < pro.Length; i++)
            {
                var rule = rules[pro[i]];

                var res = rule.Generate(seed);
                seed = res.TailSeed;
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                var idx = seed.GetIndex(currentSeed);
                row.SetValues($"{seed:X8}", idx, target - idx, rule.RuleName, $"{res.PlayerName} {res.PlayerTeam[0].Name}");
                dataGridView2.Rows.Add(row);
            }
            tabControl2.SelectedIndex = 1;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var val = (uint)e.Value;
                if (val % 24 == 0 || val % 7 == 0 || val % 24 % 7 == 0)
                {
                    e.CellStyle.BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void DataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var data = dataGridView3.Rows[e.RowIndex].DataBoundItem as IndividualListItem;

            if (data.IsShiny)
                e.CellStyle.BackColor = Color.Gold;
        }

        private void CalcListButton_Click(object sender, EventArgs e)
        {
            var currentSeed = seedBox2.Seed;
            var max = (int)maxFrameBox.Value;
            var slot = CoDarkPokemon.GetDarkPokemon(DarkPokemonBox.Text);
            var resList = new List<IndividualListItem>();

            IEnumerable<uint> enumerator;
            switch (modeBox.SelectedIndex)
            {
                case 0:
                default:
                    enumerator = currentSeed.EnumerateSeed().Take(max + 1); break;
                case 1:
                    enumerator = currentSeed.EnumerateSeedAtPyriteCave().Take(max + 1); break;
                case 2:
                    enumerator = currentSeed.EnumerateSeedAtCipherLabB1F().Take(max + 1); break;
                case 3:
                    enumerator = currentSeed.EnumerateSeedAtCipherLabB2F().Take(max + 1); break;
                case 4:
                    enumerator = currentSeed.EnumerateSeedAtOutskirtStand().Take(max + 1); break;
                    
            }

            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);

            var builder = new IndividualCriteriaBuilder();
            if (checkAbility.Checked) builder.AddGCAbilityCriteria(abilityBox1.Text);
            if (checkGender.Checked && genderBox1.SelectedGender != Gender.Genderless) builder.AddGenderCriteria(genderBox1.SelectedGender);
            if (checkNature.Checked) builder.AddNatureCriteria(natureBox1.SelectedNature);
            if (OnlyShiny_list.Checked) builder.AddShinyCriteria(tsv, ShinyType.Star | ShinyType.Square);
            var targetStats = new uint[]
            {
                checkH.Checked ? GetValueDec(StatH) : 0,
                checkA.Checked ? GetValueDec(StatA) : 0,
                checkB.Checked ? GetValueDec(StatB) : 0,
                checkC.Checked ? GetValueDec(StatC) : 0,
                checkD.Checked ? GetValueDec(StatD) : 0,
                checkS.Checked ? GetValueDec(StatS) : 0,
            };
            builder.AddStatsCriteria(targetStats);

            var criteria = builder.Build();

            foreach ((var index, var result) in enumerator.EnumerateGeneration(slot).WithIndex().Where(_ => criteria.Check(_.element.Content)))
            {
                var (indiv, seed) = result;
                resList.Add(modeBox.SelectedIndex == 0 ?
                    new IndividualListItem(index, seed, indiv, tsv) :
                    new IndividualListItem((int)seed.GetIndex(currentSeed), (uint)index, seed, indiv, tsv));
            }
            

            dataGridView3.DataSource = resList;

            dataGridView3.Columns[0].Visible = modeBox.SelectedIndex != 0;
        }

        private void CalcBlinkButton_Click(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox2.Seed;

            IEnumerable<((int frame, uint seed) blink, (int frame, uint seed))> results;
            if (radioButton1.Checked)
                results = IrregularAdvanceCalculator.CalcBlinkAndBubbleFrame(currentSeed, targetSeedBox2.Seed, (uint)minBlankBox.Value, (int)minBlinkFrameBox.Value, (int)maxBlinkFrameBox.Value, (int)minFrameBox.Value, (int)maxFrameBox_blink.Value, (int)blinkCoolTimeBox.Value);

            else if (radioButton2.Checked)
                results = IrregularAdvanceCalculator.CalcBlinkAndStandFrame(currentSeed, targetSeedBox2.Seed, (uint)minBlankBox.Value, (int)minBlinkFrameBox.Value, (int)maxBlinkFrameBox.Value, (int)minFrameBox.Value, (int)maxFrameBox_blink.Value, (int)blinkCoolTimeBox.Value);

            else if(radioButton3.Checked)
                results = IrregularAdvanceCalculator.CalcBlinkAndSmokeFrame(currentSeed, targetSeedBox2.Seed, (uint)minBlankBox.Value, (int)minBlinkFrameBox.Value, (int)maxBlinkFrameBox.Value, (int)minFrameBox.Value, (int)maxFrameBox_blink.Value, (int)blinkCoolTimeBox.Value);

            else
                results = IrregularAdvanceCalculator.CalcBlinkAndVibravaFrame(currentSeed, targetSeedBox2.Seed, (uint)minBlankBox.Value, (int)minBlinkFrameBox.Value, (int)maxBlinkFrameBox.Value, (int)minFrameBox.Value, (int)maxFrameBox_blink.Value, (int)blinkCoolTimeBox.Value);

            dataGridView4.Rows.Clear();
            foreach (var (blink, bubble) in results)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView4);
                row.SetValues($"{blink.frame}F", $"{blink.seed:X8}", $"{blink.seed.GetIndex(currentSeed)}", $"{bubble.frame}F");
                dataGridView4.Rows.Add(row);
            }
        }

        private void DarkPokemonBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var slot = CoDarkPokemon.GetDarkPokemon(DarkPokemonBox.SelectedIndex).slot;
            var poke = slot.Pokemon;
            abilityBox1.ResetItems(poke);
            genderBox1.ResetItems(poke.GenderRatio);

            switch (poke.Name)
            {
                case "アサナン":
                case "チルット":
                    modeBox.SelectedIndex = 1; break;
                case "ビブラーバ":
                    modeBox.SelectedIndex = 2; break;
                case "アリアドス":
                case "グランブル":
                case "ライコウ":
                    modeBox.SelectedIndex = 3; break;
                case "トゲチック":
                    modeBox.SelectedIndex = 4; break;
                default:
                    modeBox.SelectedIndex = 0; break;
            }

            var (minStats, maxStats) = poke.CalcStatsRange(slot.Lv);
            StatH.Minimum = minStats[0];
            StatA.Minimum = minStats[1];
            StatB.Minimum = minStats[2];
            StatC.Minimum = minStats[3];
            StatD.Minimum = minStats[4];
            StatS.Minimum = minStats[5];

            StatH.Maximum = maxStats[0];
            StatA.Maximum = maxStats[1];
            StatB.Maximum = maxStats[2];
            StatC.Maximum = maxStats[3];
            StatD.Maximum = maxStats[4];
            StatS.Maximum = maxStats[5];
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DGV_seed.Rows.Clear();

            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);

            var builder = new IndividualCriteriaBuilder();
            if (checkAbility_seed.Checked) builder.AddAbilityCriteria(abilityBox2.Text);
            if (checkGender_seed.Checked && genderBox2.SelectedGender != Gender.Genderless) builder.AddGenderCriteria(genderBox2.SelectedGender);
            if (checkNature_seed.Checked) builder.AddNatureCriteria(natureBox2.SelectedNature);
            if (OnlyShiny_seed.Checked) builder.AddShinyCriteria(tsv, ShinyType.Star | ShinyType.Square);
            if (checkHiddenPowerPower1.Checked) builder.AddHiddenPowerCriteria((uint)hiddenPowerPowerBox1.Value);
            if (checkHiddenPowerType1.Checked) builder.AddHiddenPowerTypeCriteria(hiddePowerTypeBox1.SelectedType);

            var criteria = builder.Build();

            var slot = CoDarkPokemon.GetDarkPokemon(DarkPokemonBox_seed.SelectedIndex);
            var rowList = new List<DataGridViewRow>();
            for (uint H = GetValueDec(Hmin_seed); H <= GetValueDec(Hmax_seed); H++)
                for (uint A = GetValueDec(Amin_seed); A <= GetValueDec(Amax_seed); A++)
                    for (uint B = GetValueDec(Bmin_seed); B <= GetValueDec(Bmax_seed); B++)
                        for (uint C = GetValueDec(Cmin_seed); C <= GetValueDec(Cmax_seed); C++)
                            for (uint D = GetValueDec(Dmin_seed); D <= GetValueDec(Dmax_seed); D++)
                                for (uint S = GetValueDec(Smin_seed); S <= GetValueDec(Smax_seed); S++)
                                {
                                    foreach ((var seed, var individual) in slot.CalcBack(H, A, B, C, D, S, checkDeduplication.Checked).Where(_ => criteria.Check(_.Individual)))
                                    {
                                        individual.SetShinyType(tsv);

                                        var row = new DataGridViewRow();
                                        row.CreateCells(DGV_seed);
                                        row.SetValues($"{seed:X8}", $"{individual.PID:X8}", individual.Nature.ToJapanese(),
                                            individual.IVs[0], individual.IVs[1], individual.IVs[2], individual.IVs[3], individual.IVs[4], individual.IVs[5],
                                            individual.Ability, individual.GCAbility, individual.Gender.ToSymbol(),
                                            individual.Stats[0], individual.Stats[1], individual.Stats[2], individual.Stats[3], individual.Stats[4], individual.Stats[5]);
                                        if (individual.Shiny.IsShiny()) row.DefaultCellStyle.BackColor = Color.Gold;
                                        rowList.Add(row);
                                    }
                                }
            foreach(var row in rowList)
                DGV_seed.Rows.Add(row);
        }

        private void DarkPokemonBox_seed_SelectedIndexChanged(object sender, EventArgs e)
        {
            gcAbilityBox1.ResetItems(CoDarkPokemon.GetDarkPokemon(DarkPokemonBox_seed.SelectedIndex).slot.Pokemon);
            abilityBox2.ResetItems(CoDarkPokemon.GetDarkPokemon(DarkPokemonBox_seed.SelectedIndex).slot.Pokemon);
            genderBox2.ResetItems(CoDarkPokemon.GetDarkPokemon(DarkPokemonBox_seed.SelectedIndex).slot.Pokemon.GenderRatio);
        }

        private void blinkCoolTimeBox_ValueChanged(object sender, EventArgs e)
        {
            minBlankBox.Maximum = 90 + blinkCoolTimeBox.Value;
        }
    }
}
