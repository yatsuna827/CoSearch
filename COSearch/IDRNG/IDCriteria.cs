using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonCoRNGLibrary;

namespace COSearch.IDRNG
{
    class IDCriteria : Criteria<CoStarterResult>
    {
        public override bool Check(CoStarterResult result) => true;
    }
}
