using System.Diagnostics;

public class Solution {
    public int LengthOfLastWord(string s) {
        int i = s.Length-1;
        while(s[i]==' ') {i--;}
        int len=0;
        while(i >= 0 && s[i]!=' ') {i--; len++;}
        return len;
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert("Hello World", 5);
        sol.Assert("   fly me   to   the moon  ", 4);
        sol.Assert("luffy is still joyboy", 6);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(string s, int expected)
    {
        var actual = LengthOfLastWord(s);
        Debug.Assert(actual == expected, $"actual: {actual}, expected: {expected}");
    }
}