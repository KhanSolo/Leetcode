/*
    2 pointers
    O(n) complexity
    O(1)
*/

using System.Diagnostics;

public class Solution {
    public int MaxArea(int[] height) {
        
        int l = 0;
        int r = height.Length - 1;
        int m = 0;
        while (l < r)
        {
            var cur = Math.Min(height[l], height[r]) * (r-l);
            m = Math.Max(m, cur);

            if(height[l] < height[r]) l++; else r--; // moving side where wall is less
        }
        return m;
    }

    public static void Main()
    {
        var sol = new Solution();

        {
            // Input: height = [1,8,6,2,5,4,8,3,7]
            // Output: 49
            // Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
            // In this case, the max area of water (blue section) the container can contain is 49.
            var res = sol.MaxArea([1,8,6,2,5,4,8,3,7]);
            Debug.Assert(res == 49);
        }

        {
            // Input: height = [1,1]
            // Output: 1
            var res = sol.MaxArea([1,1]);
            Debug.Assert(res == 1);
        }

        Console.WriteLine("Tests passed!");
    }
}
