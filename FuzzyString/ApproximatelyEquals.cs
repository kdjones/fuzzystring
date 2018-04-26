﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static bool ApproximatelyEquals(this string source, string target, FuzzyStringComparisonTolerance tolerance,
            FuzzyStringComparisonOptions options)
        {
            var comparisonResults = new List<float>();

            if (!options.HasFlag(FuzzyStringComparisonOptions.CaseSensitive))
            {
                source = source.ToLower();
                target = target.ToLower();
            }

            // Min: 0    Max: source.Length = target.Length
            if (options.HasFlag(FuzzyStringComparisonOptions.UseHammingDistance))
            {
                if (source.Length == target.Length)
                {
                    comparisonResults.Add(source.HammingDistance(target) / target.Length);
                }
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseJaccardDistance))
            {
                comparisonResults.Add(source.JaccardDistance(target));
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseJaroDistance))
            {
                comparisonResults.Add(source.JaroDistance(target));
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseJaroWinklerDistance))
            {
                comparisonResults.Add(source.JaroWinklerDistance(target));
            }

            // Min: 0    Max: LevenshteinDistanceUpperBounds - LevenshteinDistanceLowerBounds
            // Min: LevenshteinDistanceLowerBounds    Max: LevenshteinDistanceUpperBounds
            if (options.HasFlag(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance))
            {
                comparisonResults.Add(Convert.ToSingle(source.NormalizedLevenshteinDistance(target)) /
                                      Convert.ToSingle(Math.Max(source.Length, target.Length) -
                                                       source.LevenshteinDistanceLowerBounds(target)));
            }
            else if (options.HasFlag(FuzzyStringComparisonOptions.UseLevenshteinDistance))
            {
                comparisonResults.Add(Convert.ToSingle(source.LevenshteinDistance(target)) /
                                      Convert.ToSingle(source.LevenshteinDistanceUpperBounds(target)));
            }

            if (options.HasFlag(FuzzyStringComparisonOptions.UseLongestCommonSubsequence))
            {
                comparisonResults.Add(1 - Convert.ToSingle(source.LongestCommonSubsequence(target).Length /
                                                           Convert.ToDouble(Math.Min(source.Length, target.Length))));
            }

            if (options.HasFlag(FuzzyStringComparisonOptions.UseLongestCommonSubstring))
            {
                comparisonResults.Add(1 - Convert.ToSingle(source.LongestCommonSubstring(target).Length /
                                                           Convert.ToSingle(Math.Min(source.Length, target.Length))));
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseSorensenDiceDistance))
            {
                comparisonResults.Add(source.SorensenDiceDistance(target));
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseOverlapCoefficient))
            {
                comparisonResults.Add(1 - source.OverlapCoefficient(target));
            }

            // Min: 0    Max: 1
            if (options.HasFlag(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity))
            {
                comparisonResults.Add(1 - source.RatcliffObershelpSimilarity(target));
            }

            if (comparisonResults.Count == 0)
            {
                return false;
            }

            switch (tolerance)
            {
                case FuzzyStringComparisonTolerance.Strong:
                    return comparisonResults.Average() < 0.25;
                case FuzzyStringComparisonTolerance.Normal:
                    return comparisonResults.Average() < 0.5;
                case FuzzyStringComparisonTolerance.Weak:
                    return comparisonResults.Average() < 0.75;
                case FuzzyStringComparisonTolerance.Manual:
                    return comparisonResults.Average() > 0.6;
                default:
                    return false;
            }
        }
    }
}