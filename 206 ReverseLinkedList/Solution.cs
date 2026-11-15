//  Definition for singly-linked list.
using System.Diagnostics;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int v = 0, ListNode? n = null) => (val, next) = (v, n);
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
        var head = CreateLinkedList(input);

        // act
        var result = ReverseList(head);

        // assert
        var actual = ToArray(result);

        AssertEqual(actual, output);
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
