using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonStandardLibrary.CommonExtension;
using PokemonCoRNGLibrary;

namespace COSearch
{
    class TargetSearchBinder
    {
        private readonly GCIndividual _result;

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

        public bool IsShiny { get; }


        public TargetSearchBinder(uint seed, GCIndividual result, uint tsv)
        {
            (Seed, _result) = ($"{seed:X8}", result);
            IsShiny = _result.GetShinyType(tsv).IsShiny();
        }
    }


    class ListViewBinder
    {
        private readonly GCIndividual _result;

        [DataGridViewRowHeader(64, "F")]
        public uint Frame { get; }

        [DataGridViewRowHeader(64, "消費数")]
        public uint Index { get; }

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

        public bool IsShiny { get; }


        public ListViewBinder(uint index, uint seed, GCIndividual result, uint tsv)
        {
            Index = index;
            Frame = 0;
            (Seed, _result) = ($"{seed:X8}", result);
            IsShiny = _result.GetShinyType(tsv).IsShiny();
        }

        public ListViewBinder(uint frame, uint index, uint seed, GCIndividual result, uint tsv)
        {
            Index = index;
            Frame = frame;
            (Seed, _result) = ($"{seed:X8}", result);
            IsShiny = _result.GetShinyType(tsv).IsShiny();
        }
    }
}
