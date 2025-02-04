using System;

namespace AddTwo
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode head = new ListNode(0);
            ListNode curr = head;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                curr.next = new ListNode(sum % 10);

                curr = curr.next;
            }

            return head.next;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int[] l1 = new int[] {2,4,3};
            int[] l2 = new int[] {5,6,4};

            ListNode l1_head = new ListNode(l1[0]);
            ListNode node = l1_head;

            for (int i=1; i<l1.Length; i++)
            {
                node.next = new ListNode(l1[i]);
                node = node.next;
            }

            ListNode l2_head = new ListNode(l2[0]);
            node = l2_head;

            for (int i=1; i<l1.Length; i++)
            {
                node.next = new ListNode(l2[i]);
                node = node.next;
            }

            Solution solution = new Solution();
            ListNode result = solution.AddTwoNumbers(l1_head,l2_head);

            if (result != null)
            {
                while (result != null)
                {
                    Console.WriteLine(result.val);
                    result = result.next;
                }
            } else {
                Console.WriteLine("No solution found.");
            }
        }
    }
}