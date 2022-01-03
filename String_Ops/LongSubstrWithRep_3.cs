using System;
using System.Collections.Generic;
using System.Text;

namespace String_Ops.LongSubstrWithRep_3
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1 || s.Length == 0)
                return s.Length;

            int maxLeng = 0, subLeng = 0;
            for (int index = 0; index < s.Length; index++)
            {
                for (int tempIndex = index; tempIndex < s.Length; tempIndex++)
                    if (!s.Substring(index, tempIndex - index).Contains(s[tempIndex]))
                        subLeng++;
                    else
                        break;

                maxLeng = (maxLeng < subLeng) ? subLeng : maxLeng;
                subLeng = 0;
            }
            return maxLeng;
        }
    }
    
    public class Solution2
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1 || s.Length == 0)
                return s.Length;

            StringBuilder sb = new StringBuilder(); 
            int maxLeng = 0, subLeng = 0;
            for (int index = 0; index < s.Length; index++)
            {
                for (int tempIndex = index; tempIndex < s.Length; tempIndex++)
                {
                    if (!sb.ToString().Contains(s[tempIndex]))
                    {
                        sb.Append(s[tempIndex]);
                        subLeng++;
                    }
                    else
                        break;
                }
               
                maxLeng = (maxLeng < subLeng) ? subLeng : maxLeng;
                sb.Clear();
                subLeng = 0;
            }
            return maxLeng;
        }
    }

    public class Solution3
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1 || s.Length == 0)
                return s.Length;

            StringBuilder sb = new StringBuilder();
            int maxLeng = 0;
            for (int index = 0; index < s.Length; index++)
            {
                int tempIndex = index;
                while(tempIndex < s.Length)
                {
                    if (!sb.ToString().Contains(s[tempIndex]))
                        sb.Append(s[tempIndex++]);
                    else
                        break;
                }
               
                maxLeng = (maxLeng < sb.Length) ? sb.Length : maxLeng;
                sb.Clear();
            }
            return maxLeng;
        }
    }

    public class Solution4
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1 || s.Length == 0)
                return s.Length;

            StringBuilder sb = new StringBuilder();
            int maxLeng = 0;
            for (int index = 0; index < s.Length; index++)
            {
                int tempIndex = index;
                while (tempIndex < s.Length)
                {
                    if (!sb.ToString().Contains(s[tempIndex]))
                        sb.Append(s[tempIndex++]);
                    else
                        break;
                }

                maxLeng = (maxLeng < sb.Length) ? sb.Length : maxLeng;
                sb.Clear();
            }
            return maxLeng;
        }
    }
}
