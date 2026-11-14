

//  Definition for singly-linked list.
using System.Diagnostics;

public class ListNode {
     public int val;
     public ListNode? next;
     public ListNode(int val=0, ListNode? next=null) {
         this.val = val;
         this.next = next;
     }
 }
 
public class Solution {
    public ListNode ReverseList(ListNode head) {

        ListNode? node = head;
        ListNode? prev = null;
        while(node is not null)
        {
            var next = node.next;
            node.next = prev;          
            prev = node;
            node = next;
        }

        return prev;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([1,2,3,4,5], [5,4,3,2,1]);
        sol.Assert([1,2], [2,1]);
        sol.Assert([], []);

        Console.WriteLine("Tests passed!");
    }

    public void Assert(int[] input, int[] output)
    {
        // create a linked list
        ListNode head = null!;
        ListNode? prev = null;
        for(int i=0; i<input.Length; i++)
        {
            var node = new ListNode(input[i]);

            if(i is 0) head = node;
            if(prev is not null) prev.next = node;
            prev = node;
        }

        // act
        var result = ReverseList(head);

        // assert
        var actual = new List<int>();
        var curNode = result;
        while (curNode is not null)
        {
            actual.Add(curNode.val);
            curNode = curNode.next;
        }

        Debug.Assert(actual.Count == output.Length);
        for(int i=0; i<actual.Count; i++)
        {
            Debug.Assert(actual[i] == output[i], $"i: {i}");
        }
    }
}

static class Extension
{
    
}
