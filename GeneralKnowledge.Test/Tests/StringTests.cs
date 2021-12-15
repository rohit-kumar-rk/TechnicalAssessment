using System;
using System.Collections.Generic;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            Console.WriteLine("--------------------------------");
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found

            Dictionary<char, int> charCount = word.StringCharCount();
            foreach (var key in charCount.Keys)
            {
                Console.WriteLine($"{key} with Count {charCount[key]}");
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b

            if (a.Length ==b.Length)
            {
                var aCharCount= StringCharCount(a);
                var bCharCount = StringCharCount(b);

                foreach (var key in aCharCount.Keys)
                {
                    if (!bCharCount.ContainsKey(key)) return false;
                    if (aCharCount[key] != bCharCount[key]) return false;
                }

                return true;
            }

            return false;
        }

        public static Dictionary<char, int> StringCharCount(this string word)
        {
            var charCount = new Dictionary<char, int>();
            foreach (var chr in word)
            {
                if (!charCount.ContainsKey(chr))
                {
                    charCount.Add(chr, 0);
                }
                ++charCount[chr];
            }

            return charCount;
        }
    }
}
