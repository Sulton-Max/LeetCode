using System;

namespace MedianOfTwoSortedArrays_4
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length;
            int length2 = nums2.Length;

            int GetLower(ref int index1, ref int index2)
            {
                if (index1 == length1)
                    return nums2[index2++];
                else if (index2 == length2)
                    return nums1[index1++];

                if (nums1[index1] < nums2[index2])
                    return nums1[index1++];
                else
                    return nums2[index2++];
            }

            // Find the size of elems of 2 arrays 
            int length = nums1.Length + nums2.Length;
            int stopIndex = (length - 1) / 2;

            double result = 0.0;

            int index = 0, index1 = 0, index2 = 0;
            while (true)
            {
                if (index == stopIndex)
                {
                    if (length % 2 == 0)
                        result = (GetLower(ref index1, ref index2) + GetLower(ref index1, ref index2)) / 2.0;
                    else
                        result = GetLower(ref index1, ref index2);

                    break;
                }

                GetLower(ref index1, ref index2);
                index++;
            }

            return result;
        }
    }
}