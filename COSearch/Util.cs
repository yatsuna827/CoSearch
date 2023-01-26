using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch
{
    internal static class Util
    {
        public static uint GetValueDec(NumericUpDown numericUpDown) { return (uint)(numericUpDown?.Value ?? 0); }
        public static uint GetValueHex(TextBox textBox) { return Convert.ToUInt32(textBox.Text, 16); }

        public static string RegaxReplace(this string arg1, string pattern, string replacement)
        {
            return Regex.Replace(arg1, pattern, replacement);
        }

        public static void TextBox_SelectText(object sender, EventArgs e)
            => (sender as TextBox).SelectAll();

        public static void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

    }
}
