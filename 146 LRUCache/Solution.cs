
using System.Diagnostics;

public class LRUCache {

    private readonly int capacity;
    private readonly Dictionary<int, int> map;
    private ListNode? head = null;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        map = new(capacity);
    }
    
    private const int NotFound = -1;
    public int Get(int key) {

        return NotFound;
    }
    
    public void Put(int key, int value) {
        
    }

    class ListNode
    {
        public int value;
        public ListNode? next = null;
        public ListNode? prev = null;
        public ListNode(int value=default, ListNode? prev=null, ListNode? next=null)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }
    }
}

//  * Your LRUCache object will be instantiated and called as such:
//  * LRUCache obj = new LRUCache(capacity);
//  * int param_1 = obj.Get(key);
//  * obj.Put(key,value);

public class Solution
{
    static void Main()
    {
        // Input
        // ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
        // [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
        // Output
        // [null, null, null, 1, null, -1, null, -1, 3, 4]

        // Explanation
        var lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}        
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}   
        Debug.Assert(lRUCache.Get(1) == 1); // return 1
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        var second = lRUCache.Get(2);    // returns -1 (not found)
        Debug.Assert(second == -1);
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        Debug.Assert(lRUCache.Get(1) == -1); // return -1 (not found)
        Debug.Assert(lRUCache.Get(3) == 3); // return 3
        Debug.Assert(lRUCache.Get(4) == 4); // return 4

        Console.WriteLine("Tests passed!");
    }
}
