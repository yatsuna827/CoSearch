using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonCoRNGLibrary;
using PokemonStandardLibrary.CommonExtension;

namespace COSearch
{
    class IndividualListItem
    {
        public int Index { get; set; }
        public uint Frame { get; set; }

        public bool IsShiny => indiv.Shiny != PokemonStandardLibrary.ShinyType.NotShiny; // どうしようわね
        private uint seed;
        public string Seed { get { return $"{seed:X8}"; } }
        public string PID { get { return $"{indiv.PID:X8}"; } }
        public string Nature { get { return indiv.Nature.ToJapanese(); } }
        public string Gender { get { return indiv.Gender.ToSymbol(); } }
        public string Ability { get { return indiv.Ability; } }
        public string GCAbility { get { return indiv.GCAbility; } }
        public uint IVsH { get { return indiv.IVs[0]; } }
        public uint IVsA { get { return indiv.IVs[1]; } }
        public uint IVsB { get { return indiv.IVs[2]; } }
        public uint IVsC { get { return indiv.IVs[3]; } }
        public uint IVsD { get { return indiv.IVs[4]; } }
        public uint IVsS { get { return indiv.IVs[5]; } }

        public uint StatsH { get { return indiv.Stats[0]; } }
        public uint StatsA { get { return indiv.Stats[1]; } }
        public uint StatsB { get { return indiv.Stats[2]; } }
        public uint StatsC { get { return indiv.Stats[3]; } }
        public uint StatsD { get { return indiv.Stats[4]; } }
        public uint StatsS { get { return indiv.Stats[5]; } }


        private GCIndividual indiv;

        public IndividualListItem(int idx, uint seed, GCIndividual indiv, uint TSV)
        {
            Index = idx;
            this.seed = seed;
            this.indiv = indiv.SetShinyType(TSV) as GCIndividual;
        }
        public IndividualListItem(int idx, uint frame, uint seed, GCIndividual indiv, uint TSV)
        {
            Index = idx;
            Frame = frame;
            this.seed = seed;
            this.indiv = indiv.SetShinyType(TSV) as GCIndividual;
        }
    }
}
