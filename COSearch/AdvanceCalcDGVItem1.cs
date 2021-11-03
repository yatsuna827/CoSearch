using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSearch
{
    class AdvanceCalcDGVItem1
    {
        private uint seed;
        public string Seed { get { return $"{seed:X8}"; } }
        public uint Index { get; set; }
        public uint RemainingStep { get; set; }
        public int MashCount { get; set; }
        public int ProcedureCount { get; set; }
        public string Procedure { get; set; }

        public AdvanceCalcDGVItem1(uint seed, uint idx, uint rem, int mash, int c, string pro)
        {
            this.seed = seed;
            this.Index = idx;
            this.RemainingStep = rem;
            this.MashCount = mash;
            this.ProcedureCount = c;
            this.Procedure = pro;
        }
    }
}
