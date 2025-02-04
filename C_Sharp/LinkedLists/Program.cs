using System;
using System.Collections.Generic;

namespace LinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val=0, ListNode? next=null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkedList
    {
        public ListNode? head;
        public int count;
        public LinkedList(int[] arr)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            int count = 0;

            foreach (int number in arr)
            {
                curr.next = new ListNode(number);
                curr = curr.next;
                count++;
            }

            this.head = dummy.next;
            this.count = count;
        }
    }

    public class Solutions
    {
        // AddTwoNumbers (#2) and assoc. helpers...
        private void AddNode(ref ListNode curr, int value)
        {
            curr.next = new ListNode(value);
            curr = curr.next;
        }
        public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2) 
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
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
                AddNode(ref curr, sum % 10);
            }

            return dummy.next;
        }

        // MergeTwoSortedLists (#21) and assoc. helpers...
        private void AddNodeFromList(ref ListNode curr, ref ListNode? newNode)
        {
            if (newNode == null) { return; }

            curr.next = new ListNode(newNode.val);
            curr = curr.next;
            newNode = newNode.next;
        }
        public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;

            while (list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                {
                    if (list1.val <= list2.val)
                    {
                        AddNodeFromList(ref curr, ref list1);
                    } else {
                        AddNodeFromList(ref curr, ref list2);
                    }
                }
                else if (list1 != null)
                {
                    AddNodeFromList(ref curr, ref list1);
                }
                else {
                    AddNodeFromList(ref curr, ref list2);
                }
            }

            return dummy.next;
        }

        public bool HasCycle(ListNode? head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode? slow = head;
            ListNode? fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow?.next;
                fast = fast?.next?.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) { return head; }

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prev = dummy;

            for (int i=0; i < left-1; i++)
            {
                prev = prev.next;
            }

            ListNode curr = prev.next;
            ListNode next = null;

            for (int i=1; i < (right-left)+1; i++)
            {
                next = curr.next;
                curr.next = next.next;
                next.next = prev.next;
                prev.next = next;
            }

            return dummy.next;
        }
    }

    public class Problems
    {
        // AddTwoNumbers (#2)...
        public void AddTwoNumbers()
        {
            Console.WriteLine("Solving AddTwoNumbers:");

            LinkedList l1 = new LinkedList(new int[] {2,4,3});
            LinkedList l2 = new LinkedList(new int[] {5,6,4});

            Solutions solution = new Solutions();
            ListNode? result = solution.AddTwoNumbers(l1.head, l2.head);

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

        // MergeTwoSortedLists (#21)...
        public void MergeTwoLists()
        {
            Console.WriteLine("Solving MergeTwoLists:");

            LinkedList l1 = new LinkedList(new int[] {1,2,4});
            LinkedList l2 = new LinkedList(new int[] {1,3,4});

            Solutions solution = new Solutions();
            ListNode? result = solution.MergeTwoLists(l1.head, l2.head);

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

        // LinkedListCycle (#141)...
        public void LinkedListCycle()
        {
            Console.WriteLine("Solving LinkedListCycle:");

            LinkedList l1 = new LinkedList(new int[] {3,2,0,-4});

            Solutions solution = new Solutions();
            bool? result = solution.HasCycle(l1.head);

            if (result != null)
            {
                Console.WriteLine(result);
            } else {
                Console.WriteLine("No solution found.");
            }
        }

        // ReverseBetween (#92)...
        public void ReverseBetween()
        {
            Console.WriteLine("Solving ReverseBetween:");

            LinkedList l1 = new LinkedList(new int[] {1,2,3,4,5});

            Solutions solution = new Solutions();
            ListNode result = solution.ReverseBetween(l1.head,2,4);

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

    public class Program
    {
        static void Main(string[] args)
        {
            Problems problem = new Problems();
            problem.AddTwoNumbers();
            problem.MergeTwoLists();
            problem.LinkedListCycle();
            problem.ReverseBetween();
        }
    }
}
