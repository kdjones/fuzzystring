using System;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static float JaroWinklerDistance(this string source, string target)
        {
            float jaroDistance = source.JaroDistance(target);
            float commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + commonPrefixLength * 0.1f * (1 - jaroDistance);
        }

        public static float JaroWinklerDistanceWithPrefixScale(string source, string target, float p)
        {
            float prefixScale = 0.1f;

            if (p > 0.25) { prefixScale = 0.25f; } // The maximu value for distance to not exceed 1
            else if (p < 0) { prefixScale = 0; } // The Jaro Distance
            else { prefixScale = p; }

            float jaroDistance = source.JaroDistance(target);
            float commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + (commonPrefixLength * prefixScale * (1 - jaroDistance));
        }

        public static float CommonPrefixLength(string source, string target)
        {
            int maximumPrefixLength = 4;
            int commonPrefixLength = 0;

            if (source.Length <= 4 || target.Length <= 4)
            {
                maximumPrefixLength = Math.Min(source.Length, target.Length);
            }

            for (int i = 0; i < maximumPrefixLength; i++)
            {
                if (source[i].Equals(target[i])) { commonPrefixLength++; }
                else { return commonPrefixLength; }
            }

            return commonPrefixLength;
        }
    }
}
