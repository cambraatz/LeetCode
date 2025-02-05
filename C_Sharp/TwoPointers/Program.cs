using System;
using System.Collections.Generic;

namespace TwoPointers
{
    public class Solutions
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0;
            int right = 1;

            while (left < nums.Length)
            {
                while (right < nums.Length)
                {
                    if (nums[left] + nums[right] == target)
                    {
                        return new int[] {left,right};
                    }
                    right++;
                }
                left++;
                right = left+1;
            }

            return new int[] {-1,-1};
        }
    }
    public class Problems
    {
        public void TwoSum()
        {
            int[] nums = {2,7,11,15};
            int target = 22;

            Solutions solution = new Solutions();
            int[] result = solution.TwoSum(nums,target);

            string response = $"Target found at indices {result[0]} and {result[1]}\n";
            Console.WriteLine(response);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Problems problem = new Problems();
            problem.TwoSum();
        }
    }
}
