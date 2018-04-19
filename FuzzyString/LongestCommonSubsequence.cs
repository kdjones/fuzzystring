using System;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static string LongestCommonSubsequence(this string source, string target)
        {
            return BacktrackTable.Create(source, target).Backtrack();
        }

        private struct BacktrackTable
        {
            private readonly int[,] C;
            private readonly string source;
            private readonly string target;

            private BacktrackTable(int[,] C, string source, string target)
            {
                this.C = C;
                this.source = source;
                this.target = target;
            }

            public static BacktrackTable Create(string source, string target)
            {
                int[,] C = new int[source.Length + 1, target.Length + 1];

                for (int i = 0; i < source.Length + 1; i++) { C[i, 0] = 0; }
                for (int j = 0; j < target.Length + 1; j++) { C[0, j] = 0; }

                for (int i = 1; i < source.Length + 1; i++)
                {
                    for (int j = 1; j < target.Length + 1; j++)
                    {
                        if (source[i - 1].Equals(target[j - 1]))
                        {
                            C[i, j] = C[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            C[i, j] = Math.Max(C[i, j - 1], C[i - 1, j]);
                        }
                    }
                }

                return new BacktrackTable(C, source, target);
            }

            public string Backtrack()
            {
                return Backtrack(source.Length, target.Length);
            }

            private string Backtrack( int i, int j)
            {
                if (i == 0 || j == 0)
                {
                    return "";
                }

                if (source[i - 1].Equals(target[j - 1]))
                {
                    return Backtrack(i - 1, j - 1) + source[i - 1];
                }

                if (C[i, j - 1] > C[i - 1, j])
                {
                    return Backtrack(i, j - 1);
                }

                return Backtrack(i - 1, j);
            }
        }
    }
}
