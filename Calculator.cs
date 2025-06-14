using System.Diagnostics.Metrics;
using System.Security.Policy;

static class Calculator
{
    static string operands =  "0123456789,";
    static string operators = "+-*/^";
    static string third = "SCTLR";
    static string second = "*/^";
    static string first = "+-";
    static string functions = "SCTLR";
    static public string Analyze(string expression)
    {
        Queue<string> postfix = new Queue<string>();
        Stack<string> stack = new Stack<string>();
        string temp = "";
        try
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (operands.Contains(expression[i]))
                {
                    bool end = false;
                    temp += expression[i];
                    i++;
                    if (i == expression.Length)
                    {
                        postfix.Enqueue(temp);
                        break;
                    }
                    while (operands.Contains(expression[i]))
                    {
                        temp += expression[i];
                        if (i == expression.Length - 1)
                        {
                            end = true;
                            break;
                        }
                        i++;
                    }
                    if (!end)
                        i--;
                    postfix.Enqueue(temp);
                    temp = "";
                }
                else if (functions.Contains(expression[i]) || operators.Contains(expression[i]))
                {
                    int priority1 = Priority(Convert.ToString(expression[i])), priority2;

                    string check;
                    while (true)
                    {
                        if (stack.Count > 0)
                        {
                            check = stack.ElementAt(0);
                            priority2 = Priority(check);
                            if (priority2 >= priority1)
                            {
                                postfix.Enqueue(stack.Pop());
                            }
                            else
                            {
                                stack.Push(Convert.ToString(expression[i]));
                                break;
                            }
                        }
                        else
                        {
                            stack.Push(Convert.ToString(expression[i]));
                            break;
                        }
                    }
                }
                else if (expression[i] == '(')
                {
                    stack.Push(Convert.ToString(expression[i]));
                }
                else if (expression[i] == ')')
                {
                    while (stack.ElementAt(0) != "(")
                    {
                        postfix.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        if (functions.Contains(stack.ElementAt(0)))
                        {
                            postfix.Enqueue(stack.Pop());
                        }
                    }
                }
            }

            while (stack.Count > 0)
            {
                postfix.Enqueue(stack.Pop());
            }

            string output = "", element;
            while (postfix.Count > 0)
            {
                string a, b;
                element = postfix.Dequeue();
                if (operators.Contains(element))
                {
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(Calculation(a, element, b));
                }
                else if (functions.Contains(element))
                {
                    a = stack.Pop();
                    stack.Push(Function(element, a));
                }
                else
                {
                    stack.Push(element);
                }
            }
            return stack.Pop();
        }
        catch (Exception)
        {
            return "---";
        }        
    }
    static int Priority(string symbol)
    {
        if (first.Contains(symbol))
        {
            return 1;
        }
        else if (second.Contains(symbol))
        {
            return 2;
        }
        else if (third.Contains(symbol))
        {
            return 3;
        }
        return 0;
    }
    static public string Calculation(string first, string operation, string second)
    {
        double a = Convert.ToDouble(first);
        double b = Convert.ToDouble(second);
        switch (operation)
        {
            case "+":
                a = a + b;
                break;
            case "-":
                a = a - b;
                break;
            case "*":
                a = a * b;
                break;
            case "/":
                a = a / b;
                break;
            case "^":
                a = Math.Pow(a, b);
                break;
            default:
                break;
        }
        return Convert.ToString(a);
    }
    static public string Function(string function, string variable)
    {
        double x = Convert.ToDouble(variable);
        switch (function)
        {
            case "S":
                x = Math.Sin(x);
                break;
            case "C":
                x = Math.Cos(x);
                break;
            case "T":
                x = Math.Tan(x);
                break;
            case "L":
                x = Math.Log(x);
                break;
            case "R":
                x = Math.Sqrt(x);
                break;
            default:
                break;
        }
        return Convert.ToString(x);
    }
}
