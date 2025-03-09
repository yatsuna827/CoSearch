using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSearch.Forms
{
    public partial class ReseedForm : Form
    {
        public static uint? ShowDialog(uint currentSeed)
        {
            var dialog = new ReseedForm(currentSeed);
            var result = dialog.ShowDialog();
            
            return result == DialogResult.OK ? dialog._result : (uint?)null;
        }

        private ReseedForm(uint currentSeed)
        {
            InitializeComponent();

            currentSeedBox.Text = $"{currentSeed:X8}";
            newSeedBox.Text = $"{currentSeed:X8}";
        }

        private uint _result;
        private void OnClick__OkButton(object sender, EventArgs e)
        {
            _result = newSeedBox.Seed;

            DialogResult = DialogResult.OK;
            Close();
        }

        

    }
}
