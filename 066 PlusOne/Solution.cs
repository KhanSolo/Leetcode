using System.Diagnostics;

public class Solution {
    public int[] PlusOne(int[] digits) {
        
		bool carry=true; // starting +1
		for(int i=digits.Length-1; i>-1; i--)
		{
			var res = carry ? digits[i] + 1 : digits[i];

			if(res >= 10)
			{
				carry = true;
				res %= 10;
			}
			else
				carry = false;

			digits[i] = res;
		}

		if (carry)
		{
			var newdigits = new int[digits.Length + 1];
			newdigits[0] = 1;
			for(int i=0; i<digits.Length; i++)			
				newdigits[i+1]=digits[i];			
			return newdigits;
		}

		return digits;
    }
	
	static void Main() {
		var sol = new Solution();
		sol.Assert([1,2,3], [1,2,4]);
		sol.Assert([4,3,2,1], [4,3,2,2]);
		sol.Assert([9], [1,0]);
		sol.Assert([1,2,3,4,5,6,7,8,9,9], [1,2,3,4,5,6,7,9,0,0]);
		Console.WriteLine("Tests passed!");
	}

	private void Assert(int[] digits, int[] expected)
	{
		var actual = PlusOne(digits);
		Debug.Assert(actual.Length == expected.Length);
		for(int i=0; i<actual.Length; i++)
		{
			Debug.Assert(actual[i]==expected[i], $"i: {i}");
		}
	}
}
