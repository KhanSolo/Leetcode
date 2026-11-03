/*
    Sliding window
*/

using System.Diagnostics;

public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        if (k == 0) return 0d;
        int l = 0, r=k, max_sum = 0;
        for(int i=0; i<r; ++i) max_sum += nums[i]; // sum of first k elems
        var cur_sum = max_sum;

        while (r < nums.Length)
        {
            cur_sum = cur_sum - nums[l] + nums[r]; // moving sliding window
            {l++; r++;}
            if (cur_sum > max_sum) max_sum = cur_sum;
        }

        return (double)max_sum / k;
    }

    public static void Main()
    {
        var sol = new Solution();

        sol.Assert([0,4,0,3,2], 1, 4d);
        sol.Assert([1,12,-5,-6,50,3], 4, 12.75d);
        sol.Assert([5], 1, 5d);
  
        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[] nums, int k, double expected)
    {
        var actual = FindMaxAverage(nums, k);
        Console.WriteLine(actual + " " + expected);
        var equals = Math.Abs(actual - expected) < double.Epsilon;
        Debug.Assert(equals);
    }
}