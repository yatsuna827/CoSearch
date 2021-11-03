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
    public partial class HiddenPowerTypePanel : UserControl
    {
        public HiddenPowerTypePanel()
        {
            InitializeComponent();


            typeLabels = new Label[4, 4]
            {
                { label1, label2, label3, label4 },
                { label5, label6, label7, label8 },
                { label9, label10, label11, label12 },
                { label13, label14, label15, label16 },
            };

            {
                var propertyInfo = typeof(TableLayoutPanel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                propertyInfo.SetValue(tableLayoutPanel, true, null);
            }
            {
                var propertyInfo = typeof(Label).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                for (int i = 0; i < 4; i++)
                    for (int k = 0; k < 4; k++)
                    {
                        propertyInfo.SetValue(typeLabels[i, k], true, null);
                        typeLabels[i, k].MouseDown += TableLayoutPanel_Click;
                    }
            }
            selected = new Font(label1.Font, FontStyle.Bold);
            unselected = new Font(label1.Font, FontStyle.Regular);
        }

        public PokeType[] SelectedTypes
        {
            get => Enumerable.Range(0, 16).Where(_ => typeChecked[_ % 4, _ / 4]).Select(_ => pokeTypes[_ % 4, _ / 4]).ToArray();
        }

        private readonly Font selected, unselected;
        private readonly PokeType[,] pokeTypes = new PokeType[4, 4]
        {
            { PokeType.Fire, PokeType.Water, PokeType.Electric, PokeType.Grass },
            { PokeType.Ice, PokeType.Psychic, PokeType.Dragon, PokeType.Dark },
            { PokeType.Fighting, PokeType.Poison, PokeType.Ground, PokeType.Flying },
            { PokeType.Bug, PokeType.Rock, PokeType.Ghost, PokeType.Steel }
        };
        private readonly Label[,] typeLabels;
        private readonly bool[,] typeChecked = new bool[4, 4];
        private void TableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(typeChecked[e.Row, e.Column])
            {
                typeLabels[e.Row, e.Column].ForeColor = SystemColors.ControlText;
                typeLabels[e.Row, e.Column].Font = selected;
            }
            else
            {
                typeLabels[e.Row, e.Column].ForeColor = Color.Gray;
                typeLabels[e.Row, e.Column].Font = unselected;
            }
        }

        private void TableLayoutPanel_Click(object sender, EventArgs e)
        {
            var p = tableLayoutPanel.PointToClient(MousePosition);
            typeChecked[p.Y / 23, p.X / 50] ^= true;

            tableLayoutPanel.Invalidate();
        }

    }
}
