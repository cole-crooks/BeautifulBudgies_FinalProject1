/*
* Name: Derick Bellofatto
* email:  bellofdk@mail.uc.edu
* Assignment Number: Final Project
* Due Date:   12/10/2024
* Course #/Section:   IS3050-001
* Semester/Year:   Fall 2024
* Brief Description of the assignment:  Final Project for the IS 3050 Web Development w/ .NET

* Brief Description of what this module does. Demonstrating all that we've learned this year, solve one (1) hard leetcode problem per person with class knowledge and Github
* Citations:https://leetcode.com/problems/parsing-a-boolean-expression/description/
            https://github.com/cole-crooks/crookscl_FinalProject
            https://gist.github.com/jianminchen/d6e4b357fe64f8d76c502e22761049a7
            https://leetcode.com/problems/merge-k-sorted-lists/
* Anything else that's relevant: My collaborators on this project are Jack Driehaus (driehajl@mail.uc.edu), Cole Crooks (crookscl@mail.uc.edu), and Daquan Daniels (danieldu@mail.uc.edu)
*/


using System;
using System.Collections.Generic;

namespace Leetcode23_MergeKSortedLists
{
    // Helper class to store a node and its originating index
    public class NodeIndex
    {
        public ListNode Node { get; set; } // The current node in the linked list
        public int Index { get; set; } // The index of the linked list in the array

        public NodeIndex(ListNode node, int index)
        {
            Node = node; // Initialize the node
            Index = index; // Initialize the index
        }
    }

    // Definition of a singly linked list node
    public class ListNode
    {
        public int val; // The value stored in the node
        public ListNode next; // Pointer to the next node

        public ListNode(int x)
        {
            val = x; // Initialize the node's value
        }
    }

    public class Leetcode23_MergeKSortedLists
    {
        // Method to merge k sorted linked lists into one sorted linked list
        public ListNode MergeKLists(ListNode[] lists)
        {
            // A sorted set to keep track of nodes from the lists
            var sortedSet = new SortedSet<NodeIndex>(
                Comparer<NodeIndex>.Create((a, b) =>
                    a.Node.val == b.Node.val ? a.Index - b.Index : a.Node.val - b.Node.val));

            // Create a dummy node to act as the head of the merged list
            var head = new ListNode(int.MinValue);
            var p = head; // Pointer to build the merged list

            // Add the first node of each linked list to the sorted set
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null) // Ensure the list is not empty
                {
                    sortedSet.Add(new NodeIndex(lists[i], i)); // Add node and its list index
                }
            }

            // While the sorted set has nodes to process
            while (sortedSet.Count != 0)
            {
                // Get the smallest value node
                var nextMerge = sortedSet.Min;

                // Add it to the merged list
                p.next = nextMerge.Node;
                p = p.next; // Move the pointer forward

                // Remove the node from the sorted set
                sortedSet.Remove(nextMerge);

                // If the next node in the list exists, add it to the sorted set
                if ((nextMerge.Node = nextMerge.Node.next) != null)
                {
                    sortedSet.Add(nextMerge);
                }
            }

            // Return the merged list, skipping the dummy node
            return head.next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Call the method to run the example and print the result
            string result = Problem23Solution();
            Console.WriteLine(result); // Print the result
        }

        // Method to set up the example input and call the merge logic
        public static string Problem23Solution()
        {
            // Create example linked lists [[1,4,5],[1,3,4],[2,6]]
            var list1 = CreateLinkedList(new int[] { 1, 4, 5 }); // First list
            var list2 = CreateLinkedList(new int[] { 1, 3, 4 }); // Second list
            var list3 = CreateLinkedList(new int[] { 2, 6 }); // Third list

            // Combine the lists into an array
            var lists = new ListNode[] { list1, list2, list3 };

            // Create an instance of the solution class
            var solution = new Leetcode23_MergeKSortedLists();

            // Merge the k sorted linked lists
            var mergedList = solution.MergeKLists(lists);

            // Convert the merged list to a string for output
            return ConvertLinkedListToString(mergedList);
        }

        // Helper method to create a linked list from an array
        static ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0) return null; // Handle empty input

            // Create the head node
            var head = new ListNode(values[0]);
            var current = head; // Pointer to build the list

            // Add subsequent nodes
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next; // Move pointer forward
            }

            return head; // Return the constructed list
        }

        // Helper method to convert a linked list to a string
        static string ConvertLinkedListToString(ListNode head)
        {
            if (head == null) return "null"; // Handle empty list

            var result = new List<int>(); // Store values for output
            while (head != null)
            {
                result.Add(head.val); // Collect node values
                head = head.next; // Move to the next node
            }

            // Format the output as "1 -> 2 -> 3 -> null"
            return string.Join(" -> ", result) + " -> End of Method";
        }
    }
}