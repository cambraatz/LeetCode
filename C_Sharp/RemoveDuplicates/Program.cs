using System;
using System.Collections.Generic;

namespace RemoveDuplicates
{
    public class Solution
    {
        public int RemoveDuplicates(List<int> nums)
        {
            if (nums.Count == 0)
            {
                return 0;
            }

            int left = 0;
            int right = 1;

            while (right < nums.Count)
            {
                if (nums[left] == nums[right])
                {
                    right += 1;
                } else {
                    left += 1;
                    nums[left] = nums[right];
                    right += 1;
                }
            }

            return left+1;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> {0,0,1,1,1,2,2,3,3,4};

            Solution solution = new Solution();
            int result = solution.RemoveDuplicates(nums);

            int index = 0;
            while (index < result)
            {
                Console.WriteLine(nums[index]);
                index++;
            }
        }
    }
}
