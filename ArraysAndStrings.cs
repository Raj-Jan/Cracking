using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cracking.ArraysAndStrings
{
    //  Is Unique: Implement an algorithm to determine if a string has all unique characters.
    //  What if you cannot use additional data structures?

    public class IsUnique : IExercise
    {
        public static bool Foo(string str)
        {
            if (str.Length > 128) return false;

            bool[] chars = new bool[128]; // to each character in ASCII assign a bool if that character already occured in string before;

            foreach (var c in str)
            {
                var val = (int)c; // cast character to int, becuse array is enumerated with ints

                if (chars[val]) return false; // if already occurrend return false

                chars[val] = true; // mark charater as already occured in string
            }

            return true; // when none of characters ocuured more than once
        }

        // if i cannot use chars array i may compare every character in the string with every other O(n^2) or sort string o(n log n)

        private void Test(string arg)
        {
            Console.WriteLine($"{arg}: {Foo(arg)}");
        }

        public void Main()
        {
            Test("aa");
            Test("abc");
            Test("abca");
        }
    }

    //  Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.

    public class CheckPermutation : IExercise
    {
        public static bool Foo(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            // sort strings and check one by one

            var c1 = str1.ToCharArray();
            var c2 = str2.ToCharArray();

            c1 = c1.OrderBy(x => x).ToArray();
            c2 = c2.OrderBy(x => x).ToArray();

            for (int i = 0; i < str1.Length; i++)
            {
                if (c1[i] != c2[i]) return false;
            }

            return true;
        }

        private void Test(string arg1, string arg2)
        {
            Console.WriteLine($"{arg1}, {arg2}: {Foo(arg1, arg2)}");
        }

        public void Main()
        {
            Test("ab", "ba");
            Test("aba", "baa");
            Test("abc", "bac");
            Test("abc", "bad");
        }
    }

    //  URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
    //  has sufficient space at the end to hold the additional characters, and that you are given the "true"
    //  length of the string. (Note: If implementing in Java, please use a character array so that you can
    //  perform this operation in place.) 

    public class URLify : IExercise
    {
        public static string Foo(string str)
        {
            return str.Replace(" ", "%20");
        }

        private void Test(string arg)
        {
            Console.WriteLine($"{arg}: {Foo(arg)}");
        }

        public void Main()
        {
            Test("a bc");
            Test("ac  bad");
        }
    }

    //  Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
    //  A palindrome is a word or phrase that is the same forwards and backwards.
    //  A permutation is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.

    public class PalindromePermutation : IExercise
    {
        public static bool Foo(string str)
        {
            int result = 0;
            int[] table = new int[128];

            for (int i = 0; i < str.Length; i++)
            {
                var val = (int)str[i];

                table[val]++;

                if (table[val] % 2 == 1) result++;
                else result--;
            }

            return result <= 1;
        }

        private void Test(string arg)
        {
            Console.WriteLine($"{arg}: {Foo(arg)}");
        }

        public void Main()
        {
            Test("a bc");
            Test("aa");
            Test("abacb");
        }
    }

    //  One Away: There are three types of edits that can be performed on strings: insert a character,
    //  remove a character, or replace a character.Given two strings, write a function to check if they are
    //  one edit (or zero edits) away.

    public class OneAway : IExercise
    {
        public static bool Foo(string str1, string str2)
        {
            var change = str1.Length - str2.Length; // check lenght difference

            switch (change)
            {
                case 0: // if lenghts are equal ther operation must be replace
                    {
                        int val = 0; // differene counter
                        for (int i = 0; i < str1.Length; i++)
                        {
                            if (str1[i] != str2[i])
                                if (++val > 1)
                                    return false;
                        }
                        return true;
                    }
                case -1:
                    {
                        bool ret = false;
                        for (int i = 0, j = 0; i < str1.Length; i++, j++)
                        {
                            if (str1[i] != str2[j])
                            {
                                if (ret) return false;

                                j--;
                                ret = true;
                            }
                        }
                        return true;
                    }
                case 1:
                    {
                        bool ret = false;
                        for (int i = 0, j = 0; j < str2.Length; i++, j++)
                        {
                            if (str1[i] != str2[j])
                            {
                                if (ret) return false;

                                i--;
                                ret = true;
                            }
                        }
                        return true;
                    }
            }

            return false;
        }

        private void Test(string arg1, string arg2)
        {
            Console.WriteLine($"{arg1}, {arg2}: {Foo(arg1, arg2)}");
        }

        public void Main()
        {
            Test("aa", "abc");
            Test("aa", "ab");
            Test("aa  ", "ab");
        }
    }

    //  String Compression: Implement a method to perform basic string compression using the counts
    //  of repeated characters.For example, the string aabcccccaaa would become a2blc5a3.If the
    //  "compressed" string would not become smaller than the original string, your method should return
    //  the original string. You can assume the string has only uppercase and lowercase letters (a - z). 

    [Entry]
    public class StringCompression : IExercise
    {
        public static string Foo(string str1)
        {
            string result = string.Empty;
            char current = '\0';
            int count = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                var val = str1[i];

                if (val == current)
                {
                    count++;
                }
                else
                {
                    current = val;

                    if (count > 1) result += count.ToString();

                    result += val;

                    count = 1;
                }
            }

            if (count > 1)
            {
                result += count.ToString();
            }

            return result;
        }

        private void Test(string arg1)
        {
            Console.WriteLine($"{arg1}: {Foo(arg1)}");
        }

        public void Main()
        {
            Test("aabcccccaaa");
        }
    }
}
