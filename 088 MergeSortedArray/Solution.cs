/*
    2 pointers
*/

using System.Diagnostics;

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int l = m-1;
        int r = n-1;
        int total = m + n - 1;
        while (l >= 0 && r >= 0)
        {
            if (nums1[l] > nums2[r])
            {
                nums1[total] = nums1[l];
                l--;
            } else
            {
                nums1[total] = nums2[r];
                r--;
            }
            total--;
        }

        // while(l >= 0) { do not copy to itself, leaving as is }

        while(r >= 0)
        {
            nums1[total] = nums2[r];
            r--;
            total--;
        }
    }

    public static void Main()
    {
        var sol = new Solution();
        
        // Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
        // Output: [1,2,2,3,5,6]
        // Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
        // The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
        sol.Assert([1,2,3,0,0,0], 3, [2,5,6], 3, [1,2,2,3,5,6]);

        // Input: nums1 = [1], m = 1, nums2 = [], n = 0
        // Output: [1]
        // Explanation: The arrays we are merging are [1] and [].
        // The result of the merge is [1].
        sol.Assert([1], 1, [], 0, [1]);

        // Input: nums1 = [0], m = 0, nums2 = [1], n = 1
        // Output: [1]
        // Explanation: The arrays we are merging are [] and [1].
        // The result of the merge is [1].
        // Note that because m = 0, there are no elements in nums1.
        // The 0 is only there to ensure the merge result can fit in nums1.
        sol.Assert([0], 0, [1], 1, [1]);
        
        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        Merge(nums1, m, nums2, n);
        Debug.Assert(nums1.Length == expected.Length);
        for(int i=0; i<expected.Length; ++i)
        {
            Debug.Assert(nums1[i] == expected[i], $"i: {i}");
        }
    }
}
