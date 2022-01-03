using System;

namespace UniquePaths_62
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            int GetSum(int a, int b)
            {
                return (b + a) * (b - a + 1) / 2;
            }

            if (m == 0 || n == 0)
                return 0;

            if (m == 1 || n == 1)
                return 1;

            if (m == 2 || n == 2)
                return (m == 2) ? n : m;

            int sum = 0;
            int[,] arr = new int[m, n];
            for (int indexA = 0; indexA < m; indexA++)
            {
                sum = 0;
                for (int indexB = 0; indexB < n; indexB++)
                {
                    if (indexA == 1 || indexB == 0)
                        arr[indexA, indexB] = 1;

                    sum += arr[indexA, indexB];
                    if (indexA + 1 < m)
                        arr[indexA + 1, indexB] = sum;
                }
            }

            var result = sum;
            return result;
        }
    }
}
