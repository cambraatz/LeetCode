using System;

namespace MergeLists
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode(0);
            ListNode curr = head;

            while (list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                {
                    if (list1.val <= list2.val)
                    {
                        curr.next = new ListNode(list1.val);
                        curr = curr.next;
                        list1 = list1.next;
                    }
                    else
                    {
                        curr.next = new ListNode(list2.val);
                        curr = curr.next;
                        list2 = list2.next;
                    }
                }

                else if (list1 != null)
                {
                    curr.next = new ListNode(list1.val);
                    curr = curr.next;
                    list1 = list1.next;
                }

                else
                {
                    curr.next = new ListNode(list2.val);
                    curr = curr.next;
                    list2 = list2.next;
                }
            }

            return head.next;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int[] l1 = new int[] {1,2,4};
            ListNode l1_dummy = new ListNode(0);
            ListNode curr = l1_dummy;

            foreach (int number in l1)
            {
                curr.next = new ListNode(number);
                curr = curr.next;
            }

            int[] l2 = new int[] {1,3,4};
            ListNode l2_dummy = new ListNode(0);
            curr = l2_dummy;

            foreach (int number in l2)
            {
                curr.next = new ListNode(number);
                curr = curr.next;
            }

            Solution solution = new Solution();
            ListNode result = solution.MergeTwoLists(l1_dummy.next,l2_dummy.next);

            if (result != null)
            {
                while (result != null)
                {
                    Console.WriteLine(result.val);
                    result = result.next;
                }
            }
            else 
            {
                Console.WriteLine("No solution found.");
            }
        }
    }
}
