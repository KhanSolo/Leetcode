
using System.Diagnostics;

public class Solution {
    public void SetZeroes(int[][] matrix) {

        bool cleanCol = false, cleanRow = false;

        // zero row, iterating by cols
        for(int row=0; row<matrix.Length; row++)
        {
            if(matrix[row][0] == 0)
            {
                cleanCol = true;
                break;
            }
        }
        // zero col, iterating by rows
        for(int col=0; col < matrix[0].Length; col++)
        {
            if (matrix[0][col] == 0)
            {
                cleanRow = true;
                break;
            }
        }        

        // Console.WriteLine("----------");
        // Write(matrix);
        // Console.WriteLine();

        // storing marks in zero col & row of what cells to set zero
        for(int row = 1; row < matrix.Length; row++)
        {
            var m = matrix[row];
            for(int col = 1; col < m.Length; col++)
            {
                if (matrix[row][col] == 0)
                {
                    matrix[0][col] = 0;
                    matrix[row][0] = 0;
                }
            }
        }

        // Write(matrix);
        // Console.WriteLine();

        // make cells zero considering the marks
        for(int row=1; row < matrix.Length; row++) // iterating by rows
        {
            var m = matrix[row];
            if(m[0] == 0)
            {
                for(var col=1; col<m.Length; col++) { m[col]=0; }
            }
        }
        // Write(matrix);
        // Console.WriteLine();
        var zeroRow = matrix[0];
        for(int col=1; col < zeroRow.Length; col++) // iterating by cols
        {
            if (zeroRow[col] == 0)
            {
                for(int row = 1; row < matrix.Length; row++)
                {
                    var r = matrix[row];
                    r[col]=0;
                }
            }
        }

        // finally clean zero col & row if needed
        if(cleanCol)
        {
            for(int row=0; row<matrix.Length; row++) matrix[row][0] = 0;
        }
        if(cleanRow)
        {
            var m=matrix[0];
            for(int col=0; col<m.Length; col++) m[col]=0;
        }

        //Write(matrix);
    }

    private static void Write(int[][] matrix)
    {
        for(int row = 0; row<matrix.Length; row++)
        {
            var m=matrix[row];
            for(int col=0; col<m.Length; col++)
            {
                // matrix[row][col]
                Console.Write($"{m[col]} ");
            }
            Console.WriteLine();
        }
    }

    public static void Main()
    {
        var sol = new Solution();
        sol.Assert(
            [
                [0,1,2,3,4,0],
                [3,4,5,6,0,3],
                [1,1,1,1,1,1],
                [2,3,4,5,6,7],
                [6,7,8,9,1,3],
            ],
            [
                [0,0,0,0,0,0],
                [0,0,0,0,0,0],
                [0,1,1,1,0,0],
                [0,3,4,5,0,0],
                [0,7,8,9,0,0],
            ]
        );
        sol.Assert([[1, 1, 1], [1, 0, 1], [1, 1, 1]],           [[1,0,1],[0,0,0],[1,0,1]]);
        sol.Assert([[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]],  [[0,0,0,0],[0,4,5,0],[0,3,1,0]]);
        sol.Assert([[0]], [[0]]);
        Console.WriteLine("Tests passed!");
    }

    private void Assert(int[][] input, int[][] expected)
    {
        SetZeroes(input);
        CompareEq(input, expected);
    }

    //Compare jagged arrays
    private void CompareEq(int[][] actual, int[][] expected)
    {
        Debug.Assert(actual.Length == expected.Length);
        for(int i=0; i<actual.Length; i++)
        {
            int[] a = actual[i];
            int[] e = expected[i];
            Debug.Assert(a.Length == e.Length);
            for (int j=0; j<a.Length; j++)
            {
                Debug.Assert(a[j] == e[j], $"i:{i}, j:{j}");
            }
        }
    }
}