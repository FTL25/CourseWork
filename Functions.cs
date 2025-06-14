static class Functions
{

    static public double[] SoftMax(double[] x)
    {
        double[] y = new double[x.Length];
        double sum;
        for (int i = 0; i < y.Length; i++)
        {
            sum = 0;
            for (int k = 0; k < x.Length; k++)
            {
                sum += Math.Exp(x[k]);
            }
            y[i] = Math.Exp(x[i]) / sum;

        }
        return y;
    }
    static public double[][] dSoftMax(double[] x)
    {
        double[][] y = new double[1][];
        y[0] = new double[x.Length];
        double[] S = SoftMax(x);
        for (int i = 0; i < x.Length; i++)
        {
            y[0][i] = S[i] - S[i] * S[i];
        }
        return y;
    }
    static public double Error(double[] x, double[] y)
    {
        double sum = 0;
        for (int i = 0; i < x.Length; i++)
        {
            sum += (x[i] - y[i]) * (x[i] - y[i]);
        }
        return sum;
    }
    static public double[][] dError(double[] x, double[] y)
    {
        double[][] dE = new double[1][];
        dE[0] = new double[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            dE[0][i] = 2 * (x[i] - y[i]);
        }
        return dE;
    }
    static public double CrossEntropy(double[] x, double[] y)
    {
        double E = 0;
        for (int i = 0; i < x.Length; i++)
        {
            E += y[i] * Math.Log(x[i]);
        }
        return -E;
    }
    static public double[] dCrossEntropy(double[] x, double[] y)
    {
        double[] E = new double [x.Length];
        for (int i = 0; i < E.Length; i++)
            E[i] = x[i] - y[i];
        return E;
    }
    static public double[][] PRELU(double[][] x)
    {
        double[][] y = new double[x.Length][];
        for (int i = 0; i < y.Length; i++)
        {
            y[i] = new double[x[0].Length];
        }
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < x[0].Length; j++)
            {
                if (x[i][j] >= 0)
                    y[i][j] = x[i][j];
                else
                    y[i][j] = 0.01 * x[i][j];
            }
        }
        return y;
    }
    static public double[][] dPRELU(double[][] x)
    {
        double[][] y = new double[x.Length][];
        for (int i = 0; i < y.Length; i++)
        {
            y[i] = new double[x[0].Length];
        }
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < x[0].Length; j++)
            {
                if (x[i][j] >= 0)
                    y[i][j] = 1;
                else
                    y[i][j] = 0.1;
            }
        }
        return y;
    }
}