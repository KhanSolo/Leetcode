/*
    2 pointers
*/

using System.Diagnostics;

public class Solution {
    public void MoveZeroes(int[] nums) {
        int j;
        for(j=0; j<nums.Length; ++j)
        {
            if(nums[j]==0) break; // finding first zero
        }

        for (int i=j; i<nums.Length; ++i)
        {
            if (nums[i] != nums[j])
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                j++;
            }
        }
    }

    public void MoveZeroes_(int[]nums)
    {
        int j=0;
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != 0)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]); // it strarts to swap if even no zero case
                j++;                
            }
        }
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert([0], [0]);
        sol.Assert([0,1,0,3,12], [1,3,12,0,0]);
        sol.Assert([1,3,0,0,4], [1,3,4,0,0]);
        sol.Assert([1,2,3,4,5], [1,2,3,4,5]);
        Console.WriteLine("Tests passed!");
    }

    public void Assert(int[] actual, int[] expected)
    {
        MoveZeroes(actual);
        for(int i=0; i<expected.Length; ++i)
        {
            Debug.Assert(expected[i] == actual[i], $"i:{i}");
        }
    }
}