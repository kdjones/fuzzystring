using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    { 
        /// <summary>
        /// Calculate the minimum number of single-character edits needed to change the source into the target,
        /// allowing insertions, deletions, and substitutions.
        /// <br/><br/>
        /// Time complexity: at least O(n^2), where n is the length of each string
        /// Accordingly, this algorithm is most efficient when at least one of the strings is very short
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>The number of edits required to transform the source into the target. This is at most the length of the longest string, and at least the difference in length between the two strings</returns>
        public static int LevenshteinDistance(this string source, string target)
        {
            if (source.Length == 0) { return target.Length; }
            if (target.Length == 0) { return source.Length; }

            int distance = 0;

            if (source[source.Length - 1] == target[target.Length - 1]) { distance = 0; }
            else { distance = 1; }

            var sourceInitial = source.Substring(0, source.Length - 1);
            var targetInitial = target.Substring(0, target.Length - 1);
            return Math.Min(Math.Min(LevenshteinDistance(sourceInitial, target) + 1,
                                     LevenshteinDistance(source, targetInitial)) + 1,
                                     LevenshteinDistance(sourceInitial, targetInitial) + distance);
        }

        /// <summary>
        /// Calculate the minimum number of single-character edits needed to change the source into the target,
        /// allowing insertions, deletions, and substitutions.
        /// <br/><br/>
        /// Time complexity: at least O(n^2), where n is the length of each string
        /// Accordingly, this algorithm is most efficient when at least one of the strings is very short
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>The Levenshtein distance, normalized so that the lower bound is always zero, rather than the difference in length between the two strings</returns>
        public static double NormalizedLevenshteinDistance(this string source, string target)
        {
            int unnormalizedLevenshteinDistance = source.LevenshteinDistance(target);

            return unnormalizedLevenshteinDistance - source.LevenshteinDistanceLowerBounds(target);
        }

        /// <summary>
        /// The upper bounds is either the length of the longer string, or the Hamming distance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int LevenshteinDistanceUpperBounds(this string source, string target)
        {
            // If the two strings are the same length then the Hamming Distance is the upper bounds of the Levenshtien Distance.
            if (source.Length == target.Length) { return source.HammingDistance(target); }

            // Otherwise, the upper bound is the length of the longer string.
            else if (source.Length > target.Length) { return source.Length; }
            else if (target.Length > source.Length) { return target.Length; }

            return 9999;
        }

        /// <summary>
        /// The lower bounds is the difference in length between the two strings
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int LevenshteinDistanceLowerBounds(this string source, string target)
        {
            // If the two strings are different lengths then the lower bounds is the difference in length.
            return Math.Abs(source.Length - target.Length);
        }

    }
}
