using System;
using System.Collections.Generic;

namespace ArraysStrings
{
    public class Solutions
    {
        // Merge (#88)...
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // initialize left, right and index pointers...
            int left = m-1;
            int right = n-1;
            int index = nums1.Length-1;

            while (index >= 0)
            {
                // case 1: valid left + right values remain...
                if (left >= 0 && right >= 0)
                {
                    if (nums1[left] > nums2[right])
                    {
                        nums1[index] = nums1[left];
                        left--;
                    } else {
                        nums1[index] = nums2[right];
                        right--;
                    }
                }
                
                // case 2: only valid left values remain...
                else if (left >= 0)
                {
                    nums1[index] = nums1[left];
                    left--;
                }

                // case 3: only valid right values remain...
                else
                {
                    nums1[index] = nums2[right];
                    right--;
                }
                index--;
            }
        }

        // RemoveElement (#27) and assoc. helpers...
        static void swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
        public int RemoveElement(int[] nums, int val)
        {
            int left = 0;
            int right = nums.Length-1;

            while (left <= right)
            {
                if (nums[left] == val)
                {
                    swap(nums, left, right);
                    right--;
                } else {
                    left++;
                }
            }

            return left;
        }

        // RemoveDuplicates (#26)...
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) { return 0; }
            int left = 0;
            int right = 1;

            while (right < nums.Length)
            {
                if (nums[left] != nums[right])
                {
                    left++;
                    nums[left] = nums[right];
                }
                right++;
            }

            return left+1;
        }
        // IntToRoman (#12)...
        public string IntToRoman(int num)
        {
            List<(int,string)> symbols = new List<(int,string)> 
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I")
            };

            string result = "";
            foreach (var (value,symbol) in symbols)
            {
                // find the largest numeral that divides the number...
                while (num >= value)
                {
                    // add symbol...
                    result += symbol;
                    // decrement value from number...
                    num -= value;
                }
            }

            return result;
        }
        // RomanToInt (#13)...
        public int RomanToInt(string s)
        {
            Dictionary<string,int> symbols = new Dictionary<string,int>
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
            };

            int result = 0;
            int index = 0;

            while (index < s.Length)
            {
                if (index+1 < s.Length && symbols.ContainsKey(s.Substring(index,2)))
                {
                    result += symbols[s.Substring(index,2)];
                    index += 2;
                }
                else
                {
                    result += symbols[s[index].ToString()];
                    index++;
                }
            }

            return result;
        }

        // GasStation (#134)...
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            // begin at station 0 w/ empty tank...
            int total_gas = 0;
            int total_cost = 0;
            int capacity = 0;
            int start = 0;

            // sum gas + costs, iterate starts to find valid start...
            for (int i = 0; i < gas.Length; i++)
            {
                total_gas += gas[i];
                total_cost += cost[i];
                capacity += gas[i] - cost[i];

                if (capacity < 0)
                {
                    start = i+1;
                    capacity = 0;
                }
            }

            // ensure loop is possible...
            if (total_gas < total_cost)
            {
                return -1;
            }

            // return valid start station...
            return start;
        }

        // ReverseWords (#151)...
        public string ReverseWords(string s)
        {
            // remove leading/trailing spaces...
            s = s.Trim();

            // split string into array of substrings, delimited by spaces + exclude spaces...
            string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            // reverse array...
            Array.Reverse(words);

            return string.Join(" ", words);
        }

        // CombinationSum (#39)...
        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            // initialize result List...
            IList<IList<int>> result = new List<IList<int>>();

            // define recursive helper...
            void Backtrack(List<int> currCombo, int start, int currSum)
            {
                // base case: check for target...
                if (currSum == target)
                {
                    // store current combo in results...
                    result.Add(new List<int>(currCombo));
                    return;
                }

                // return when currSum < target...
                if (currSum > target) { return; }

                // try each candidate from start onwards (avoids duplicates)...
                for (int i = start; i < candidates.Length; i++)
                {
                    // add curr candidate...
                    currCombo.Add(candidates[i]);

                    // recurse w/ curr candidate again...
                    Backtrack(currCombo, i, currSum+candidates[i]);

                    // remove last candidate...
                    currCombo.RemoveAt(currCombo.Count - 1);
                }
            }

            // start backtracking from ind=0, empty combo and sum=0...
            Backtrack(new List<int>(), 0, 0);

            return result;
        }
    }

    public class Problems
    {
        // Merge (#88)...
        public void Merge()
        {
            Console.WriteLine("Solving Merge:");

            int[] nums1 = {1,2,3,0,0,0};
            int[] nums2 = {2,5,6};

            Solutions solution = new Solutions();
            solution.Merge(nums1,3,nums2,3);
            string response = "{";

            for (int i=0; i< nums1.Length; i++)
            {
                if (i > 0) {
                    response += ",";
                }
                response += nums1[i];
            }
            Console.WriteLine(response + "}\n");
        }

        // RemoveElement (#27)...
        public void RemoveElement()
        {
            Console.WriteLine("Solving RemoveElement:");

            int[] nums = {0,1,2,2,3,0,4,2};
            int val = 2;

            Solutions solution = new Solutions();
            int tail = solution.RemoveElement(nums,val);
            string response = "{";

            // tail shows tail index (inclusive)...
            for (int i=0; i <= tail; i++)
            {
                if (i > 0) {
                    response += ",";
                }
                response += nums[i];
            }
            Console.WriteLine(response + "}\n");
        }

        // RemoveDuplicates (#26)...
        public void RemoveDuplicates()
        {
            Console.WriteLine("Solving RemoveDuplicates:");

            int[] nums = {0,0,1,1,1,2,2,3,3,4};

            Solutions solution = new Solutions();
            int tail = solution.RemoveDuplicates(nums);
            string response = "{";

            // tail shows num of non-duplicates (exclusive)...
            for (int i=0; i < tail; i++)
            {
                if (i > 0) {
                    response += ",";
                }
                response += nums[i];
            }
            Console.WriteLine(response + "}\n");
        }

        // IntToRoman (#12)...
        public void IntToRoman()
        {
            Console.WriteLine("Solving IntToRoman:");

            int num = 3749;

            Solutions solution = new Solutions();
            string result = solution.IntToRoman(num);

            if (result != null)
            {
                Console.WriteLine(result + "\n");
            } else {
                Console.WriteLine("No solution found.\n");
            }
        }

        // RomanToInt (#13)...
        public void RomanToInt()
        {
            Console.WriteLine("Solving RomanToInt");

            string roman = "MCMXCIV";

            Solutions solution = new Solutions();
            int result = solution.RomanToInt(roman);

            Console.WriteLine(result + "\n");
        }

        // GasStation (#134)...
        public void CanCompleteCircuit()
        {
            Console.WriteLine("Solving GasStation");

            int[] gas = {1,2,3,4,5};
            int[] cost = {3,4,5,1,2};

            Solutions solution = new Solutions();
            int result = solution.CanCompleteCircuit(gas,cost);

            Console.WriteLine($"Circuit found starting at station {result}\n");
        }

        // ReverseWords (#151)...
        public void ReverseWords()
        {
            Console.WriteLine("Solving ReverseWords");

            string s = "a good   example";

            Solutions solution = new Solutions();
            string reversed = solution.ReverseWords(s);

            Console.WriteLine(reversed + "\n");
        }

        // CombinationSum (#39)...
        public void CombinationSum() 
        {
            Console.WriteLine("Solving CombinationSum");

            int[] candidates = {2,3,6,7};
            int target = 7;

            Solutions solution = new Solutions();
            IList<IList<int>> results = solution.CombinationSum(candidates,target);

            foreach (IList<int> result in results)
            {
                Console.WriteLine("[" + string.Join(",",result) + "]");
            }

            Console.Write("\n");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Problems problem = new Problems();
            problem.Merge();
            problem.RemoveElement();
            problem.RemoveDuplicates();
            problem.IntToRoman();
            problem.RomanToInt();
            problem.CanCompleteCircuit();
            problem.ReverseWords();
            problem.CombinationSum();
        }
    }
}
