using System.Diagnostics;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int v = 0, ListNode? n = null) => (val, next) = (v, n);
}

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        
        var node1 = list1;
        var node2 = list2;
        ListNode dummy = new();
        ListNode? tail = dummy; // current       
        while(node1 is not null && node2 is not null)
        {            
            if (node1.val < node2.val)
            {
                tail.next = node1;
                node1 = node1.next;
            } 
            else
            {
                tail.next = node2;
                node2 = node2.next;                    
            }
            tail = tail.next;
        }
        if(node1 is not null) tail.next = node1;
        if(node2 is not null) tail.next = node2;

        return dummy.next;
    }

    public static void Main()
    {
        var sol = new Solution();

        sol.Assert([1,2,4], [1,3,4], [1,1,2,3,4,4]);
        sol.Assert([], [], []);
        sol.Assert([], [0], [0]);

        Console.WriteLine("Tests passed!");
    }

    public void Assert(int[] first, int[] second, int[] expected)
    {
        // create a linked list
        ListNode head1 = CreateLinkedList(first);
        ListNode head2 = CreateLinkedList(second);

        // act
        var result = MergeTwoLists(head1, head2);

        // assert
        var actual = ToArray(result);

        AssertEqual(actual, expected);
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
