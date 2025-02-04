using System;

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0;
            int right = 1;
            int product;

            while (left < nums.Length && right < nums.Length)
            {
                while (right < nums.Length)
                {
                    product = nums[left] + nums[right];

                    if (product == target)
                    {
                        return new int[] {left,right};
                    }
                    
                    right += 1;
                }
                left += 1;
                right = left + 1;
            }

            return null;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,7,11,15};
            int target = 18;

            Solution solution = new Solution();
            int[] result = solution.TwoSum(nums, target);

            if (result != null)
            {
                Console.WriteLine($"Indices: {result[0]}, {result[1]}");
            } else {
                Console.WriteLine("No solution found.");
            }
        }
    }
}