using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float TanimotoCoefficient(this string source, string target)
        {
            float Na = source.Length;
            float Nb = target.Length;
            float Nc = source.Intersect(target).Count();

            return Nc / (Na + Nb - Nc);
        }
    }
}
