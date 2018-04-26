using System;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float JaccardDistance(this string source, string target)
        {
            return 1 - source.JaccardIndex(target);
        }

        public static float JaccardIndex(this string source, string target)
        {
            return Convert.ToSingle(source.Intersect(target).Count()) / Convert.ToSingle(source.Union(target).Count());
        }
    }
}