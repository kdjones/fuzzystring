using System;

namespace FuzzyString
{
    public enum FuzzyStringComparisonOptions
    {
        UseHammingDistance,

        UseJaccardDistance,

        UseJaroDistance,

        UseJaroWinklerDistance,

        UseLevenshteinDistance,

        UseLongestCommonSubsequence,

        UseLongestCommonSubstring,

        UseNormalizedLevenshteinDistance,

        UseOverlapCoefficient,

        UseRatcliffObershelpSimilarity,

        UseSorensenDiceDistance,

        UseTanimotoCoefficient,

        CaseSensitive
    }
}
