using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch
{
    public partial class NatureComboBox : ComboBox
    {
        private static readonly Nature[] sortedNatureList;
        static NatureComboBox()
        {
            var natures = Enumerable.Range(0, 25).Select(_ => (Nature)_).ToList();
            natures.Sort((Nature a, Nature b) => string.Compare(a.ToJapanese(), b.ToJapanese()));
            sortedNatureList = natures.ToArray();
        }

        public NatureComboBox()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void Initialize()
        {
            this.Items.Clear();
            this.Items.AddRange(sortedNatureList.Select(_ => _.ToJapanese()).ToArray());
            this.SelectedIndex = 0;
        }
        public Nature SelectedNature { get => 0 <= SelectedIndex && SelectedIndex < 25 ? sortedNatureList[SelectedIndex] : Nature.other; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
