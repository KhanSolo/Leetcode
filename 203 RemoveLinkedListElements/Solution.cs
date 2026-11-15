using System.Diagnostics;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int v = 0, ListNode? n = null) => (val, next) = (v, n);
}

public class Solution {
    public ListNode? RemoveElements(ListNode head, int val) {
        ListNode dummy = new();
        var tail = dummy;
        var node = head;
        while (node is not null)
        {
            if(node.val == val)
            {
                // move node
                while(node is not null && node.val == val) node = node.next;                
            }
            tail.next = node;

            if(node != null) node = node.next;
            if(tail != null) tail = tail.next;
        }

        return dummy.next;
    }

    public static void Main()
    {
        var sol = new Solution();

        sol.Assert([1,2,6,3,4,5,6], 6, [1,2,3,4,5]);
        sol.Assert([], 1, []);
        sol.Assert([7,7,7,7], 7, []);

        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[] input, int del, int[] expected)
    {
        var head = CreateLinkedList(input);
        var result = RemoveElements(head, del);
        var actual = ToArray(result);
        AssertEqual(actual, expected);
    }
    
    private static IReadOnlyCollection<int> ToArray(ListNode? result)
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