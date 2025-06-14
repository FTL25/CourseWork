class Layer
{
    int place = 0;
    double[][] Neurons;
    double[][] Weights;
    double[][] Bias;
    double[][] Results;
    double K;
    public Layer(int enter, int exit, double LearningRate)
    {
        K = LearningRate;

        Neurons = new double[1][];
        Neurons[0] = new double[enter];

        Weights = new double[enter][];
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] = new double[exit];
        }

        Bias = new double[1][];    
        Bias[0] = new double[exit];
        
        Results = new double[1][];
        Results[0] = new double[exit];

        for (int i = 0; i < Weights.Length; i++)
        {
            for (int j = 0; j < Weights[0].Length; j++)
            {
                Weights[i][j] = Random.Shared.NextDouble();
                if ((i + j) % 2 == 0)
                    Weights[i][j] = -Weights[i][j];
            }
        }
        for (int i = 0; i < Bias.Length; i++)
        {
            Bias[0][i] = Random.Shared.NextDouble();
        }
    }
    public double[][] N
    {
        get { return Neurons; }
        set { Neurons = value; }
    }
    public double[][] Activation(bool last = false)
    {
        double[][] Output = Matrix.Multiplication(Neurons, Weights);
        Output = Matrix.Addition(Output, Bias);
        Results = Output;
        if (!last)
        {
            Output = Functions.PRELU(Output);
        }
        return Output;
    }
    public double[][] GradientDescent(double[][] dE, bool last = false)
    {
        if (!last)
            dE = Matrix.Hadamard(Functions.dPRELU(Results), dE); // Производная функции активации

        Bias = Matrix.Subtraction(Bias, Matrix.Multiplication(K, dE)); // Исправление матрицы смещений
        double[][] WeightsT = Matrix.Transpose(Weights);

        double[][] doubles = Matrix.Multiplication(dE, WeightsT);

        double[][] NeuronsT = Matrix.Transpose(Neurons);
        double[][] DeltaWeights = Matrix.Multiplication(NeuronsT, dE);
        Weights = Matrix.Subtraction(Weights, Matrix.Multiplication(K, DeltaWeights)); // Исправление матрицы весов

        return doubles; // Градиент ошибки для предыдущего слоя
    }
    public void LearningRate(double rate)
    {
        K = rate;
    }
    public void SaveWeights(string type)
    {
        string path = "Веса для " + type + " слоя.txt";
        FileStream file = new FileStream(path, FileMode.Append);
        using (StreamWriter writer = new StreamWriter(file))
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                for (int j = 0; j < Weights[0].Length; j++)
                {
                    writer.WriteLine(Weights[i][j]);
                }
            }
            for (int i = 0; i < Bias[0].Length; i++)
            {
                writer.WriteLine(Bias[0][i]);
            }
        }
    }
    public void LoadWeights(string path)
    {
        FileStream file = new FileStream(path, FileMode.Open);
        using (StreamReader reader = new StreamReader(file))
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                for (int j = 0; j < Weights[0].Length; j++)
                {
                    Weights[i][j] = Convert.ToDouble(reader.ReadLine());
                }
            }
            for (int i = 0; i < Bias[0].Length; i++)
            {
                Bias[0][i] = Convert.ToDouble(reader.ReadLine());
            }
        }
    }
    public void Clear()
    {
        place = 0;
        for (int i = 0; i < Neurons.Length; i++)
        {
            for (int j = 0; j < Neurons[0].Length; j++)
            {
                Neurons[i][j] = 0;
            }
        }
    }
    public void Add(double activity)
    {
        Neurons[0][place] = activity;
        place++;
    }
}
