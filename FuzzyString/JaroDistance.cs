using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float JaroDistance(this string source, string target)
        {
            int m = source.Intersect(target).Count();

            if (m == 0) { return 0; }

            string sourceTargetIntersetAsString = string.Concat(source.Intersect(target));
            string targetSourceIntersetAsString = string.Concat(target.Intersect(source));

            float t = sourceTargetIntersetAsString.LevenshteinDistance(targetSourceIntersetAsString) / 2;
            return (m / source.Length + m / target.Length + (m - t) / m) / 3;
        }
    }
}
