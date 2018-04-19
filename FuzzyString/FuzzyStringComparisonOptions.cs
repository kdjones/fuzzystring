using System;

namespace FuzzyString
{
    [Flags]
    public enum FuzzyStringComparisonOptions
    {
        CaseSensitive = 0x0001,

        UseHammingDistance = 0x0002,

        UseJaccardDistance = 0x0004,

        UseJaroDistance = 0x0008,

        UseJaroWinklerDistance = 0x0010,

        UseLevenshteinDistance = 0x0020,

        UseLongestCommonSubsequence = 0x0040,

        UseLongestCommonSubstring = 0x0080,

        UseNormalizedLevenshteinDistance = 0x0100,

        UseOverlapCoefficient = 0x0200,

        UseRatcliffObershelpSimilarity = 0x0400,

        UseSorensenDiceDistance = 0x0800,

        UseTanimotoCoefficient = 0x1000,
    }
}
