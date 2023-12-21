using Calculator.Exception;
using Calculator.Model;

namespace Calculator.Repository;

public class Postfix : IPostfix
{
    public MyStack<char> TempOperators { get; } = new();
    public MyStack<char> Operators { get; } = new();

    public string ConvertToPostfix(string infix)
    {
        var postfix = "";
        var tempNumber = "";
        foreach (var i in infix)
        {
            switch (i)
            {
                case '(':
                    postfix = postfix + tempNumber + " ";
                    Operators.Push(i);
                    break;
                case ')':
                    postfix += tempNumber + " ";
                    tempNumber = "";
                    while (Operators.Size > 0 && Operators.Peek() != "(")
                        postfix = postfix + " " + Operators.Pop();
                    if ((Operators.Size > 0 && Operators.Peek() != "(") || Operators.Size == 0)
                        throw new InvalidExpressionException();
                    Operators.Pop();
                    break;
                case 'p':
                    postfix += tempNumber + " ";
                    tempNumber = "";
                    postfix += 3.14;
                    break;
                case 'e':
                    postfix += 2.71;
                    break;
                case '+':
                case '*':
                case '/':
                case '^':
                case '!':
                    postfix += tempNumber + " ";
                    tempNumber = "";
                    while (Priority(Convert.ToChar(Operators.Peek())) > Priority(i))
                        TempOperators.Push(Convert.ToChar(Operators.Pop()));
                    Operators.Push(i);
                    while (TempOperators.Size > 0)
                        Operators.Push(Convert.ToChar(TempOperators.Pop()));
                    break;
                default:
                    tempNumber += i;
                    break;
            }
        }

        postfix += tempNumber + " ";
        while (Operators.Size > 0)
        {
            postfix += " " + Operators.Pop();
        }

        return postfix;
    }

    private static int Priority(char ch)
    {
        switch (ch)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            case '^':
                return 3;
            case '!':
                return 4;
        }

        return -1;
    }
}