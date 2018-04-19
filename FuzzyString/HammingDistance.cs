namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static int HammingDistance(this string source, string target)
        {
            int distance = 0;

            if (source.Length != target.Length) return 99999;

            for (int i = 0; i < source.Length; i++)
            {
                if (!source[i].Equals(target[i]))
                {
                    distance++;
                }
            }

            return distance;
        }
    }
}
