using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSearch
{
    internal static class ForcedAdvancesData
    {
        private static readonly Dictionary<string, uint> _forcedAdvances = new Dictionary<string, uint>()
        {
            { "テッポウオ", 4 },
            { "ノコッチ", 4 },
            { "グライガー", 4 },
            { "オドシシ", 4 },
            { "イノムー", 4 },
            { "ニューラ", 4 },
            { "ミルタンク", 4 },
            { "アブソル", 4 },
            { "バンギラス", 15434 },
        };

        public static uint GetForcedAdvances(string name) => _forcedAdvances.ContainsKey(name) ? _forcedAdvances[name] : 0;
    }
}
