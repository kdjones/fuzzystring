using System;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double JaccardDistance(this string source, string target)
        {
            return 1 - source.JaccardIndex(target);
        }

        public static double JaccardIndex(this string source, string target)
        {
            return Convert.ToDouble(source.Intersect(target).Count()) / Convert.ToDouble(source.Union(target).Count());
        }
    }
}