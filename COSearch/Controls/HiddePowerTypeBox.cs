using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch
{
    public partial class HiddePowerTypeBox : ComboBox
    {
        public HiddePowerTypeBox()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Size = new Size(52, 20);
        }

        private static readonly PokeType[] hiddenPowerType = new PokeType[16]
        {
            PokeType.Fighting,
            PokeType.Flying,
            PokeType.Poison,
            PokeType.Ground,
            PokeType.Rock,
            PokeType.Bug,
            PokeType.Ghost,
            PokeType.Steel,
            PokeType.Fire,
            PokeType.Water,
            PokeType.Grass,
            PokeType.Electric,
            PokeType.Psychic,
            PokeType.Ice,
            PokeType.Dragon,
            PokeType.Dark
        };
        public PokeType SelectedType { get => 0 <= SelectedIndex && SelectedIndex < 16 ? hiddenPowerType[SelectedIndex] : PokeType.None; }
        public void Initialize()
        {
            this.Items.Clear();
            this.Items.AddRange(hiddenPowerType.Select(_ => _.ToJapanese()).ToArray());
            this.SelectedIndex = 0;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
