using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPRNG.LCG32;
using PokemonPRNG.LCG32.GCLCG;

namespace COSearch
{
    internal class WithOffset<T>: IGeneratable<RNGResult<T>>
    {
        private readonly uint _offset;
        private readonly IGeneratable<RNGResult<T>> _generator;

        public WithOffset(IGeneratable<RNGResult<T>> generator, uint offset)
        {
            _offset = offset;
            _generator = generator;
        }

        public RNGResult<T> Generate(uint seed)
        {
            var result = _generator.Generate(seed.NextSeed(_offset));
            return new RNGResult<T>(result.Content, seed, result.TailSeed);
        }

    }

    public static class WithOffsetExtention
    {
        public static IGeneratable<RNGResult<T>> WithOffset<T>(this IGeneratable<RNGResult<T>> generator, uint offset)
            => new WithOffset<T>(generator, offset);
    }
}
