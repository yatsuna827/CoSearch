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
using PokemonStandardLibrary.Gen3;
using PokemonStandardLibrary.CommonExtension;
using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;
using PokemonCoRNGLibrary.Criteria;
using PokemonCoRNGLibrary.Criteria.Starter;
using PokemonCoRNGLibrary.StarterCriteriaLanguage;

using static COSearch.Util;
using static PokemonPRNG.LCG32.Criteria;

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
            dgvPropertyInfo.SetValue(dataGridView4, true, null);
            dgvPropertyInfo.SetValue(dataGridView5, true, null);
            dgvPropertyInfo.SetValue(dataGridView6, true, null);
            _targetSearchDGV = new DataGridViewWrapper<TargetSearchBinder>(DGV_seed);
            _listDGV = new DataGridViewWrapper<ListViewBinder>(dataGridView3);
            dgvPropertyInfo.SetValue(DGV_id, true, null);
            dgvPropertyInfo.SetValue(DGV_ID_Gap, true, null);
        }

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

        private void Form1_Load(object sender, EventArgs e)
        {
            var dpName = CoDarkPokemon.GetAllCoDarkPokemons().Select(_ => _.slot.Pokemon.Name).ToArray();
            DarkPokemonBox.Items.AddRange(dpName);
            DarkPokemonBox_seed.Items.AddRange(dpName);

            natureBox1.Initialize();
            natureBox2.Initialize();
            id_NatureBox.Initialize();
            id_CheckNature.Checked = false;

            hiddePowerTypeBox1.Initialize();
            id_HiddePowerType.Initialize();
            id_CheckHPType.Checked = false;

            var slot = CoDarkPokemon.GetDarkPokemon("マクノシタ");
            DarkPokemonBox.SelectedIndex = 0;
            DarkPokemonBox_seed.SelectedIndex = 0;
            modeBox.SelectedIndex = 0;

            id_PokemonBox.SelectedIndex = 0;

            DisplayIDTarget();
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
            var data = dataGridView3.Rows[e.RowIndex].DataBoundItem as ListViewBinder;
            if (data.IsShiny)
                e.CellStyle.BackColor = Color.Gold;
        }

        private readonly DataGridViewWrapper<ListViewBinder> _listDGV;
        private void CalcListButton_Click(object sender, EventArgs e)
        {
            var currentSeed = seedBox2.Seed;
            var max = (int)maxFrameBox.Value;
            var slot = CoDarkPokemon.GetDarkPokemon(DarkPokemonBox.Text);

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

            var builder = new List<ICriteria<GCIndividual>>();
            if (checkAbility.Checked) 
                builder.Add(new AbilityCriteria(abilityBox1.Text));
            if (checkGender.Checked && genderBox1.SelectedGender != Gender.Genderless) 
                builder.Add(new GenderCriteria(genderBox1.SelectedGender));
            if (checkNature.Checked) 
                builder.Add(new NatureCriteria(natureBox1.SelectedNature));
            if (OnlyShiny_list.Checked) 
                builder.Add(new ShinyCriteria(tsv, ShinyType.Star | ShinyType.Square));
            var targetStats = new uint[]
            {
                checkH.Checked ? GetValueDec(StatH) : 0,
                checkA.Checked ? GetValueDec(StatA) : 0,
                checkB.Checked ? GetValueDec(StatB) : 0,
                checkC.Checked ? GetValueDec(StatC) : 0,
                checkD.Checked ? GetValueDec(StatD) : 0,
                checkS.Checked ? GetValueDec(StatS) : 0,
            };
            builder.Add(new StatsCriteria(targetStats));

            var criteria = AND(builder.ToArray());

            var temp = enumerator.EnumerateGeneration(slot).WithIndex().Where(_ => criteria.CheckConditions(_.element.Content));
            var results = modeBox.SelectedIndex == 0 ? 
                temp.Select((res) => new ListViewBinder((uint)res.index, res.element.HeadSeed, res.element.Content, tsv)) :
                temp.Select((res) => new ListViewBinder((uint)res.index, res.element.HeadSeed.GetIndex(currentSeed), res.element.HeadSeed, res.element.Content, tsv));

            _listDGV.SetColumnVisible("Frame", modeBox.SelectedIndex != 0);
            _listDGV.SetData(results);
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

        private readonly DataGridViewWrapper<TargetSearchBinder> _targetSearchDGV;
        private void Button7_Click(object sender, EventArgs e)
        {
            var tsv = GetValueDec(TIDBox) ^ GetValueDec(SIDBox);

            var builder = new List<ICriteria<GCIndividual>>();
            if (checkAbility_seed.Checked) builder.Add(new AbilityCriteria(abilityBox2.Text));
            if (checkGender_seed.Checked && genderBox2.SelectedGender != Gender.Genderless) builder.Add(new GenderCriteria(genderBox2.SelectedGender));
            if (checkNature_seed.Checked) builder.Add(new NatureCriteria(natureBox2.SelectedNature));
            if (OnlyShiny_seed.Checked) builder.Add(new ShinyCriteria(tsv, ShinyType.Star | ShinyType.Square));
            if (checkHiddenPowerPower1.Checked) builder.Add(new HiddenPowerPowerCriteria((uint)hiddenPowerPowerBox1.Value));
            if (checkHiddenPowerType1.Checked) builder.Add(new HiddenPowerTypeCriteria(hiddePowerTypeBox1.SelectedType));

            var criteria = AND(builder.ToArray());

            var slot = CoDarkPokemon.GetDarkPokemon(DarkPokemonBox_seed.SelectedIndex);
            var rowList = new List<TargetSearchBinder>();
            for (uint H = GetValueDec(Hmin_seed); H <= GetValueDec(Hmax_seed); H++)
                for (uint A = GetValueDec(Amin_seed); A <= GetValueDec(Amax_seed); A++)
                    for (uint B = GetValueDec(Bmin_seed); B <= GetValueDec(Bmax_seed); B++)
                        for (uint C = GetValueDec(Cmin_seed); C <= GetValueDec(Cmax_seed); C++)
                            for (uint D = GetValueDec(Dmin_seed); D <= GetValueDec(Dmax_seed); D++)
                                for (uint S = GetValueDec(Smin_seed); S <= GetValueDec(Smax_seed); S++)
                                {
                                    var r = slot.CalcBack(H, A, B, C, D, S, checkDeduplication.Checked).Where(_ => criteria.CheckConditions(_.Individual));
                                    rowList.AddRange(r.Select(_ => new TargetSearchBinder(_.seed, _.Individual, tsv)));
                                }
            _targetSearchDGV.SetData(rowList);
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

        private void button3_Click(object sender, EventArgs e)
        {
            var current = seedBox3.Seed;
            var target = seedBox4.Seed;

            var targetIndex = target.GetIndex(current);

            var snatchMax = (int)numericUpDown22.Value;

            var cool = (int)numericUpDown19.Value;

            // var results = IrregularAdvanceCalculator.CalcBlinkAndSnatchList(seed, target, 0, 100, 200000, snatchMax, cool);

            dataGridView5.Rows.Clear();
            foreach (var (seed, interval, frame, lcgIndex) in current.EnumerateBlinkingSeed(cool).TakeWhile(_=>_.seed.GetIndex(current) <= targetIndex))
            {
                var snatchStream = seed.EnumerateSnatchListAdvance().TakeWhile((_) => _.GetIndex(current) <= targetIndex).ToArray();
                var snatchCount = snatchStream.Length - 1;
                var terminal = snatchStream.Last();
                var snatchCell = terminal == target ? $"{snatchCount}回" : $"{snatchCount}回+{target.GetIndex(terminal)}[F]";

                var row = new DataGridViewRow();
                row.CreateCells(dataGridView5);
                // フレーム、間隔、消費数、残り消費数、seed、スナッチリスト回数
                row.SetValues($"{frame}F", $"{seed:X8}", $"{interval}", $"{lcgIndex}[F]", $"{target.GetIndex(seed)}[F]", snatchCell);
                if(terminal == target && snatchCount <= snatchMax)
                    row.Cells[5].Style.BackColor = Color.GreenYellow;
                dataGridView5.Rows.Add(row);
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (row < 0) return;

            var seed = seedBox3.Seed;
            var target = seedBox4.Seed;

            var cool = (int)numericUpDown19.Value;

            var timeline = seed.EnumerateBlinkingSeed(cool).Take(row+1).Select(_ => _.interval).ToArray();

            var breaking = (int)numericUpDown21.Value;
            var frq = (double)numericUpDown20.Value;

            new BlinkTimer(timeline, breaking).Show();
        }

        #region Tab_ID

        private DataGridViewRow CreateRow(CoStarterResult res, uint? pid = null)
        {
            var seed = res.HeadSeed;
            var umbreon = res.Umbreon;
            var espeon = res.Espeon;

            var row = new DataGridViewRow();
            row.CreateCells(DGV_id,
                $"{seed:X8}", $"{res.TID:d5}", $"{res.SID:d5}",
                "ブラッキー", $"{umbreon.PID:X8}", umbreon.Nature.ToJapanese(),
                umbreon.IVs[0], umbreon.IVs[1], umbreon.IVs[2], umbreon.IVs[3], umbreon.IVs[4], umbreon.IVs[5],
                $"{umbreon.HiddenPowerType.ToKanji()}{umbreon.HiddenPower}",
                "エーフィ", $"{espeon.PID:X8}", espeon.Nature.ToJapanese(),
                espeon.IVs[0], espeon.IVs[1], espeon.IVs[2], espeon.IVs[3], espeon.IVs[4], espeon.IVs[5],
                $"{espeon.HiddenPowerType.ToKanji()}{espeon.HiddenPower}"
            );

            if(pid != null)
            {
                var psv = (pid.Value >> 16) ^ (pid.Value & 0xFFFF);
                var tsv = res.TID ^ res.SID;
                if((psv ^ tsv) == 0)
                {
                    row.Cells[1].Style.ForeColor = Color.MediumPurple;
                    row.Cells[2].Style.ForeColor = Color.MediumPurple;
                }
            }

            return row;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var generator = new CoStarterGenerator();
            var rowList = new List<DataGridViewRow>();

            var builder = new List<ICriteria<GCIndividual>>();
            if (id_CheckNature.Checked) builder.Add(new NatureCriteria(id_NatureBox.SelectedNature));
            if (id_CheckHPPower.Checked) builder.Add(new HiddenPowerPowerCriteria((uint)id_HiddenPowerPower.Value));
            if (id_CheckHPType.Checked) builder.Add(new HiddenPowerTypeCriteria(id_HiddePowerType.SelectedType));

            if (id_PokemonBox.Text == "ブラッキー")
            {
                var criteria =  new UmbreonCriteria(AND(builder.ToArray()));

                for (uint H = GetValueDec(id_Hmin); H <= GetValueDec(id_Hmax); H++)
                for (uint A = GetValueDec(id_Amin); A <= GetValueDec(id_Amax); A++)
                for (uint B = GetValueDec(id_Bmin); B <= GetValueDec(id_Bmax); B++)
                for (uint C = GetValueDec(id_Cmin); C <= GetValueDec(id_Cmax); C++)
                for (uint D = GetValueDec(id_Dmin); D <= GetValueDec(id_Dmax); D++)
                for (uint S = GetValueDec(id_Smin); S <= GetValueDec(id_Smax); S++)
                {
                    foreach (var res in CoStarterGenerator.CalcBackUmbreon(H, A, B, C, D, S).Select(_ => generator.Generate(_)).Where(criteria.CheckConditions))
                    {
                        rowList.Add(CreateRow(res));
                    }
                }
            } 
            else
            {
                var criteria = new EspeonCriteria(AND(builder.ToArray()));

                for (uint H = GetValueDec(id_Hmin); H <= GetValueDec(id_Hmax); H++)
                for (uint A = GetValueDec(id_Amin); A <= GetValueDec(id_Amax); A++)
                for (uint B = GetValueDec(id_Bmin); B <= GetValueDec(id_Bmax); B++)
                for (uint C = GetValueDec(id_Cmin); C <= GetValueDec(id_Cmax); C++)
                for (uint D = GetValueDec(id_Dmin); D <= GetValueDec(id_Dmax); D++)
                for (uint S = GetValueDec(id_Smin); S <= GetValueDec(id_Smax); S++)
                {
                    foreach (var res in CoStarterGenerator.CalcBackEspeon(H, A, B, C, D, S).Select(_ => generator.Generate(_)).Where(criteria.CheckConditions))
                    {
                        rowList.Add(CreateRow(res));
                    }
                }
            }

            if (id_CheckClearOnSearch.Checked)
            {
                DGV_id.Rows.Clear();
            }
            else if (id_CheckDivideResults.Checked && DGV_id.Rows.Count > 0)
            {
                var row = new DataGridViewRow();
                row.CreateCells(DGV_id);
                DGV_id.Rows.Add(row);
            }

            DGV_id.Rows.AddRange(rowList.ToArray());
        }

        private void id_FromPID_CheckedChanged(object sender, EventArgs e)
        {
            id_PIDBox.Enabled = id_FromPID.Checked;
            id_FromID_Square.Enabled = id_FromPID.Checked;
            id_FromID_Star.Enabled = id_FromPID.Checked;

            id_SIDBox.Enabled = !id_FromPID.Checked;
        }

        private void id_FromID_Square_CheckedChanged(object sender, EventArgs e)
        {
            if(!id_FromID_Square.Checked && !id_FromID_Star.Checked)
                id_FromID_Square.Checked = true;
        }

        private void id_FromID_Star_CheckedChanged(object sender, EventArgs e)
        {
            if (!id_FromID_Square.Checked && !id_FromID_Star.Checked)
                id_FromID_Star.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_FromSID.Checked)
            {
                var gen = new CoStarterGenerator();

                var tid = (uint)id_TIDBox.Value;
                var sid = (uint)id_SIDBox.Value;

                var res = CoStarterGenerator.CalcBack(tid, sid).Select(_ => CreateRow(gen.Generate(_))).ToArray();

                if (id_CheckClearOnSearch.Checked)
                {
                    DGV_id.Rows.Clear();
                }
                else if (id_CheckDivideResults.Checked && DGV_id.Rows.Count > 0)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(DGV_id);
                    DGV_id.Rows.Add(row);
                }

                DGV_id.Rows.AddRange(res);
            }
            else
            {
                var gen = new CoStarterGenerator();

                var tid = (uint)id_TIDBox.Value;
                var shinyType = (id_FromID_Square.Checked ? ShinyType.Square : 0) | (id_FromID_Star.Checked ? ShinyType.Star : 0);

                var pids = id_PIDBox.Text.Split('\n').Select(_ =>
                {
                    var line = _.Trim();
                    if (line.RegaxReplace("[^0-9A-F]", string.Empty) == string.Empty) return null;
                    else return line;
                }).Where(_ => _ != null).Select(_ => Convert.ToUInt32(_, 16));

                if (id_CheckClearOnSearch.Checked)
                    DGV_id.Rows.Clear();

                if (id_CheckDivideResults.Checked)
                {
                    foreach (var pid in pids)
                    {
                        var res = CoStarterGenerator.CalcBack(tid, pid, shinyType).Select(_ => CreateRow(gen.Generate(_), pid)).ToArray();

                        var row = new DataGridViewRow();
                        row.CreateCells(DGV_id, $"{pid:X8}");
                        DGV_id.Rows.Add(row);

                        DGV_id.Rows.AddRange(res);
                    }
                }
                else
                {
                    var hasSeen = new HashSet<uint>();
                    foreach (var pid in pids)
                    {
                        var psv = (pid >> 16) ^ (pid & 0xFFFF);
                        if (hasSeen.Contains(psv)) continue;

                        hasSeen.Add(psv);
                        var res = CoStarterGenerator.CalcBack(tid, pid, shinyType).Select(_ => CreateRow(gen.Generate(_), pid)).ToArray();

                        DGV_id.Rows.AddRange(res);
                    }
                }
            }
        }

        private void id_ClearButton_Click(object sender, EventArgs e)
        {
            DGV_id.Rows.Clear();
        }

        private void id_NatureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_CheckNature.Checked = true;
        }

        private void id_HiddePowerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_CheckHPType.Checked = true;
        }

        #endregion

        private uint id_displaying;

        private void DisplayIDTarget()
        {
            var seed = id_TargetSeedBox.Seed;
            if (seed == id_displaying) return;

            id_displaying = seed;
            if (!seed.IsAccessibleInNameScreen())
            {
                id_IDLabel.Text = "名前入力画面の不定消費に巻き込まれるseedです";
                id_UmbreonLabel.Text = "";
                id_EspeonLabel.Text = "";

                groupBox12.Enabled = groupBox10.Enabled = false;
            }
            else
            {
                groupBox12.Enabled = groupBox10.Enabled = true;

                var res = (new CoStarterGenerator()).Generate(seed);

                var umbreon = res.Umbreon;
                var espeon = res.Espeon;

                id_IDLabel.Text = $"{res.TID:d5} - {res.SID:d5}";
                id_UmbreonLabel.Text = $"{umbreon.Nature.ToJapanese()} {string.Join("-", umbreon.IVs.Select(_ => $"{_:d2}"))} ({string.Join("-", umbreon.Stats)}) {umbreon.HiddenPowerType.ToKanji()}{umbreon.HiddenPower}";
                id_EspeonLabel.Text = $"{espeon.Nature.ToJapanese()} {string.Join("-", espeon.IVs.Select(_ => $"{_:d2}"))} ({string.Join("-", espeon.Stats)}) {espeon.HiddenPowerType.ToKanji()}{espeon.HiddenPower}";
            }
        }

        private void id_TargetSeedBox_Leave(object sender, EventArgs e) => DisplayIDTarget();

        private void id_TargetSeedBox_Validated(object sender, EventArgs e) => DisplayIDTarget();

        private void id_CalcAdvanceButton_Click(object sender, EventArgs e)
        {
            var current = id_CurrentSeedBox.Seed;
            var target = id_TargetSeedBox.Seed;

            var frames = (uint)(id_TimerFrameBox.Value + id_BlankBox.Value);

            var namingStart = target.BackInNamingScreen(frames);

            id_AdvanceResultBox.Value = namingStart.GetIndex(current);
            id_StartingSeedBox.Text = $"{namingStart:X8}";
        }

        private void id_SearchGapButton_Click(object sender, EventArgs e)
        {
            var targetSeed = id_TargetSeedBox.Seed;
            var startingSeed = id_StartingSeedBox.Seed;

            var tid = (uint)id_DrawnTIDBox.Value;
            var targetFrame = (int)(id_TimerFrameBox.Value + id_BlankBox.Value);
            var range = (int)id_RangeBox.Value;

            var l = Math.Max(targetFrame - range, 0);
            var r = targetFrame + range;

            DGV_ID_Gap.Rows.Clear();

            var gen = new CoStarterGenerator();
            var rows = startingSeed.EnumerateSeedAtNamingScreen().EnumerateGeneration(gen).WithIndex()
                .Skip(l)
                .Take(r - l + 1)
                .Where(_ => _.element.TID == tid)
                .Select(_ => {
                    var (idx, result) = _;

                    var seed = result.HeadSeed;
                    var umbreon = result.Umbreon;
                    var espeon = result.Espeon;

                    var row = new DataGridViewRow();
                    row.CreateCells(DGV_ID_Gap,
                        idx - targetFrame, $"{result.TID:d5}", $"{result.SID:d5}",
                        "ブラッキー", umbreon.Nature.ToJapanese(),
                        umbreon.IVs[0], umbreon.IVs[1], umbreon.IVs[2], umbreon.IVs[3], umbreon.IVs[4], umbreon.IVs[5],
                        $"{umbreon.HiddenPowerType.ToKanji()}{umbreon.HiddenPower}",
                        "エーフィ", espeon.Nature.ToJapanese(),
                        espeon.IVs[0], espeon.IVs[1], espeon.IVs[2], espeon.IVs[3], espeon.IVs[4], espeon.IVs[5],
                        $"{espeon.HiddenPowerType.ToKanji()}{espeon.HiddenPower}"
                    );

                    return row;
                }).ToArray();

            DGV_ID_Gap.Rows.AddRange(rows);
        }


        private ICriteriaNode<CoStarterResult> node;
        private EditorForm editorForm;
        private void button5_Click(object sender, EventArgs e)
        {
            if (editorForm == null || editorForm.IsDisposed) return;

            try
            {
                var node = StarterCriteriaLanguage.TryParse(editorForm.Script);
                this.node = node;
                button10.Enabled = true;
                responce1.Text = "";
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            var seed = seedBox1.Seed;
            var max = (int)numericUpDown1.Value;

            var criteria = node.Build();

            var gen = new CoStarterGenerator();

            dataGridView6.Rows.Clear();
            var list = new List<DataGridViewRow>();
            foreach ((var index, var res) in seed.EnumerateSeedAtNamingScreen().Take(max).EnumerateGeneration(gen)
                .WithIndex().Where(_ => criteria.CheckConditions(_.element)))
            {
                var head = res.HeadSeed;
                var umbreon = res.Umbreon;
                var espeon = res.Espeon;

                var row = new DataGridViewRow();
                row.CreateCells(dataGridView6,
                    index, $"{head:X8}", $"{res.TID:d5}", $"{res.SID:d5}",
                    "ブラッキー", $"{umbreon.PID:X8}", umbreon.Nature.ToJapanese(),
                    umbreon.IVs[0], umbreon.IVs[1], umbreon.IVs[2], umbreon.IVs[3], umbreon.IVs[4], umbreon.IVs[5],
                    $"{umbreon.HiddenPowerType.ToKanji()}{umbreon.HiddenPower}",
                    "エーフィ", $"{espeon.PID:X8}", espeon.Nature.ToJapanese(),
                    espeon.IVs[0], espeon.IVs[1], espeon.IVs[2], espeon.IVs[3], espeon.IVs[4], espeon.IVs[5],
                    $"{espeon.HiddenPowerType.ToKanji()}{espeon.HiddenPower}"
                );
                list.Add(row);
            }

            dataGridView6.Rows.AddRange(list.ToArray());

            responce1.Text = $"{list.Count}件見つかりました";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (editorForm == null || editorForm.IsDisposed)
            {
                var defaultValue = System.IO.File.Exists("./criteria.txt") ? System.IO.File.ReadAllText("./criteria.txt") : "";
                editorForm = new EditorForm(defaultValue);
            }

            editorForm.Show();
            button5.Enabled = true;
        }
    }
}
