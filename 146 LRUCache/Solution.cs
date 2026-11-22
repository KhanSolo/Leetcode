using System;
using System.Diagnostics;

public class LRUCache {

    private readonly int capacity;
    private readonly Dictionary<int, ListNode> map;
    private ListNode head; // head of a double linked list
    private ListNode tail; // tail

    public LRUCache(int capacity) {
        this.capacity = capacity;
        map = new(capacity);
        // creating dummyHead & dummyTail
        tail = new();
        head = new(next: tail); 
    }
    
    private const int NotFound = -1;
    public int Get(int key) {
        // getting a value leads it to be first among recently used (most fresh)
        if(map.TryGetValue(key, out var node))
        {
            // cut the node from a dll and put it to a head after dummyNode
            Promote(node);
            return node.value;
        }
        return NotFound;
    }
    
    public void Put(int key, int value) {
        // making a new value to be first among recently used
        // doing eviction for lru value if it exceeds capacity
        if(map.TryGetValue(key, out var node))
        {
            // cut the node from a dll and put it to a head after dummyNode
            node.value = value;
            Promote(node);
        }
        else
        {
            // new dll node - put to a head after dummyNode
            var next = head.next;
            map[key] = new(value, key, head, next);
                    
            // check for eviction
            if (map.Count > capacity)
            {
                // remove last node in dll (before dummyTail)
                var evic = tail.prev!;
                var prev = evic.prev!;
                prev.next = tail;
                tail.prev = prev;

                evic.next = null;
                evic.prev = null;
                map.Remove(evic.key!.Value);
            }
        }
    }

    private void Promote(ListNode node)
    {
        { // cut
            var prev = node.prev!;
            var next = node.next!;
            prev.next = next;
            next.prev = prev;
        }
        { // put
            var next = head.next!;
            node.prev=head;
            head.next=node;
            node.next=next;
            next.prev=node;
        }
    }

    // double linked list node
    class ListNode
    {
        public int value;
        public int? key; // to fast search in map when the value is evicted
        public ListNode? next;
        public ListNode? prev;

        public ListNode(int value=default, int? key = null, ListNode? prev=null, ListNode? next=null)
        {
            this.value  =   value;
            this.key    =   key;
            this.prev   =   prev;
            this.next   =   next;
            if(this.prev is not null) this.prev.next = this;            
            if(this.next is not null) this.next.prev = this;
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
        Debug.Assert(lRUCache.Get(2) == -1); // returns -1 (not found)
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        Debug.Assert(lRUCache.Get(1) == -1); // return -1 (not found)
        Debug.Assert(lRUCache.Get(3) == 3); // return 3
        Debug.Assert(lRUCache.Get(4) == 4); // return 4

        Console.WriteLine("Tests passed!");
    }
}
