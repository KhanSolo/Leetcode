using System;
using System.Diagnostics;

public class Solution
{
    public int Reverse(int x) {
        const int LEN = 11; 
        Span<char> arr = stackalloc char[LEN];

        bool negative = x < 0;

        var pointer = 0;
        if(negative) {
            arr[0] = '-';
            pointer++;
        }

        // this allows to get Abs(x) without overflow 
        //  we cannot do Math.Abs(-2,147,483,648) because int32 cannot store  2,147,483,648          
        // -2,147,483,648 to 2,147,483,647
        // and also for the task condition we cannot use longer types
        var remainder = unchecked((uint)x);
        if(negative) remainder = unchecked(0u - remainder);

        do
        {            
            var cur = remainder % 10;
            arr[pointer] = (char)(cur + '0');
            pointer++;
            remainder /= 10;
        }
        while (remainder != 0);

        if(int.TryParse(arr, out var parsed))        
            return parsed;        
        else
            return 0;
    }
    
    public static void Main()
    {
        var sol = new Solution();
        sol.Assert(123, 321);
        sol.Assert(-123, -321);
        sol.Assert(120, 21);
        sol.Assert(1_147_483_647, 0);
        sol.Assert(-2_147_483_648, 0);

        Console.WriteLine("Tests passed!");
    }

    private void Assert(int x, int expected)
    {
        var actual = Reverse(x);
        Debug.Assert(actual == expected);
    }
}
