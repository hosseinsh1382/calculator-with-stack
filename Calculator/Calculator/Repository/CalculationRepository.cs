using System.Data;
using Calculator.Model;
using InvalidExpressionException = Calculator.Exception.InvalidExpressionException;

namespace Calculator.Repository;

public class CalculationRepository : ICalculationRepository
{
    private readonly IPostfix _postfix;
    public MyStack<double> Operands { get; } = new();

    public CalculationRepository(IPostfix postfix)
    {
        _postfix = postfix;
    }

    public double Calculate(string infix)
    {
        var operators = "+ - * / ^ !".Split(" ");
        var postfix = _postfix.ConvertToPostfix(infix).Split(" ");
        foreach (var n in postfix)
        {
            if (n == "")
                continue;
            if (!operators.Contains(n))
                Operands.Push(Convert.ToDouble(n));
            else if (Operands.Size == 1)
                throw new InvalidExpressionException();
            else
                switch (n)
                {
                    case "+":
                        Operands.Push(Add(Convert.ToDouble(Operands.Pop()), Convert.ToDouble(Operands.Pop())));
                        break;
                    case "-":
                        Operands.Push(Subtract(Convert.ToDouble(Operands.Pop()), Convert.ToDouble(Operands.Pop())));
                        break;
                    case "*":
                        Operands.Push(Product(Convert.ToDouble(Operands.Pop()), Convert.ToDouble(Operands.Pop())));
                        break;
                    case "/":
                        var temp = Operands.Pop();
                        Operands.Push(Divide(Convert.ToDouble(Operands.Pop()), Convert.ToDouble(temp)));
                        break;
                    case "^":
                        temp = Operands.Pop();
                        Operands.Push(Power(Convert.ToDouble(Operands.Pop()), Convert.ToInt32(temp)));
                        break;
                    case "!":
                        Operands.Push(Factorial(Convert.ToInt32(Operands.Pop())));
                        break;
                }
        }

        return Convert.ToDouble(Operands.Pop());
    }

    public double Add(double number1, double number2)
    {
        return number1 + number2;
    }

    public double Subtract(double number1, double number2)
    {
        return number1 - number2;
    }

    public double Product(double number1, double number2)
    {
        return number1 * number2;
    }

    public double Divide(double number1, double number2)
    {
        return number1 / number2;
    }

    public double Power(double number1, int number2)
    {
        return Math.Pow(number1, number2);
    }

    public int Factorial(int number)
    {
        if (number == 1)
            return 1;
        return number * Factorial(number - 1);
    }
}