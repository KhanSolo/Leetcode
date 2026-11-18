using System.Diagnostics;

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();

        return set1.Intersect(set2).ToArray();
    }

    static void Main()
    {
        var sol = new Solution();
        sol.Assert([1,2,2,1], [2,2], [2]);
        sol.Assert([4,9,5], [9,4,9,8,4], [4,9]);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[] nums1, int[] nums2, int[] expected)
    {
        var actual = Intersection(nums1, nums2);
        AssertEq(actual, expected);
    }

    private void AssertEq(int[] actual, int[] expected)
    {
        Debug.Assert(actual.Length == expected.Length);
        for(int i=0; i<actual.Length; i++)
        {
            Debug.Assert(actual[i] == expected[i]);
        }
    }
}