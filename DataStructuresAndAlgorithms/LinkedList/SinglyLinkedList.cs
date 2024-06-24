using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList
    {
        ListNode? head;

        /// <summary>
        /// Traverses the list and prints the data of each item.
        /// </summary>
        public void PrintList()
        {
            ListNode? temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
        }

        /// <summary>
        /// Adds a number to the list. List will always be in ascending order.
        /// </summary>
        /// <param name="number">Number to add.</param>
        public void AddNode(int number)
        {
            ListNode node = new ListNode() { data = number };   // Create node

            // Head
            if(node.data <= head?.data || head == null)
            {
                node.next = head;
                head = node;
                return;
            }

            // Body
            ListNode temp = head;
            while (temp!.next != null)
            {
                if(node.data <= temp.next.data)
                {
                    node.next = temp.next;
                    temp.next = node;
                    return;
                }

                temp = temp.next!;
            }

            // Tail
            temp.next = node;
        }

        /// <summary>
        /// Removes a number from the list. 
        /// 
        /// If multiple instances of the number exist, only the first instance of the number is removed.
        /// </summary>
        /// <param name="number">Number to remove.</param>
        public void RemoveNode(int number)
        {
            // Head
            if (head?.data == number)
            {
                head = head.next;
                return;
            }

            // Body
            ListNode? temp = head;
            while(temp != null)
            {
                if (temp.next?.data == number)
                {
                    temp.next = temp.next.next;
                    return;
                }
            }
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void ClearList()
        {
            head = null;
            return;

            // Garbage collection is automatic in C#, but this is a sort of pseudocode for languages w/o a garbage collector.
            ListNode? temp = head;
            while (temp != null)
            {
                temp = temp.next;
                // Destroy(head);
            }
        }
    }
}
