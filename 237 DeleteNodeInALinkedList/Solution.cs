//  Definition for singly-linked list.
using System.Diagnostics;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int v = 0, ListNode? n = null) => (val, next) = (v, n);
}
 
public class Solution {
    public void DeleteNode(ListNode node) {
        // we do not have a head
        // so, we should copy next into node and delete next
        var next = node.next;
        if(next is not null){
            node.val = next.val;
            node.next = next.next;
        }
    }
    
    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([4,5,1,9], 5, [4,1,9]);
        sol.Assert([4,5,1,9], 1, [4,5,9]);
        Console.WriteLine("Tests passed!");
    }

    public void Assert(int[] input, int valForDelete, int[] output)
    {
        var head = CreateLinkedList(input);
        var node = FindNode(head, valForDelete);
        Debug.Assert(node != null);

        // act
        DeleteNode(node);

        // assert
        var actual = ToArray(head);

        AssertEqual(actual, output);
    }

    private ListNode? FindNode(ListNode head, int val)
    {
        var node = head;
        while(node is not null)
        {
            if(node.val == val) break;
            node = node.next;
        }
        return node;
    }
    
    private static IReadOnlyCollection<int> ToArray(ListNode result)
    {
        var actual = new List<int>();
        var curNode = result;
        while (curNode is not null)
        {
            actual.Add(curNode.val);
            curNode = curNode.next;
        }
        return actual;
    }

    private static void AssertEqual<T>(IReadOnlyCollection<T> actual, IReadOnlyCollection<T> expected)
    {
        Debug.Assert(actual.Count == expected.Count);

        using var actualEnumerator = actual.GetEnumerator();
        using var expectedEnumerator = expected.GetEnumerator();

        int i = 0;
        while (actualEnumerator.MoveNext() && expectedEnumerator.MoveNext())
        {
            Debug.Assert(
                EqualityComparer<T>.Default.Equals(actualEnumerator.Current, expectedEnumerator.Current),
                $"i: {i}");

            i++;
        }
    }

    private static ListNode CreateLinkedList(int[] input)
    {
        ListNode head = null!;
        ListNode? prev = null;
        for(int i=0; i<input.Length; i++)
        {
            var node = new ListNode(input[i]);
            if(i is 0) head = node;
            if(prev is not null) prev.next = node;
            prev = node;
        }
        return head;
    }
}
