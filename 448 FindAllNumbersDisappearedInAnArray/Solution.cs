
using System.Diagnostics;

public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        
        var set = nums.ToHashSet();
        var list = new List<int>(set.Count);
        for(var i=1; i<=nums.Length; i++)
        {
            if(!set.Contains(i)) list.Add(i);
        }
        return list;
    }

    static void Main()
    {
        var sol = new Solution();
        sol.Assert([4,3,2,7,8,2,3,1],[5,6]);
        sol.Assert([1,1],[2]);
        Console.WriteLine("Tests passed!");
    }

    void Assert(int[] nums, IList<int> expected)
    {
        var actual = FindDisappearedNumbers(nums);
        Debug.Assert(actual.Count == expected.Count);
        for(int i=0; i<actual.Count; i++)
            Debug.Assert(actual[i]==expected[i]);
    }
}
