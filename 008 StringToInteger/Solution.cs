
using System.Diagnostics;

public class Solution {
    /*
    1 Whitespace: Ignore any leading whitespace (" ").

    2 Signedness: Determine the sign by checking if the next character is '-' or '+',
        assuming positivity if neither present.

    3 Conversion: Read the integer by skipping leading zeros
        until a non-digit character is encountered or the end of the string is reached.
        If no digits were read, then the result is 0.

    4 Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1],
        then round the integer to remain in the range.
        Specifically, integers less than -2^31 should be rounded to -2^31,
        and integers greater than 2^31 - 1 should be rounded to 2^31 - 1.

    Return the integer as the final result.
    */
    public int MyAtoi(string s) {        
        if(s.Length is 0) return 0;

        int l = TrimLeft(s);
        int sign = GetSign(s, ref l);
        int result = PrecalculateResult(s, l, sign);

        return result * sign;
    }

    private int TrimLeft(string s) // "   abc"
    {
        int l=0;
        while(l < s.Length && s[l]==' ') l++;
        return l;
    }
    private int GetSign(string s, ref int l)
    {
        int sign = 1; // we will multiply to it
        if(l < s.Length && s[l]=='-') { sign = -1; l++; }
        else
            if(l < s.Length && s[l]=='+') { sign = 1; l++; }
        return sign;
    }
    private int PrecalculateResult(string s, int l, int sign)
    {
        long result = 0L;
        while(l<s.Length && char.IsDigit(s[l]))
        {
            char ch = s[l];
            int dig = ch - '0';
            //---- validation BEFORE adding to avoid long overflow on result calculation
            long limit = sign == 1 ? int.MaxValue : -(long)int.MinValue;
            // overflow happens when:
            //  result*10 + dig > limit
            //  result*10       > limit - dig
            //  result          > (limit - dig) / 10 
            //----
            if(result > (limit - dig) / 10)
            {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result*10 + dig; // main equation
            l++;
        }
        return (int)result;
    }

    public static void Main()
    {
        var sol = new Solution();

        sol.Assert("-21474836482", -2147483648);
        sol.Assert("9223372036854775808", int.MaxValue);
        sol.Assert("-+12", 0);
        sol.Assert(" ", 0);
        sol.Assert("42", 42);
        sol.Assert(" 42", 42);
        sol.Assert(" -042", -42);
        sol.Assert("   -042", -42);
        sol.Assert("1337c0d3", 1337); 
        sol.Assert("0-1", 0); 
        sol.Assert("words and 987", 0);
        sol.Assert(" 3000000000abc", int.MaxValue); // 2147483647
        sol.Assert("-3000000000bca", int.MinValue); // -2147483648
        sol.Assert("  0000000000012345678", 12345678);
        sol.Assert("  +0000000000012345678", 12345678);

        Console.WriteLine("Tests passed!");
    }

    private void Assert(string s, int expected)
    {
        var actual = MyAtoi(s);
        Debug.Assert(actual == expected, $"actual {actual}, expexted {expected}");
    }
}
