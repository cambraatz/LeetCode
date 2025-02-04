using System;
using System.Collections.Generic;

namespace LongestSub
{
    public class Substring
    {
        public string chars;
        public int length;
        public Substring(string s = "", int left=0, int right=0)
        {
            this.chars = s;
            this.length = right-left;
        }
    }
    public class Solution
    {
        public Substring LengthOfLongestSubstring(string s)
        {
            Substring sub = new Substring();
            HashSet<char> chars = new HashSet<char>();
            int maxLength = 0;
            int left = 0;
            int right = 0;

            while (right < s.Length)
            {
                // remove all characters up to s[right] duplicate...
                while (chars.Contains(s[right]))
                {
                    chars.Remove(s[left]);
                    left++;
                }

                // add next letter to hash set...
                chars.Add(s[right]);
                right += 1;

                // update max length...
                if ((right-left)+1 > maxLength)
                {
                    maxLength = (right-left)+1;
                    sub.chars = s[left..right];
                    sub.length = sub.chars.Length;
                }
            }

            return sub;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //string s = "pwwkew";
            string s = "abcabcdbb";

            Solution solution = new Solution();
            Substring result = solution.LengthOfLongestSubstring(s);

            if (result != null)
            {
                Console.WriteLine($"The longest substring ({result.chars}) is {result.length} characters long.");
            } 
            else 
            {
                Console.WriteLine("No solution found.");
            }
        }
    }
}