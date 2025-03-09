using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;
using PokemonStandardLibrary.CommonExtension;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.Criteria;
using PokemonCoRNGLibrary.ProvidedData;

using static COSearch.Util;

namespace COSearch
{
    public partial class SearchGapsForm : Form
    {
        public SearchGapsForm(ProvidedCoDarkPokemonData pokemon, uint currentSeed, uint targetSeed, uint forcedAdvances = 0)
        {
            InitializeComponent();

            _darkPokemon = pokemon;

            _currentSeed = currentSeed;
            _targetSeed = targetSeed;

            this.Text = $"ズレ検索 - {pokemon.Slot.Species.Name}";
            this.currentSeedBox.Text = $"{currentSeed:X8}";
            this.targetSeedBox.Text = $"{targetSeed:X8}";
            forcedAdvancesBox.Value = forcedAdvances;

            _wrapper = new DataGridViewWrapper<SearchGapsFormResultBinder>(dataGridView1);
        }

        private readonly DataGridViewWrapper<SearchGapsFormResultBinder> _wrapper;

        private readonly ProvidedCoDarkPokemonData _darkPokemon;

        private uint _currentSeed;
        private readonly uint _targetSeed;

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

        public void SetValue(uint currentSeed)
        {
            _currentSeed = currentSeed;
            currentSeedBox.Text = $"{currentSeed:X8}";
        }

        private ICriteria<GCIndividual> BuildCriteria()
        {
            var builder = new List<ICriteria<GCIndividual>>();
            var targetStats = new uint[]
            {
                checkStatH.Checked ? GetValueDec(statBoxH) : 0,
                checkStatA.Checked ? GetValueDec(statBoxA) : 0,
                checkStatB.Checked ? GetValueDec(statBoxB) : 0,
                checkStatC.Checked ? GetValueDec(statBoxC) : 0,
                checkStatD.Checked ? GetValueDec(statBoxD) : 0,
                checkStatS.Checked ? GetValueDec(statBoxS) : 0,
            };
            builder.Add(new StatsCriteria(targetStats));

            return Criteria.AND(builder.ToArray());
        }

        private void Click__CalcButton(object sender, EventArgs e)
        {
            var currentSeed = _currentSeed;
            var forcedAdvances = (uint)forcedAdvancesBox.Value;

            var target = _targetSeed.GetIndex(currentSeed);

            var range = (uint)maxFrameBox.Value;
            var generator = _darkPokemon.GetGenerator().WithOffset(forcedAdvances);

            var criteria = BuildCriteria();

            var results = _targetSeed.Surround(range)
                .Select(generator.Generate)
                .Where(_ => criteria.CheckConditions(_.Content))
                .Select((res) => new SearchGapsFormResultBinder((int)res.HeadSeed.GetIndex(currentSeed), (int)(res.HeadSeed.GetIndex(_targetSeed)), res))
                .ToArray();

            _wrapper.SetData(results);
        }

        private void OnValidated__StatBoxH(object sender, EventArgs e)
        {
            if (statBoxH.Text == "")
            {
                statBoxH.Value = 0;
                statBoxH.Text = "0";
            }
            checkStatH.Checked = statBoxH.Value > 0;
        }

        private void OnValidated__StatBoxA(object sender, EventArgs e)
        {
            if (statBoxA.Text == "")
            {
                statBoxA.Value = 0;
                statBoxA.Text = "0";
            }
            checkStatA.Checked = statBoxA.Value > 0;
        }

        private void OnValidated__StatBoxB(object sender, EventArgs e)
        {
            if (statBoxB.Text == "")
            {
                statBoxB.Value = 0;
                statBoxB.Text = "0";
            }
            checkStatB.Checked = statBoxB.Value > 0;
        }

        private void OnValidated__StatBoxC(object sender, EventArgs e)
        {
            if (statBoxC.Text == "")
            {
                statBoxC.Value = 0;
                statBoxC.Text = "0";
            }
            checkStatC.Checked = statBoxC.Value > 0;
        }

        private void OnValidated__StatBoxD(object sender, EventArgs e)
        {
            if (statBoxD.Text == "")
            {
                statBoxD.Value = 0;
                statBoxD.Text = "0";
            }
            checkStatD.Checked = statBoxD.Value > 0;
        }

        private void OnValidated__StatBoxS(object sender, EventArgs e)
        {
            if (statBoxS.Text == "")
            {
                statBoxS.Value = 0;
                statBoxS.Text = "0";
            }
            checkStatS.Checked = statBoxS.Value > 0;
        }
    }

    class SearchGapsFormResultBinder
    {
        private readonly GCIndividual _result;


        [DataGridViewRowHeader(88, "消費数")]
        public uint Frames { get; }

        [DataGridViewRowHeader(88, "ズレ")]
        public int Gaps { get; }

        [DataGridViewRowHeader(88, "seed")]
        public string Seed { get; }

        [DataGridViewRowHeader(88, "性格値")]
        public string PID { get => $"{_result.PID:X8}"; }

        [DataGridViewRowHeader(64, "性格")]
        public string Nature { get => _result.Nature.ToJapanese(); }

        [DataGridViewRowHeader(40, "H")]
        public uint IVs_H { get => _result.IVs[0]; }
        [DataGridViewRowHeader(40, "A")]
        public uint IVs_A { get => _result.IVs[1]; }
        [DataGridViewRowHeader(40, "B")]
        public uint IVs_B { get => _result.IVs[2]; }
        [DataGridViewRowHeader(40, "C")]
        public uint IVs_C { get => _result.IVs[3]; }
        [DataGridViewRowHeader(40, "D")]
        public uint IVs_D { get => _result.IVs[4]; }
        [DataGridViewRowHeader(40, "S")]
        public uint IVs_S { get => _result.IVs[5]; }

        [DataGridViewRowHeader(100, "特性", true)]
        public string Ability { get => _result.Ability; }

        [DataGridViewRowHeader(100, "XD特性", true)]
        public string XDAbility { get => _result.GCAbility; }

        [DataGridViewRowHeader(66, "性別", false, "ＭＳ ゴシック")]
        public string Gender { get => _result.Gender.ToSymbol(); }

        [DataGridViewRowHeader(40, "H")]
        public uint Stats_H { get => _result.Stats[0]; }
        [DataGridViewRowHeader(40, "A")]
        public uint Stats_A { get => _result.Stats[1]; }
        [DataGridViewRowHeader(40, "B")]
        public uint Stats_B { get => _result.Stats[2]; }
        [DataGridViewRowHeader(40, "C")]
        public uint Stats_C { get => _result.Stats[3]; }
        [DataGridViewRowHeader(40, "D")]
        public uint Stats_D { get => _result.Stats[4]; }
        [DataGridViewRowHeader(40, "S")]
        public uint Stats_S { get => _result.Stats[5]; }

        [DataGridViewRowHeader(60, "めざパ")]
        public string HiddenPower { get => $"{_result.HiddenPowerType.ToKanji()}{_result.HiddenPower}"; }

        public SearchGapsFormResultBinder(int frames, int gaps, RNGResult<GCIndividual> result)
        {
            Frames = (uint)frames;
            Gaps = gaps;
            (Seed, _result) = ($"{result.HeadSeed:X8}", result.Content);
        }
    }

}
