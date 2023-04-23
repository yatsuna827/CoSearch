using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokemonPRNG.LCG32.GCLCG;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.IrregularAdvance;

namespace COSearch
{
    public partial class BlinkWatcher : Form
    {
        public BlinkWatcher(int cooltime, bool enemyBlinking)
        {
            InitializeComponent();

            (_cooltime, _enemyBlinking) = (cooltime, enemyBlinking);
        }

        private bool _working = false;
        private List<int> _blanks = new List<int>();
        private uint _foundSeed;
        private int _index = -1;
        private readonly int _cooltime;
        private readonly bool _enemyBlinking;

        private void button1_Click(object sender, EventArgs e)
        {
            _working ^= true;
            if (_working)
            {
                _blanks = new List<int>();
                blankDGV.Rows.Clear();
                button1.Text = "観測中止";
            }
            else
            {
                button1.Text = "観測開始";
            }
        }

        private long _prev = 0;
        private void BlinkWatcher_KeyUp(object sender, KeyEventArgs e)
        {
            if (_working && !e.Shift)
            {
                var cur = DateTime.Now.Ticks;
                if (_prev != 0)
                {
                    var blank = (int)((cur - _prev) * 29.97 / 10_000_000);

                    var row = new DataGridViewRow();
                    row.CreateCells(blankDGV);
                    row.SetValues(new object[] { _blanks.Count, blank });
                    blankDGV.Rows.Add(row);

                    _blanks.Add(blank);
                }
                _prev = cur;

                if (_blanks.Count > 10)
                {
                    var seed = seedBox1.Seed;

                    var result = SeedFinder.FindCurrentSeedByBlinkInBattle(seed, 500000, _blanks.ToArray(), false, 10, 4);
                    textBox1.Text = string.Join(Environment.NewLine, result.Select(_ => $"{_.GetIndex(seed)}[F] {_:X8}"));

                    if (result.Count() == 1)
                    {
                        _foundSeed = result.First();
                        _index = (int)result.First().GetIndex(seed);
                        _working = false;
                        button1.Text = "観測開始";
                    }
                }
            }
        }

        private BlinkTimer _timer;
        private void button2_Click(object sender, EventArgs e)
        {
            if (_index != -1)
            {
                var initSeed = seedBox1.Seed;
                var target = seedBox2.Seed;
                var targetIndex = target.GetIndex(initSeed);

                // 「現在地から目標seedまでの待機時間」を算出する
                // arr - 1が必要な待機時間(フレーム)
                // -1が必要なのは、先頭のseedは現在地である(=0基準である)ため

                var blinkObjects = _enemyBlinking ? 
                    new[] {
                        new BlinkObject(10, 10),
                        new BlinkObject(10, 10),
                        new BlinkObject(_cooltime, 10)
                    } : 
                    new[] {
                        new BlinkObject(10, 10),
                        new BlinkObject(_cooltime, 10)
                    };

                var arr = initSeed.EnumerateSeed(new BlinkObjectEnumeratorHanlder(blinkObjects))
                    .SkipWhile(_ => _.GetIndex(initSeed) < _index)
                    .TakeWhile(_ => _.GetIndex(initSeed) <= targetIndex).ToArray();

                // 「現在地から目標seedまでの瞬き間隔の系列」
                var blinkSeries = initSeed.EnumerateBlinkingSeedInBattle()
                    .SkipWhile(_ => _.lcgIndex < _index)
                    .TakeWhile(_ => _.lcgIndex <= targetIndex);

                // 残り待機時間 - 瞬き間隔の系列の総和
                var rest = (arr.Length - 1) - blinkSeries.Skip(1).Sum(_ => _.interval);

                // 目標seedがちょうど瞬きに重なるとは限らないため
                // 余りが出る場合は末尾に追加する必要がある
                var blinks = rest > 0 ?
                    blinkSeries.Select(_ => _.interval).Append(rest).ToArray() :
                    blinkSeries.Select(_ => _.interval).ToArray();

                if (_timer == null || _timer.IsDisposed)
                    _timer = new BlinkTimer(blinks, breakingFrames: (int)numericUpDown21.Value, baseTick: _prev);

                _timer.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _prev = DateTime.Now.Ticks;

            var seed = seedBox1.Seed;

            var result = SeedFinder.FindCurrentSeedByBlinkInBattle(seed, 500000, new int[] { 853, 854, 443, 650, 609, 806, 650, 387, 837, 600 }, false, 10, 4);
            textBox1.Text = string.Join(Environment.NewLine, result.Select(_ => $"{_.GetIndex(seed)}[F] {_:X8}"));

            if (result.Count() == 1)
            {
                _foundSeed = result.First();
                _index = (int)result.First().GetIndex(seed);
                _working = false;
                button1.Text = "観測開始";
            }
        }
    }
}
