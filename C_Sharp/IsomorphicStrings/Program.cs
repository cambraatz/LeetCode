using System;
using System.Collections.Generic;

namespace IsomorphicStrings
{
    public class Solution
    {
        public bool isIsomorphic(string s, string t)
        {
            // initialize an empty dictionary...
            Dictionary<char, char> chars = new Dictionary<char, char>();

            // iterate through each character of strings...
            int index = 0;
            while (index < s.Length)
            {
                // if key exists, check for equality...
                if (chars.ContainsKey(s[index]))
                {
                    // if mismatch, return false...
                    if (chars[s[index]] != t[index])
                    {
                        return false;
                    }
                } else {
                    // if no key, but value exists, return false...
                    if (chars.ContainsValue(t[index]))
                    {
                        return false;
                    }

                    // add new key-value char mapping...
                    chars.Add(s[index], t[index]);
                }

                // increment index...
                index++;
            }

            return true;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "egg";
            string t = "add";

            Solution solution = new Solution();
            bool result = solution.isIsomorphic(s,t);

            Console.WriteLine(result);
        }
    }
}
