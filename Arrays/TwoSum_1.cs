using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.TwoSums_1
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int indexA = 0; indexA < nums.Length; indexA++)
                for (int indexB = 0; indexB < nums.Length; indexB++)
                {
                    if (indexA == indexB)
                        continue;

                    if (nums[indexA] + nums[indexB] == target)
                        return new[] { indexA, indexB };
                }

            return null;
        }
    }
}
