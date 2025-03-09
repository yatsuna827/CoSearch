using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using PokemonPRNG.LCG32.GCLCG;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.AdvancePlanning;
using PokemonCoRNGLibrary.AdvanceSource;
using PokemonCoRNGLibrary.ProvidedData;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch
{
    public partial class PathCalculationForm : Form
    {
        public PathCalculationForm(ProvidedCoDarkPokemonData pokemon, uint current, uint target, uint forcedAdvances = 0)
        {
            InitializeComponent();

            _darkPokemon = pokemon;

            currentSeedBox.Text = $"{current:X8}";
            targetSeedBox.Text = $"{target:X8}";

            _targetSeed = target;
            _forcedAdvances = forcedAdvances;

            _resultDataGridView = new DataGridViewWrapper<BattleNowAdvanceResultBinder>(dataGridView_p1);
            _dataGridViewWrapper_p2 = new DataGridViewWrapper<BlinkAndSnatchListBinder>(dataGridView_p2);
            _dataGridViewWrapper_p4 = new DataGridViewWrapper<BlinkAndIrregularAdvanceBinder>(dataGridView_p4);

            irregularAdvanceBox_p4.SelectedIndex = 0;

            var targetIndiv = pokemon.GetGenerator().WithOffset(forcedAdvances).Generate(target).Content;
            this.Text = $"消費計算 - {pokemon.Slot.Species.Name} {targetIndiv.Nature.ToJapanese()} {string.Join("-", targetIndiv.IVs.Select(_ => $"{_:d2}"))}";
        
            // 連続戦闘
            // マクノシタ以外は進化後瞬き、マクノシタは猶予が広いのでステータス画面で消費して頑張る
            if (new[] { "マクノシタ", "アブソル", "ヘルガー", "トロピウス", "メタグロス", "ツボツボ" }.Contains(pokemon.Slot.Species.Name))
            {
                // 瞬きだけで消費
                tabControl.SelectedIndex = 2;
            }
            // 不定消費: パイラの洞窟
            else if (new[] { "アサナン", "チルット" }.Contains(pokemon.Slot.Species.Name))
            {
                tabControl.SelectedIndex = 3;
                irregularAdvanceBox_p4.SelectedIndex = 0;
            }
            // 不定消費: ダークポケモン研究所B2F
            else if (pokemon.Slot.Species.Name == "ビブラーバ")
            {
                tabControl.SelectedIndex = 3;
                irregularAdvanceBox_p4.SelectedIndex = 1;
            }
            // 不定消費: ダークポケモン研究所B3F
            else if (new[] { "アリアドス", "グランブル", "ライコウ" }.Contains(pokemon.Slot.Species.Name))
            {
                tabControl.SelectedIndex = 3;
                irregularAdvanceBox_p4.SelectedIndex = 2;
            }
            // 御三家
            else if (new[] { "ベイリーフ", "マグマラシ", "アリゲイツ" }.Contains(pokemon.Slot.Species.Name))
            {
                // スナッチ団アジトでの調整が一番楽なので瞬き+スナッチリスト
                tabControl.SelectedIndex = 1;
                // 不定消費はダークポケモン研究所B3Fに合わせておく
                irregularAdvanceBox_p4.SelectedIndex = 2;
            }
            // 町外れのスタンド
            else if (pokemon.Slot.Species.Name == "トゲチック")
            {
                tabControl.SelectedIndex = 3;
                irregularAdvanceBox_p4.SelectedIndex = 3;
            }
            // 連続戦闘するしかないやつ
            else if (new[] { "マンタイン", "ホウオウ" }.Contains(pokemon.Slot.Species.Name))
            {
                tabControl.SelectedIndex = 4;
            }
            // それ以外は瞬き+スナッチリスト
            else
            {
                tabControl.SelectedIndex = 1;
            }
        }

        private readonly ProvidedCoDarkPokemonData _darkPokemon;

        private readonly uint _targetSeed;
        private readonly uint _forcedAdvances;


        private SearchGapsForm _searchGapsForm;
        private void OnClick__SearchGapsButton(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox.Seed;

            if (_searchGapsForm == null || _searchGapsForm.IsDisposed)
            {
                _searchGapsForm = new SearchGapsForm(
                    _darkPokemon,
                    currentSeed,
                    _targetSeed,
                    _forcedAdvances
                );
            }
            else
            {
                _searchGapsForm.SetValue(currentSeed);
            }

            _searchGapsForm.Show();
            _searchGapsForm.Activate();
        }


        // page1 --------------------

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

        private (uint CurrentSeed, int AdvanceRoughlyCount, BattleNowAdvanceResult[] Result) _displayingResult_p1;

        private void OnClick__CalcButton_p1(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox.Seed;

            var targetIndex = _targetSeed.GetIndex(currentSeed);
            if (targetIndex > 500000)
            {
                MessageBox.Show($"目標seedが遠すぎます.\r\n{targetIndex}消費をとにかくバトルだけで消費するのはやめましょう.");
                return;
            }

            var range = (uint)RangeBox.Value;

            var (count, seed) = (dataGridView_p1.Columns[2].Visible = RoughlyButton.Checked) 
                ? BattleNowAdvance.AdvanceRoughly(currentSeed, targetIndex, (uint)RoughlyRangeBox.Value)
                : (0, currentSeed);

            var res = BattleNowAdvance.Advance(seed, targetIndex - seed.GetIndex(currentSeed), range)
                .OrderByDescending(_ => _.Seed.GetIndex(currentSeed)).ToArray();

            _resultDataGridView.SetData(res.Select(_ => new BattleNowAdvanceResultBinder(_.Seed, currentSeed, targetIndex, count, _.Count)).ToArray());

            _displayingResult_p1 = (currentSeed, count, res);
        }

        private void OnCellDoubleClick__DataGridView_p1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var (currentSeed, cnt, displayingList) = _displayingResult_p1;

            var targetIndex = _targetSeed.GetIndex(currentSeed);
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

        private void OnCellFormatting__DataGridView_p1(object sender, DataGridViewCellFormattingEventArgs e)
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

        // page2 --------------------

        private readonly DataGridViewWrapper<BlinkAndSnatchListBinder> _dataGridViewWrapper_p2;

        private void OnClick__CalcButton_p2(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox.Seed;

            var targetIndex = _targetSeed.GetIndex(currentSeed);
            if (targetIndex > 500000)
            {
                MessageBox.Show($"{targetIndex}消費は多すぎます.\r\nもう少し近くなるまで適当に消費してください.");
                return;
            }


            var snatchMax = (int)maxSnatchListOpeningBox_p2.Value;
            var coolTime = (int)coolTimeBox.Value;
            var onlyCompleted = checkOnlyCompleted_p2.Checked;

            // TODO: 遠すぎるときに警告を出す. どれくらいを基準にする？

            var openSnatchList = new OpenSnatchList();

            var result = new List<BlinkAndSnatchListBinder>();
            foreach (var (seed, interval, frame, lcgIndex) in currentSeed.EnumerateBlinkingSeed(coolTime).TakeWhile(_ => _.seed.GetIndex(currentSeed) <= targetIndex))
            {
                var snatchStream = seed.EnumerateSeed(openSnatchList).TakeWhile((_) => _.GetIndex(currentSeed) <= targetIndex).ToArray();
                var snatchCount = snatchStream.Length - 1;
                var terminal = snatchStream.Last();

                if (onlyCompleted && terminal != _targetSeed) continue;
                if (snatchCount > snatchMax) continue;

                var snatchCell = terminal == _targetSeed ? $"{snatchCount}回" : $"{snatchCount}回 + {_targetSeed.GetIndex(terminal)} [F]";

                result.Add(new BlinkAndSnatchListBinder(frame, seed, interval, lcgIndex, _targetSeed.GetIndex(seed), snatchCell));
            }
            _dataGridViewWrapper_p2.SetData(result);
        }

        private void OnCellDoubleClick__DataGridView_p2(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (row < 0) return;

            var currentSeed = currentSeedBox.Seed;

            var terminalIndex = Convert.ToUInt32((dataGridView_p2[1, e.RowIndex].Value as string), 16).GetIndex(currentSeed);

            var cool = (int)coolTimeBox.Value;

            var timeline = currentSeed.EnumerateBlinkingSeed(cool).TakeWhile(_ => _.lcgIndex <= terminalIndex).Select(_ => _.interval).ToArray();

            var breaking = (int)timerBreakingFramesBox.Value;
            var frq = (double)timerFrequencyBox.Value;

            if (timeline.Length > 0)
                new BlinkTimer(timeline, breaking).Show();
        }

        // page3 --------------------

        private void OnClick__CalcButton_p3(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox.Seed;

            var targetIndex = _targetSeed.GetIndex(currentSeed);
            if (targetIndex > 500000)
            {
                MessageBox.Show($"{targetIndex}消費は多すぎます.\r\nもう少し近くなるまで適当に消費してください.");
                return;
            }

            // 「現在地から目標seedまでの待機時間」を算出する
            // arr - 1が必要な待機時間(フレーム)
            // -1が必要なのは、先頭のseedは現在地である(=0基準である)ため

            var cool = (int)coolTimeBox.Value;
            var handler = new BlinkObjectEnumeratorHanlder(new BlinkObject(cool));

            var totalWaitingTime = currentSeed.EnumerateSeed(handler)
                .TakeWhile(_ => _.GetIndex(currentSeed) < targetIndex).Count();

            // 「現在地から目標seedまでの瞬き間隔の系列」
            var blinkSeries = currentSeed.EnumerateActionSequence(handler)
                .TakeWhile(_ => _.Seed.GetIndex(currentSeed) <= targetIndex);

            var rest = totalWaitingTime - blinkSeries.Sum(_ => _.Interval);

            // 目標seedがちょうど瞬きに重なるとは限らないため
            // 余りが出る場合は末尾に追加する必要がある
            var blinks = rest > 0 ?
                blinkSeries.Select(_ => _.Interval).Append(rest).ToArray() :
                blinkSeries.Select(_ => _.Interval).ToArray();

            var breaking = (int)timerBreakingFramesBox.Value;

            if (blinks.Length > 0)
                new BlinkTimer(blinks, breakingFrames: breaking).Show();
        }

        // page4 --------------------

        private readonly DataGridViewWrapper<BlinkAndIrregularAdvanceBinder> _dataGridViewWrapper_p4;

        private ISeedEnumeratorHandler GetSeedEnumeratorHandler_p4()
        {
            if (irregularAdvanceBox_p4.SelectedIndex == 0) return new PyriteCave();
            if (irregularAdvanceBox_p4.SelectedIndex == 1) return new CipherLabB2F();
            if (irregularAdvanceBox_p4.SelectedIndex == 2) return new CipherLabB3F();
            if (irregularAdvanceBox_p4.SelectedIndex == 3) return new OutskirtStand();

            // never reach
            throw new Exception();
        }

        private void OnClick__CalcButton_p4(object sender, EventArgs e)
        {
            var currentSeed = currentSeedBox.Seed;

            var minBlinkFrames = (int)minBlinkFrameBox_p4.Value;
            var maxBlinkFrames = (int)maxBlinkFrameBox_p4.Value;
            var minFrames = (int)minFrameBox_p4.Value;
            var maxFrames = (int)maxFrameBox_p4.Value;
            var coolTime = (int)coolTimeBox.Value;

            var planner = new BlinkAdvancePlanner(new BlinkObject(cool: coolTime), GetSeedEnumeratorHandler_p4());

            var result = new List<BlinkAndIrregularAdvanceBinder>();
            foreach (var (blink, second) in planner.CalculatePlanning(currentSeed, _targetSeed, 0, minBlinkFrames, maxBlinkFrames, minFrames, maxFrames))
            {
                result.Add(new BlinkAndIrregularAdvanceBinder(blink.Frame, blink.Seed, blink.Seed.GetIndex(currentSeed), second.Frame));
            }
            _dataGridViewWrapper_p4.SetData(result);
        }

        private (uint CurrentSeed, uint BlinkFrames, uint FieldAdvanceFrames)? _selectedRow_p4;
        private SearchFieldAdvanceGapsForm _searchGapsForm_p4;
        private void OnClick__SearchGapsButton_p4(object sender, EventArgs e)
        {
            if (!_selectedRow_p4.HasValue) return;

            var (currentSeed, targetBlinkFrames, targetFrames) = _selectedRow_p4.Value;
            if (_searchGapsForm_p4 == null || _searchGapsForm_p4.IsDisposed)
            {
                _searchGapsForm_p4 = new SearchFieldAdvanceGapsForm(
                    _darkPokemon,
                    (FieldAdvanceType)irregularAdvanceBox_p4.SelectedIndex,
                    currentSeed,
                    _targetSeed,
                    targetBlinkFrames: targetBlinkFrames,
                    targetFrames: targetFrames,
                    forcedAdvances: _forcedAdvances
                );
            }
            else
            {
                _searchGapsForm_p4.SetValues(currentSeed, _targetSeed, targetBlinkFrames, targetFrames);
            }

            _searchGapsForm_p4.Show();
            _searchGapsForm_p4.Activate();
        }

        private void OnCellDoubleClick__DataGridView_p4(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (row < 0) return;

            var currentSeed = currentSeedBox.Seed;

            var blinkFramesString = (dataGridView_p4[0, row].Value as string);
            var fieldAdvanceFramesString = (dataGridView_p4[3, row].Value as string);
            var blinkFrames = uint.Parse(blinkFramesString.Replace("F", string.Empty));
            var fieldAdvanceFrames = uint.Parse(fieldAdvanceFramesString.Replace("F", string.Empty));

            _selectedRow_p4 = (currentSeed, blinkFrames, fieldAdvanceFrames);

            searchGapsButton_p4.Enabled = true;

            var terminalIndex = Convert.ToUInt32((dataGridView_p4[1, row].Value as string), 16).GetIndex(currentSeed);

            var coolTime = (int)coolTimeBox.Value;

            var timeline = currentSeed.EnumerateBlinkingSeed(coolTime).TakeWhile(_ => _.lcgIndex <= terminalIndex).Select(_ => _.interval).ToArray();

            if (timeline.Length > 0)
                new BlinkTimer(timeline, breakingFrames: (int)timerBreakingFramesBox.Value, frequency: (double)timerFrequencyBox.Value).Show();
        }

        // page5 --------------------

        private BlinkWatcher _watcherForm;
        private void OnClickCalcButton_p5(object sender, EventArgs e)
        {
            if (_watcherForm == null || _watcherForm.IsDisposed)
                _watcherForm = new BlinkWatcher((int)coolTimeBox.Value, checkEnemyBlinking_p5.Checked);
            _watcherForm.Show();
        }

    }

    class BattleNowAdvanceResultBinder
    {
        [DataGridViewRowHeader(100, "合計消費数")]
        public uint Advances { get; }

        [DataGridViewRowHeader(100, "残り消費数")]
        public uint Gaps { get; }

        [DataGridViewRowHeader(100, "シングル最強")]
        public string AdvanceRoughlyCount { get; }

        [DataGridViewRowHeader(64, "手数")]
        public int NumberOfSelects { get; }

        public BattleNowAdvanceResultBinder(uint seed, uint currentSeed, uint targetSteps, int advanceRoughlyCount, int numberOfSelects)
        {
            var idx = seed.GetIndex(currentSeed);

            Advances = idx;
            Gaps = targetSteps - idx;
            AdvanceRoughlyCount = $"{advanceRoughlyCount} 回";
            NumberOfSelects = numberOfSelects;
        }
    }

    class BattleNowAdvancePathBinder
    {
        [DataGridViewRowHeader(120, "選択するルール")]
        public string Rule { get; }

        [DataGridViewRowHeader(64, "")]
        public string PlayerName { get; }

        [DataGridViewRowHeader(80, "")]
        public string Team { get; }

        [DataGridViewRowHeader(100, "seed")]
        public string Seed { get; }

        [DataGridViewRowHeader(100, "合計消費数")]
        public uint TotalAdvances { get; }

        [DataGridViewRowHeader(100, "残り消費数")]
        public uint RemainingAdvances { get; }

        public BattleNowAdvancePathBinder(uint currentSeed, uint targetIndex, RentalBattleResult result, string ruleName)
        {
            var idx = result.TailSeed.GetIndex(currentSeed);

            Seed = $"{result.TailSeed:X8}";
            Rule = ruleName;
            PlayerName = result.PlayerName;
            Team = result.PlayerTeam[0].Name;
            TotalAdvances = idx;
            RemainingAdvances = targetIndex - idx;
        }
    }

    class BlinkAndSnatchListBinder
    {
        [DataGridViewRowHeader(64, "F")]
        public int Frames { get; }

        [DataGridViewRowHeader(88, "seed")]
        public string Seed { get; }

        [DataGridViewRowHeader(64, "間隔")]
        public int Interval { get; }

        [DataGridViewRowHeader(64, "消費数")]
        public string Advances { get; }

        [DataGridViewRowHeader(64, "残り")]
        public string RemainingAdvances { get; }

        [DataGridViewRowHeader(88, "スナッチリスト")]
        public string NumberOfOpeningSnatchList { get; }

        public BlinkAndSnatchListBinder(int frames, uint seed, int interval, uint advances, uint remaining, string snatchList)
        {
            Frames = frames;
            Seed = $"{seed:X8}";
            Interval = interval;
            Advances = $"{advances} [F]";
            RemainingAdvances = $"{remaining} [F]";
            NumberOfOpeningSnatchList = snatchList;
        }
    }

    class BlinkAndIrregularAdvanceBinder
    {
        [DataGridViewRowHeader(88, "瞬き")]
        public string BlinkFrames { get; }

        [DataGridViewRowHeader(100, "瞬き終了時")]
        public string Seed { get; }

        [DataGridViewRowHeader(100, "消費数")]
        public string Advances { get; }

        [DataGridViewRowHeader(88, "不定消費")]
        public string SecondFrames { get; }

        public BlinkAndIrregularAdvanceBinder(int blinkFrames, uint seed, uint advances, int secondFrames)
        {
            BlinkFrames = $"{blinkFrames}F";
            Seed = $"{seed:X8}";
            Advances = $"{advances} [F]";
            SecondFrames = $"{secondFrames}F";
        }
    }

}
