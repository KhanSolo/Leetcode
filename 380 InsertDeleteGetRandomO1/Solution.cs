
using System.Diagnostics;

public class RandomizedSet {

    private readonly List<int> list = new();
    private readonly Dictionary<int, int> map = new();
    private readonly Random random = new();

    public RandomizedSet() {}
    
    public bool Insert(int val) {
        if(map.TryGetValue(val, out _)) return false;        

        var idx = list.Count;
        list.Add(val);
        map[val] = idx;

        return true;
    }
    
    public bool Remove(int val) {
        if(map.TryGetValue(val, out var idx))
        {
            var newVal = list[list.Count-1];
            list[idx] = newVal;
            map[newVal] = idx;
            list.RemoveAt(list.Count - 1);
            map.Remove(val);
            return true;
        }

        return false;        
    }
    
    public int GetRandom() {
        var idx = random.Next(list.Count);
        return list[idx];
    }
}

//  * Your RandomizedSet object will be instantiated and called as such:
//  * RandomizedSet obj = new RandomizedSet();
//  * bool param_1 = obj.Insert(val);
//  * bool param_2 = obj.Remove(val);
//  * int param_3 = obj.GetRandom();

 public class Solution
{
    static void Main()
    {
        {
            var obj = new RandomizedSet();
            Assert(!obj.Remove(0)); // []
            Assert(!obj.Remove(0)); // []
            Assert(obj.Insert(0));  // [0]
            Console.WriteLine(obj.GetRandom()); // 0
            Assert(obj.Remove(0));  // []
            Assert(obj.Insert(0));  // [0]
        }
        {
            var obj = new RandomizedSet();
            Assert(obj.Insert(4));
            Assert(!obj.Remove(9));
            Assert(!obj.Insert(4));
            Assert(obj.Remove(4));
            Assert(obj.Insert(8));
            Console.WriteLine(obj.GetRandom());
        }
        {
            var obj = new RandomizedSet();
            Assert(obj.Insert(1));
            Console.WriteLine(obj.GetRandom());
        }
        {
            var obj = new RandomizedSet();
            Assert(!obj.Remove(2));
        }
        Console.WriteLine("Tests passed!");

        static void Assert(bool exp) => Debug.Assert(exp);
    }
}