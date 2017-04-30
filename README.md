# fuzzystring
Approximate String Comparision in C#

*Originally Hosted on Codplex*
http://fuzzystring.codeplex.com

*Project Description*

FuzzyString is a library developed for use in my day job for reconciling naming conventions between different models of the electric grid. I have stripped off the power system specific code and put together what can effectively be used as a string extension for determining approximate equality between two strings. All of the algorithms used here have been pulled from online resources, translated into C#, and compiled into this library. I found several other similar open-source implementations around but nothing for .NET/C#. Adding the *.dll to your project will give you access to this extension and the individual extensions under the hood of the ApproximatelyEquals() extension.

Algorithms included in this project:
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