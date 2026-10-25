/*
    2 pointers
    O(n) complexity
    O(1) memory
*/

using System.Diagnostics;

public class Solution {
    public bool IsPalindrome(string s) {
        if(string.IsNullOrWhiteSpace(s) || s.Length < 2) return true;

        int l = 0;
        int r = s.Length - 1;

        while (l < r)
        {
            var ch1 = s[l];
            while (!char.IsLetterOrDigit(ch1))
            {
                l++;
                if(l>=r) return true;
                ch1 = s[l];
            }

            var ch2 = s[r];
            while (!char.IsLetterOrDigit(ch2))
            {
                r--;
                if(l>=r) return true;
                ch2 = s[r];
            }

            ch1 = char.ToLower(ch1);
            ch2 = char.ToLower(ch2);

            if (ch1 != ch2) return false;
            l++;
            r--;
        }

        return true;
    }

    public static void Main()
    {
        var sol = new Solution();
        {
            var s = "A man, a plan, a canal: Panama";
            Debug.Assert(sol.IsPalindrome(s));
            Console.WriteLine(s);
        }

        {
            var s = "race a car";
            Debug.Assert(!sol.IsPalindrome(s));
            Console.WriteLine(s);
        }

        {
            var s = " ";
            Debug.Assert(sol.IsPalindrome(s));
            Console.WriteLine(s);
        }
    }
}