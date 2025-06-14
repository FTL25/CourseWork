 class NeuralNetwork
{
    //string[] classes = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "e", "p", "+", "-", "d", "x", "A",
    //                    "(", ")", "S", "C", "T", "L"};
    string[] classes;
    Layer InputLayer;
    Layer HiddenLayer;
    //Layer HiddenLayer2;
    double[][] Out;
    int InputSize;
    int HiddenSize;
    int OutputSize;
    public string[] Classes
    {
        get { return classes; }
    }

    public int OutSize
    {
        get { return OutputSize; }  
    }

    public Layer FirstLayer
    {
        get { return InputLayer;  }
    }
    public NeuralNetwork(int _InputSize, int _HiddenSize, int _OutputSize, double LearningRate)
    {
        InputSize = _InputSize;
        HiddenSize = _HiddenSize;
        OutputSize = _OutputSize;
        classes = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "x", "d", "^", "(", ")" };
        InputLayer = new Layer(InputSize, HiddenSize, LearningRate);
        HiddenLayer = new Layer(HiddenSize, OutputSize, LearningRate);
        //HiddenLayer2 = new Layer(HiddenSize, OutputSize, LearningRate);
        Out = new double[1][];
        Out[0] = new double[OutputSize];
    }
    public void Activation()
    {
        HiddenLayer.N = InputLayer.Activation();
        //HiddenLayer2.N = HiddenLayer.Activation();
        Out = HiddenLayer.Activation();
        Out[0] = Functions.SoftMax(Out[0]);
    }
    public double[] Probabilities()
    {
        return Out[0];
    }
    public string Answer()
    {
        double max = Out[0].Max();
        int index = 0;
        for (int i = 0; i < Out[0].Length; i++)
        {
            if (Out[0][i] == max)
                index = i;
        }
        if (index == 12)
            return "*";
        else if (index == 13)
            return "/";
        return classes[index];
    }
    public void GradientDescent(double[][] dE)
    {
        //double[][] dEdX3 = HiddenLayer2.GradientDescent(dE, true);
        double[][] dEdX2 = HiddenLayer.GradientDescent(dE, true);
        double[][] dEdX1 = InputLayer.GradientDescent(dEdX2);
    }
    public double[] dError(string name)
    {
        double[] right = new double[classes.Length];
        for (int i = 0; i < classes.Length; i++)
        {
            if (classes[i] == name)
                right[i] = 1;
            else
                right[i] = 0;
        }
        double[] answer = Out[0];

        return Functions.dCrossEntropy(answer, right);
    }
    public void SaveWeights()
    {
        FileStream file = new FileStream("Веса для входного слоя.txt", FileMode.Create);
        file.Close();
        file = new FileStream("Веса для скрытого слоя.txt", FileMode.Create);
        file.Close();
        //file = new FileStream("Веса для второго скрытого слоя.txt", FileMode.Create);
        //file.Close();
        InputLayer.SaveWeights("входного");
        HiddenLayer.SaveWeights("скрытого");
        //HiddenLayer2.SaveWeights("второго скрытого");
    }
    public void LoadWeights()
    {
        InputLayer.LoadWeights("Веса для входного слоя.txt");
        HiddenLayer.LoadWeights("Веса для скрытого слоя.txt");
        //HiddenLayer2.LoadWeights("Веса для второго скрытого слоя.txt");
    }
    public void LearningRate(double rate)
    {
        InputLayer.LearningRate(rate);
        HiddenLayer.LearningRate(rate);
        //HiddenLayer2.LearningRate(rate);
    }
}