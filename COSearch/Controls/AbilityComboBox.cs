using System.Windows.Forms;
using PokemonStandardLibrary.PokeDex.Gen3;

namespace COSearch
{
    public partial class AbilityComboBox : ComboBox
    {
        public AbilityComboBox()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ResetItems(Pokemon.Species species)
        {
            this.Items.Clear();
            var abilities = species.Ability;

            this.Items.Add(abilities[0]);
            if (abilities[0] != abilities[1]) this.Items.Add(abilities[1]);

            this.SelectedIndex = 0;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
