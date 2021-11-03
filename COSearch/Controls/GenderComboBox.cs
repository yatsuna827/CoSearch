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

namespace COSearch
{
    public partial class GenderComboBox : ComboBox
    {
        public GenderComboBox()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Size = new Size(52, 20);
        }
        public Gender SelectedGender { get => Text == "♂" ? Gender.Male : (Text == "♀" ? Gender.Female : Gender.Genderless); }
        public void ResetItems(GenderRatio ratio)
        {
            this.Items.Clear();
            switch (ratio)
            {
                case GenderRatio.Genderless:
                    this.Items.Add("-");
                    break;
                case GenderRatio.MaleOnly:
                    this.Items.Add("♂");
                    break;
                case GenderRatio.FemaleOnly:
                    this.Items.Add("♀");
                    break;
                default:
                    this.Items.Add("♂");
                    this.Items.Add("♀");
                    break;
            }
            this.SelectedIndex = 0;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
