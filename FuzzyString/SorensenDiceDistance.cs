using System;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float SorensenDiceDistance(this string source, string target)
        {
            return 1 - source.SorensenDiceIndex(target);
        }

        public static float SorensenDiceIndex(this string source, string target)
        {
            return 2 * Convert.ToSingle(source.Intersect(target).Count()) / Convert.ToSingle(source.Length + target.Length);
        }
    }
}
