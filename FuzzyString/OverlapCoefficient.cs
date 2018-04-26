using System;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float OverlapCoefficient(this string source, string target)
        {
            return Convert.ToSingle(source.Intersect(target).Count()) / Convert.ToSingle(Math.Min(source.Length, target.Length));
        }
    }
}
