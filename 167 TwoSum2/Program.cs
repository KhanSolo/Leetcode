using System;
using System.Diagnostics;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target) {
        if (numbers.Length < 2) return [];
        int l = 0;
        int r = numbers.Length - 1;

        while (l < r)
        {
            var sum = numbers[l] + numbers[r];
            if (sum == target) return [l+1,r+1]; // count from 1            
            if (sum > target) r--; else l++;
        }

        return [];
    }

    public static void Main()
    {
        var sol = new Solution();
        {
            // Input: numbers = [2,7,11,15], target = 9
            // Output: [1,2]
            // Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
            var res = sol.TwoSum([2,7,11,15], 9);
            Debug.Assert(res[0] == 1);
            Debug.Assert(res[1] == 2);
        }

        {
            // Input: numbers = [2,3,4], target = 6
            // Output: [1,3]
            // Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
            var res = sol.TwoSum([2,3,4], 6);
            Debug.Assert(res[0] == 1);
            Debug.Assert(res[1] == 3);
        }

        {
            // Input: numbers = [-1,0], target = -1
            // Output: [1,2]
            // Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
            var res = sol.TwoSum([-1,0], -1);
            Debug.Assert(res[0] == 1);
            Debug.Assert(res[1] == 2);
        }
    }
}