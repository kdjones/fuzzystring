using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
