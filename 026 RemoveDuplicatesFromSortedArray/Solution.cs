/* 
    2 pointers
*/

using System.Diagnostics;

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if(nums is null || nums.Length is 0) return 0;
        if(nums.Length is 1) return 1;

        int l = 0, r = 1;
        while (r < nums.Length)
        {
            if(nums[l] != nums[r])
                nums[++l] = nums[r]; // increasing slow pointer and copy there new found value

            r++; // fast pointer == just for-loop cycle counter
        }

        return l+1; // l is a position, length of resulting array is l+1 because the position starts from zero
    }

    public static void Main()
    {
        var sol = new Solution();        
        sol.Assert([], []);
        sol.Assert([1],[1]);

    // Input: nums = [1,1,2]
    // Output: 2, nums = [1,2,_]
    // Explanation: Your function should return k = 2,
    //  with the first two elements of nums being 1 and 2 respectively.
    // It does not matter what you leave beyond the returned k (hence they are underscores).
        sol.Assert([1,1,2], [1,2]);

    // Input: nums = [0,0,1,1,1,2,2,3,3,4]
    // Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
    // Explanation: Your function should return k = 5,
    //  with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
    // It does not matter what you leave beyond the returned k (hence they are underscores).
        sol.Assert([0,0,1,1,1,2,2,3,3,4], [0,1,2,3,4]);

        Console.WriteLine("Tests passed!");
    }

    /// <param name="nums">Input array</param>
    /// <param name="expectedNums">The expected answer with correct length</param>
    private void Assert(int[] nums, int[] expectedNums)
    {
        int k = RemoveDuplicates(nums);

        Debug.Assert(k == expectedNums.Length);
        for (int i = 0; i < k; i++) {
            Debug.Assert( nums[i] == expectedNums[i], $"i : {i}");
        }
    }
}