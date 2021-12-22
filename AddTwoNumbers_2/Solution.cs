using System;

namespace AddTwoNumbers_2
{
    public class ListNode
    {
        public int val;
        public ListNode next;
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode nodeResult = new ListNode();
            ListNode nodeC = nodeResult;
            ListNode[] nodes = { l1, l2 };
            int result = 0;
            bool hasNext = false;
            while (true)
            {
                hasNext = false;
                for (int index = 0; index < nodes.Length; index++)
                {
                    if (nodes[index] != null)
                    {
                        // Get the sum of all digits
                        result += nodes[index].val;

                        // Clear the element if it does not have next digit 
                        if (nodes[index].next != null)
                        {
                            hasNext = true;
                            nodes[index] = nodes[index].next;
                        }
                        else
                            nodes[index] = null;
                    }
                }

                // Check if sum exceeds one digit
                if (result >= 10)
                {
                    nodeC.val = result - 10;
                    result = 1;
                }
                else
                {
                    nodeC.val = result;
                    result = 0;
                }

                // Create the next node if needed 
                if (hasNext || result != 0)
                    nodeC.next = new ListNode();

                if (nodeC.next == null)
                    break;
                else
                    nodeC = nodeC.next;
            }

            return nodeResult;
        }
    }

}
