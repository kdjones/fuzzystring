# fuzzystring
Approximate String Comparision in C#

*Originally Hosted on Codplex*
http://fuzzystring.codeplex.com

## Project Description

FuzzyString is a library developed for use in my day job for reconciling naming conventions between different models of the electric grid. I have stripped off the power system specific code and put together what can effectively be used as a string extension for determining approximate equality between two strings. All of the algorithms used here have been pulled from online resources, translated into C#, and compiled into this library. I found several other similar open-source implementations around but nothing for .NET/C#. Adding the *.dll to your project will give you access to this extension and the individual extensions under the hood of the ApproximatelyEquals() extension.

## Algorithms included in this project

* Hamming Distance|http://en.wikipedia.org/wiki/Hamming_distance
* Jaccard Distance|http://en.wikipedia.org/wiki/Jaccard_index
* Jaro Distance|http://en.wikipedia.org/wiki/Jaro_distance
* Jaro-Winkler Distance|http://en.wikipedia.org/wiki/Jaro_distance
* Levenshtein Distance|http://en.wikipedia.org/wiki/Levenshtein_distance
* Longest Common Subsequence|http://en.wikipedia.org/wiki/Longest_common_subsequence_problem
* Longest Common Substring|http://en.wikipedia.org/wiki/Longest_common_substring
* Overlap Coefficient|http://en.wikipedia.org/wiki/Overlap_coefficient
* Ratcliff-Obershelp Similarity|http://www.morfoedro.it/doc.php?n=223&lang=en
* Sorensen-Dice Distance|http://en.wikipedia.org/wiki/S%C3%B8rensen%E2%80%93Dice_coefficient
* Tanimoto Coefficient|http://en.wikipedia.org/wiki/Tanimoto_coefficient#Tanimoto_coefficient_.28extended_Jaccard_coefficient.29

## Approximate String Comparision
> Note: This sample is taken from the [legacy documentation] on CodePlex.

While all of the algorithms are exposed and can be used and can provide their raw results, they have been conveniently combined in a way that they can selectively be used to judge the approximate equality of two strings. This is done through the `ApproximatelyEquals` extension and by setting the desired `FuzzyStringComparisonOptions` and `FuzzyStringComparisonTolerance`.

For two strings that are desired to be compared approximately, a boolean response of equality can be garnered in the following way:


```csharp
string source = "kevin";
string target = "kevyn";

List<FuzzyStringComparisonOptions> options = new List<FuzzyStringComparisonOptions>();

// Choose which algorithms should weigh in for the comparison
options.Add(FuzzyStringComparisonOptions.UseOverlapCoefficient);
options.Add(FuzzyStringComparisonOptions.UseLongestCommonSubsequence);
options.Add(FuzzyStringComparisonOptions.UseLongestCommonSubstring);

// Choose the relative strength of the comparison - is it almost exactly equal? or is it just close?
FuzzyStringComparisonTolerance tolerance = FuzzyStringComparisonTolerance.Strong;

// Get a boolean determination of approximate equality
bool result = source.ApproximatelyEquals(target, options, tolerance);
```

[legacy documentation]: http://fuzzystring.codeplex.com/wikipage?title=Using%20the%20ApproximatelyEquals%28%29%20Extension&referringTitle=Documentation

