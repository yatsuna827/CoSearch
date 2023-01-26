using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace COSearch
{
    public partial class EditorForm : Form
    {
        public EditorForm(string defaultValue)
        {
            InitializeComponent();

            azukiControl1.Text = defaultValue;

			var back = Color.White;
			azukiControl1.BackColor = back;
			azukiControl1.ColorScheme.SetColor(CharClass.Keyword, Color.Blue, back);
			azukiControl1.ColorScheme.SetColor(CharClass.Keyword2, Color.DeepSkyBlue, back);
			azukiControl1.ColorScheme.SetColor(CharClass.Number, Color.YellowGreen, back);

			var keywordHighlighter = new KeywordHighlighter();
			keywordHighlighter.AddKeywordSet(Keywords.OjbectFields, CharClass.Keyword);
			keywordHighlighter.AddRegex("[0-9a-fA-F]{1,8}", CharClass.Number);
			keywordHighlighter.AddKeywordSet(new[]{ "_" }, CharClass.Number);
			keywordHighlighter.AddKeywordSet(Keywords.Terms, CharClass.Keyword2);

			azukiControl1.Highlighter = keywordHighlighter;
			azukiControl1.AutoIndentHook = AutoIndentHooks.CHook;

			this.FormClosing += (s, e) =>
			{
				e.Cancel = true;
				this.Visible = false;
			};
		}

		public string Script { get => azukiControl1.Text ?? ""; }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.IO.File.WriteAllText("./criteria.txt", this.azukiControl1.Text);
			toolStripStatusLabel1.Text = $"保存しました {DateTime.Now}";
        }
    }

    public static class Keywords
    {
		public static string[] OjbectFields = new string[]
		{
			"id", "tid", "shiny", "square", "star", "umbreon", "espeon", "ivs", "nature", "hp", "power", "type"
		}.OrderBy(_ => _).ToArray();
		public static string[] Terms = new string[]
		{
			"Hardy","Lonely","Brave","Adamant","Naughty","Bold","Docile","Relaxed","Impish","Lax","Timid","Hasty","Serious","Jolly","Naive","Modest","Mild","Quiet","Bashful","Rash","Calm","Gentle","Sassy","Careful","Quirky",
			"hardy","lonely","brave","adamant","naughty","bold","docile","relaxed","impish","lax","timid","hasty","serious","jolly","naive","modest","mild","quiet","bashful","rash","calm","gentle","sassy","careful","quirky",
			"HARDY","LONELY","BRAVE","ADAMANT","NAUGHTY","BOLD","DOCILE","RELAXED","IMPISH","LAX","TIMID","HASTY","SERIOUS","JOLLY","NAIVE","MODEST","MILD","QUIET","BASHFUL","RASH","CALM","GENTLE","SASSY","CAREFUL","QUIRKY",
			"がんばりや","さみしがり","ゆうかん","いじっぱり","やんちゃ","ずぶとい","すなお","のんき","わんぱく","のうてんき","おくびょう","せっかち","まじめ","ようき","むじゃき","ひかえめ","おっとり","れいせい","てれや","うっかりや","おだやか","おとなしい","なまいき","しんちょう","きまぐれ",

			"Fire","Water","Grass","Electric","Ice","Fighting","Poison","Ground","Flying","Psychic","Bug","Rock","Ghost","Dragon","Dark","Steel",
			"FIRE","WATER","GRASS","ELECTRIC","ICE","FIGHTING","POISON","GROUND","FLYING","PSYCHIC","BUG","ROCK","GHOST","DRAGON","DARK","STEEL",
			"fire","water","grass","electric","ice","fighting","poison","ground","flying","psychic","bug","rock","ghost","dragon","dark","steel",
			"ほのお","みず","くさ","でんき","こおり","かくとう","どく","じめん","ひこう","エスパー","むし","いわ","ゴースト","ドラゴン","あく","はがね",
			"炎","水","草","電","氷","闘","毒","地","飛","超","虫","岩","霊","竜","龍","悪","鋼",
		}.OrderBy(_ => _).ToArray();
	}
}
