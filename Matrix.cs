static class Matrix
{
    static public double[][] Hadamard(double[][] a, double[][] b)
    {
        double[][] y = new double[1][];
        y[0] = new double[a[0].Length];
        for (int i = 0; i < y[0].Length; i++)
        {
            y[0][i] = a[0][i] * b[0][i];
        }
        return y;
    }
    static public double[][] Addition(double[][] a, double[][] b)
    {
        double[][] c = new double[a.Length][];
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = new double[b[0].Length];
        }
        for (int i = 0; i < c.Length; i++)
        {
            for (int j = 0; j < c[0].Length; j++)
            {
                c[i][j] = a[i][j] + b[i][j];
            }
        }
        return c;
    }
    static public double[][] Subtraction(double[][] a, double[][] b)
    {
        double[][] c = new double[a.Length][];
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = new double[b[0].Length];
        }
        for (int i = 0; i < c.Length; i++)
        {
            for (int j = 0; j < c[0].Length; j++)
            {
                c[i][j] = a[i][j] - b[i][j];
            }
        }
        return c;
    }
    static public double[][] Multiplication(double[][] a, double[][] b)
    {
        double[][] c = new double[a.Length][];
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = new double[b[0].Length];
        }

        double temp = 0;
        for (int i = 0; i < c.Length; i++)
        {
            for (int j = 0; j < c[0].Length; j++)
            {
                for (int k = 0; k < b.Length; k++)
                {
                    temp += a[i][k] * b[k][j];
                }
                c[i][j] = temp;
                temp = 0;
            }
        }

        return c;
    }
    static public double[][] Multiplication(double K, double[][] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a[0].Length; j++)
            {
                a[i][j] = K * a[i][j];
            }
        }
        return a;
    }
    static public double[][] Transpose(double[][] matrix)
    {
        double[][] matrixT = new double[matrix[0].Length][];
        for (int i = 0; i < matrixT.Length; i++)
        {
            matrixT[i] = new double[matrix.Length];
        }
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrixT[j][i] = matrix[i][j];
            }
        }
        return matrixT;
    }
}