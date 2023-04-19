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

namespace COSearch
{
    public partial class BlinkWatcher : Form
    {
        public BlinkWatcher()
        {
            InitializeComponent();

            textBox1.Text = $"{0x5bf6861fu.GetIndex(0xB8EC1CDB)}";
        }

        private bool _working = false;
        private List<int> _blanks = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            _working ^= true;
            if (_working) _blanks = new List<int>();
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
                }
            }
        }
    }
}
