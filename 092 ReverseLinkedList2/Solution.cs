//  Definition for singly-linked list.
using System.Diagnostics;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int v = 0, ListNode? nxt = null) => (val, next) = (v, nxt);

    public override string ToString() => $"val:{val}, nxt:{(next is null?"-":next.val)}";
}

public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        ListNode dummy = new(0, head);
        var prev = dummy;
        var node = head;
        ListNode? leftNode=null, rightNode=null;
        int pos = 0;
        while(node is not null)
        {
            pos++;

            if(leftNode is null && pos == left) leftNode = node; // searching left node
            
            if(rightNode is null && pos == right) { // searching right node
                rightNode = node;            
                
                // reverse a part from left to right
                var nod = leftNode;
                ListNode? pre = null;
                ListNode? end = rightNode.next;
                while(nod != end)
                {
                    var nxt = nod.next;                    
                    nod.next = pre;
                    pre = nod;
                    nod = nxt;
                }

                leftNode.next = end;
                if(prev is not null) prev.next = rightNode;
                break;
            }

            node = node.next;
            if(leftNode is null) prev = prev.next;
        }

        return dummy.next;
    }
    
    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([1,2,3,4,5], 2, 4, [1,4,3,2,5]);
        sol.Assert([1,2,3], 1, 3, [3,2,1]);
        sol.Assert([1,2,3,4,5], 1, 3, [3,2,1,4,5]);
        sol.Assert([1,2,3,4,5], 3, 5, [1,2,5,4,3]);
        sol.Assert([5], 1, 1, [5]);
        sol.Assert([3,5], 1, 2, [5,3]);

        Console.WriteLine("Tests passed!");
    }

    public void Assert(int[] input, int left, int right, int[] output)
    {
        var head = CreateLinkedList(input);

        // act
        var result = ReverseBetween(head, left, right);

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
        Debug.Assert(actual.Count == expected.Count,
         $"expected.Count: {expected.Count}, actual.Count: {actual.Count}");

        using var actualEnumerator = actual.GetEnumerator();
        using var expectedEnumerator = expected.GetEnumerator();

        int i = 0;
        while (actualEnumerator.MoveNext() && expectedEnumerator.MoveNext())
        {
            Debug.Assert(
                EqualityComparer<T>.Default.Equals(actualEnumerator.Current, expectedEnumerator.Current),
                $"i: {i}, expected: {expectedEnumerator.Current}, actual: {actualEnumerator.Current}");

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