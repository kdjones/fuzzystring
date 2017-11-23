using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double RatcliffObershelpSimilarity(this string source, string target)
        {
            var matchs = GetMatchQueue(source, target);
            return 2.0 * matchs.Select(match => match.Length).Sum() / (source.Length + target.Length);
        }

        private static List<string> GetMatchQueue(string source, string target)
        {
            List<string> list = new List<string>();
            var match = FrontMaxMatch(source, target);
            if (match.Length > 0)
            {
                var frontSource = source.Substring(0, source.IndexOf(match));
                var frontTarget = target.Substring(0, target.IndexOf(match));
                var frontQueue = GetMatchQueue(frontSource, frontTarget);

                var endSource = source.Substring(source.IndexOf(match) + match.Length);
                var endTarget = target.Substring(target.IndexOf(match) + match.Length);
                var endQueue = GetMatchQueue(endSource, endTarget);

                list.Add(match);
                list.AddRange(frontQueue);
                list.AddRange(endQueue);
                return list;
            }
            else
            {
                return list;
            }
        }

        private static string FrontMaxMatch(string a, string b)
        {
            var index = 0;
            var length = 0;

            for (int i = 0; i < a.Length; i++)
            {
                Enumerable.Range(1, a.Length - i)
                .ToList()
                .ForEach
                (len =>
                {
                    if (len > length && b.Contains(a.Substring(i, len)))
                    {
                        index = i;
                        length = len;
                    }
                });
            }

            return a.Substring(index, length);
        }
    }
}