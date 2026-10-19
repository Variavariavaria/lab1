using System;
using Xunit;

public class MatrixSumTests
{
    public double MatrixSum(double[,] matrix, int X1, int Y1, int X2, int Y2)
    {
        double sum = 0;
        for (int i = X1; i <= X2; i++)
        {
            for (int j = Y1; j <= Y2; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    [Fact]
    public void Sum_SingleElement_ReturnsThatElement()
    {
        var matrix = new double[,] { { 5.0 } };
        Assert.Equal(5.0, MatrixSum(matrix, 0, 0, 0, 0));
    }

    [Fact]
    public void Sum_Error()
    {
        var matrix = new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        //3+6 = 9, не 7, будет ошибка
        Assert.Equal(7.0, MatrixSum(matrix, 0, 2, 1, 2));
    }

    [Fact]
    public void Sum_Negatives()
    {
        var matrix = new double[,]
        {
            { -1, -2 },
            { -3, -4 }
        };
        Assert.Equal(-10.0, MatrixSum(matrix, 0, 0, 1, 1));
    }

    [Fact]
    public void Sum_MakingASquare()
    {
        var matrix = new double[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        // 1 + 2 + 5 + 6 = 14
        Assert.Equal(14.0, MatrixSum(matrix, 0, 0, 1, 1));
    }

    [Fact]
    public void Sum_AllZero()
    {
        var matrix = new double[3, 3];
        Assert.Equal(0.0, MatrixSum(matrix, 0, 0, 2, 2)); //нолики хихииихихх
    }

    [Fact]
    public void Sum_TooBig()
    {
        var matrix = new double[,] { { 1, 2 }, { 3, 4 } };
        Assert.Throws<IndexOutOfRangeException>(() => MatrixSum(matrix, 0, 0, 2, 1));
    }
}