using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSearch
{
    public partial class DigitFixedNumericUpDown : NumericUpDown
    {
        public DigitFixedNumericUpDown()
        {
            InitializeComponent();

            this.Enter += (s, e) => Select(0, Text.Length);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value.ToString().PadLeft(Digit, '0');
            }

        }
        private int digit = 4;
        public int Digit { get { return digit; } set { digit = Math.Max(1, value); } }
    }
}
