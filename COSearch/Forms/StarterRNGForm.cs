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
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.AdvanceSource;
using PokemonCoRNGLibrary.Criteria;
using PokemonCoRNGLibrary.Criteria.Starter;
using PokemonCoRNGLibrary.StarterCriteriaLanguage;

using static COSearch.Util;
using System.Reflection;

namespace COSearch
{
    // TODO: SelectValueの設定、コントロールのリネーム
    public partial class StarterRNGForm : Form
    {
        public StarterRNGForm()
        {
            InitializeComponent();

            var dgvPropertyInfo = typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            dgvPropertyInfo.SetValue(dataGridView6, true, null);
            dgvPropertyInfo.SetValue(DGV_id, true, null);
            dgvPropertyInfo.SetValue(DGV_ID_Gap, true, null);

            _resultDataGridView = new DataGridViewWrapper<BattleNowAdvanceResultBinder>(dataGridView_p4);

            natureBox_FromStatus.Initialize();
            checkNature.Checked = false;

            hiddenPowerType_FromStatus.Initialize();
            checkHiddenPowerType.Checked = false;

            pokemonBox_FromStatus.SelectedIndex = 0;

            DisplayIDTarget();
        }

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);


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

            if (pid != null)
            {
                var psv = (pid.Value >> 16) ^ (pid.Value & 0xFFFF);
                var tsv = res.TID ^ res.SID;
                if ((psv ^ tsv) == 0)
                {
                    row.Cells[1].Style.ForeColor = Color.MediumPurple;
                    row.Cells[2].Style.ForeColor = Color.MediumPurple;
                }
            }

            return row;
        }
        private void Click__CalcButton_FromStatus(object sender, EventArgs e)
        {
            var generator = new CoStarterGenerator();
            var rowList = new List<DataGridViewRow>();

            var builder = new List<ICriteria<GCIndividual>>();
            if (checkNature.Checked) builder.Add(new NatureCriteria(natureBox_FromStatus.SelectedNature));
            if (checkHiddenPowerPower.Checked) builder.Add(new HiddenPowerPowerCriteria((uint)hiddenPowerPowerBox_FromStatus.Value));
            if (checkHiddenPowerType.Checked) builder.Add(new HiddenPowerTypeCriteria(hiddenPowerType_FromStatus.SelectedType));

            if (pokemonBox_FromStatus.Text == "ブラッキー")
            {
                var criteria = new UmbreonCriteria(Criteria.AND(builder.ToArray()));

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
                var criteria = new EspeonCriteria(Criteria.AND(builder.ToArray()));

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
            pidBox_FromID.Enabled = checkFromPID_FromID.Checked;
            id_FromID_Square.Enabled = checkFromPID_FromID.Checked;
            id_FromID_Star.Enabled = checkFromPID_FromID.Checked;

            sidBox_FromID.Enabled = !checkFromPID_FromID.Checked;
        }

        private void id_FromID_Square_CheckedChanged(object sender, EventArgs e)
        {
            if (!id_FromID_Square.Checked && !id_FromID_Star.Checked)
                id_FromID_Square.Checked = true;
        }

        private void id_FromID_Star_CheckedChanged(object sender, EventArgs e)
        {
            if (!id_FromID_Square.Checked && !id_FromID_Star.Checked)
                id_FromID_Star.Checked = true;
        }

        private void Click__CalcButton_FromID(object sender, EventArgs e)
        {
            if (checkFromSID_FromID.Checked)
            {
                var gen = new CoStarterGenerator();

                var tid = (uint)tidBox_FromID.Value;
                var sid = (uint)sidBox_FromID.Value;

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

                var tid = (uint)tidBox_FromID.Value;
                var shinyType = (id_FromID_Square.Checked ? ShinyType.Square : 0) | (id_FromID_Star.Checked ? ShinyType.Star : 0);

                var pids = pidBox_FromID.Text.Split('\n').Select(_ =>
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

        private void Click__ClearButton(object sender, EventArgs e)
        {
            DGV_id.Rows.Clear();
        }

        private void SelectedIndexChanged__NatureBox(object sender, EventArgs e)
        {
            checkNature.Checked = true;
        }

        private void SelectedIndexChanged__HiddePowerType(object sender, EventArgs e)
        {
            checkHiddenPowerType.Checked = true;
        }

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

            if (namingStart.GetIndex(current) <= 50_0000)
            {
                currentSeedBox_p4.Text = id_CurrentSeedBox.Text;
                targetAdvancesBox_p4.Value = namingStart.GetIndex(current);
            }
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
            var rows = startingSeed.EnumerateSeed(new NamingScreen()).EnumerateGeneration(gen).WithIndex()
                .Skip(l)
                .Take(r - l + 1)
                .Where(_ => _.Element.TID == tid)
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
            catch (Exception ex)
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
            foreach ((var index, var res) in seed.EnumerateSeed(new NamingScreen()).Take(max).EnumerateGeneration(gen)
                .WithIndex().Where(_ => criteria.CheckConditions(_.Element)))
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
            loadCriteriaButton.Enabled = true;
        }

        private static readonly Dictionary<string, RentalTeamRank> _rules = new Dictionary<string, RentalTeamRank>()
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
        private readonly DataGridViewWrapper<BattleNowAdvanceResultBinder> _resultDataGridView;
        private (uint CurrentSeed, uint TargetIndex, int AdvanceRoughlyCount, BattleNowAdvanceResult[] Result) _displayingResult_p4;
        private void calcButton_p1_Click(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox_p4.Seed;

            var targetIndex = (uint)targetAdvancesBox_p4.Value;
            var range = (uint)rangeBox_p4.Value;

            var (count, seed) = (dataGridView_p4.Columns[2].Visible = RoughlyButton.Checked)
                ? BattleNowAdvance.AdvanceRoughly(currentSeed, targetIndex, (uint)RoughlyRangeBox.Value)
                : (0, currentSeed);

            var res = BattleNowAdvance.Advance(seed, targetIndex - seed.GetIndex(currentSeed), range)
                .OrderByDescending(_ => _.Seed.GetIndex(currentSeed)).ToArray();

            _resultDataGridView.SetData(res.Select(_ => new BattleNowAdvanceResultBinder(_.Seed, currentSeed, targetIndex, count, _.Count)).ToArray());

            _displayingResult_p4 = (currentSeed, targetIndex, count, res);
        }
        private void OnCellDoubleClick__DataGridView_p4(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var (currentSeed, targetIndex, cnt, displayingList) = _displayingResult_p4;
            var pro = displayingList[e.RowIndex].GetProcedure();

            var result = new List<BattleNowAdvancePathBinder>();

            var seed = currentSeed;
            for (int i = 0; i < cnt; i++)
            {
                var res = BattleNow.SingleBattle.Ultimate.Generate(seed);
                seed = res.TailSeed;
                result.Add(new BattleNowAdvancePathBinder(currentSeed, targetIndex, res, BattleNow.SingleBattle.Ultimate.RuleName));
            }
            foreach (var rule in pro.Select(_ => _rules[_]))
            {
                var res = rule.Generate(seed);
                seed = res.TailSeed;
                result.Add(new BattleNowAdvancePathBinder(currentSeed, targetIndex, res, rule.RuleName));
            }

            new ResultWindow<BattleNowAdvancePathBinder>(result, title: "とにかくバトルで消費", width: 650).Show();
        }

        private void OnCellFormatting__DataGridView_p4(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var val = (uint)e.Value;
                if (val % 24 == 0)
                {
                    e.CellStyle.BackColor = Color.DeepSkyBlue;
                }
            }
        }

    }
}
