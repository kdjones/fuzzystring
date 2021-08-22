using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    { 
        public static bool ApproximatelyEquals(this string source, string target,  FuzzyStringComparisonTolerance tolerance, params FuzzyStringComparisonOptions[] options)
        {
            double score = this.MatchingScore(target, tolerance, options)

            if (score == 0)
            {
                return false;
            }

            if (tolerance == FuzzyStringComparisonTolerance.Strong)
            {
                if (score < 0.25)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tolerance == FuzzyStringComparisonTolerance.Normal)
            {
                if (score < 0.5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tolerance == FuzzyStringComparisonTolerance.Weak)
            {
                if (score < 0.75)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tolerance == FuzzyStringComparisonTolerance.Manual)
            {
                if (score > 0.6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
