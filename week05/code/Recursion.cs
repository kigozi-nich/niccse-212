using System;
using System.Collections.Generic;

namespace Week5Code
{
    public class Recursion
    {
        // Problem 1: Sum of Squares Recursive
        public static int SumSquaresRecursive(int n)
        {
            if (n <= 0) return 0;
            return n * n + SumSquaresRecursive(n - 1);
        }

        // Problem 2: Permutations Choose
        public static List<string> PermutationsChoose(string letters, int size)
        {
            List<string> results = new List<string>();
            GeneratePermutations(letters, size, "", results);
            return results;
        }

        private static void GeneratePermutations(string letters, int size, string current, List<string> results)
        {
            if (current.Length == size)
            {
                results.Add(current);
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
                GeneratePermutations(remaining, size, current + letters[i], results);
            }
        }

        // Problem 3: Climbing Stairs
        public static int CountWaysToClimb(int s, Dictionary<int, int>? memo = null)
        {
            if (memo == null) memo = new Dictionary<int, int>();

            if (s < 0) return 0;
            if (s == 0) return 1;
            if (s == 1) return 1;
            if (s == 2) return 2;
            if (s == 3) return 4;

            if (memo.ContainsKey(s)) return memo[s];

            int result = CountWaysToClimb(s - 1, memo) +
                         CountWaysToClimb(s - 2, memo) +
                         CountWaysToClimb(s - 3, memo);

            memo[s] = result;
            return result;
        }

        // Problem 4: Wildcard Binary Patterns
        public static List<string> GenerateBinaryPatterns(string pattern)
        {
            List<string> results = new List<string>();
            GeneratePatterns(pattern, 0, "", results);
            return results;
        }

        private static void GeneratePatterns(string pattern, int index, string current, List<string> results)
        {
            if (index == pattern.Length)
            {
                results.Add(current);
                return;
            }

            if (pattern[index] == '*')
            {
                GeneratePatterns(pattern, index + 1, current + '0', results);
                GeneratePatterns(pattern, index + 1, current + '1', results);
            }
            else
            {
                GeneratePatterns(pattern, index + 1, current + pattern[index], results);
            }
        }
    }
}
