using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonCoRNGLibrary;
using PokemonPRNG.LCG32.GCLCG;

namespace COSearch
{
    public class AdvanceResult
    {
        public uint seed;
        public string code;
        private readonly Dictionary<char, string> rules = new Dictionary<char, string>()
        {
            {'0',"シ最"},
            {'1',"シ強"},
            {'2',"シ普"},
            {'3',"シ弱"},
            {'4',"ダ最"},
            {'5',"ダ強"},
            {'6',"ダ普"},
            {'7',"ダ弱"},
        };
        public string GetProcedure() => string.Join("→", code.Select(_ => rules[_]));
    }
    class COAdvanceCalc
    {
        public static (int Count, uint Seed) AdvanceRoughly(uint currentSeed, uint targetStep, uint range)
        {
            var count = 0;
            var seed = currentSeed;
            while (targetStep - seed.GetIndex(currentSeed) > range)
            {
                seed = BattleNow.SingleBattle.Ultimate.AdvanceSeed(seed);
                count++;
            }

            return (count, seed);
        }
        public static IReadOnlyList<AdvanceResult> Advance(uint currentSeed, uint targetSeed, uint range)
        {
            var rules = new RentalPartyRank[]
            {
                BattleNow.SingleBattle.Ultimate,
                BattleNow.SingleBattle.Hard,
                BattleNow.SingleBattle.Normal,
                BattleNow.SingleBattle.Easy,
                BattleNow.DoubleBattle.Ultimate,
                BattleNow.DoubleBattle.Hard,
                BattleNow.DoubleBattle.Normal,
                BattleNow.DoubleBattle.Easy
            };

            var res = new List<AdvanceResult>();
            var queue = new Queue<(uint seed, string code)>();
            var wantedStep = targetSeed.GetIndex(currentSeed);
            var hasAppeared = new bool[wantedStep + 1];

            queue.Enqueue((currentSeed, ""));
            while (queue.Count > 0)
            {
                var (seed, code) = queue.Dequeue();
                for (int i = 0; i < 8; i++)
                {
                    var s = rules[i].AdvanceSeed(seed);
                    var idx = s.GetIndex(currentSeed);
                    if (idx > wantedStep || hasAppeared[idx]) continue;

                    hasAppeared[idx] = true;
                    var nextCode = code + i.ToString();
                    if (wantedStep - idx <= range) res.Add(new AdvanceResult() { seed = s, code = nextCode });

                    queue.Enqueue((s, nextCode));
                }
            }

            res.Sort((a, b) => (int)(b.seed.GetIndex(currentSeed) - a.seed.GetIndex(currentSeed)));

            return res;
        }
    }
}
