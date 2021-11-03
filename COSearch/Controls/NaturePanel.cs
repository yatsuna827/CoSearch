using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch.IDRNG
{
    public partial class NaturePanel : UserControl
    {
        public NaturePanel()
        {
            InitializeComponent();

            natureLabels = new Label[5, 5]
            {
                { label1, label2, label3, label4, label5 },
                { label6, label7, label8, label9, label10 },
                { label11, label12, label13, label14, label15 },
                { label16, label17, label18, label19, label20 },
                { label21, label22, label23, label24, label25 },
            };

            {
                var propertyInfo = typeof(TableLayoutPanel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                propertyInfo.SetValue(tableLayoutPanel, true, null);
            }
            {
                var propertyInfo = typeof(Label).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                for (int i = 0; i < 5; i++)
                    for (int k = 0; k < 5; k++)
                    {
                        propertyInfo.SetValue(natureLabels[i, k], true, null);
                        natureLabels[i, k].MouseDown += TableLayoutPanel_Click;
                    }
            }

            this.MinimumSize = new Size(326, 116);
            this.MaximumSize = new Size(326, 116);

            selected = new Font(label1.Font, FontStyle.Bold);
            unselected = new Font(label1.Font, FontStyle.Regular);
        }

        public Nature [] SelectedNatures
        {
            get => Enumerable.Range(0, 25).Where(_ => natureChecked[_ % 5, _ / 5]).Select(_ => (Nature)_).ToArray();
        }

        private readonly Font selected, unselected;
        private readonly bool[,] natureChecked = new bool[5, 5];
        private readonly Label[,] natureLabels;
        private void TableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(natureChecked[e.Column, e.Row])
            {
                natureLabels[e.Row, e.Column].ForeColor = SystemColors.ControlText;
                natureLabels[e.Row, e.Column].Font = selected;
            }
            else
            {
                natureLabels[e.Row, e.Column].ForeColor = Color.Gray;
                natureLabels[e.Row, e.Column].Font = unselected;
            };
        }

        private void TableLayoutPanel_Click(object sender, EventArgs e)
        {
            var p = tableLayoutPanel.PointToClient(MousePosition);
            natureChecked[p.X / 64, p.Y / 23] ^= true;

            tableLayoutPanel.Invalidate();
        }
    }
}
