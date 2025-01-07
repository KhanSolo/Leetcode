public class Solution
 {
    public int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int,int>();
        for(var i = 0; i<nums.Length; ++i)
        {
            var cur = nums[i];
            var rest = target - cur;
            if(map.TryGetValue(rest, out var idx))
            {
                return new[] {i, idx};
            }
            else
            {
                map[cur] = i;
            }
        }
        return default;
    }
}