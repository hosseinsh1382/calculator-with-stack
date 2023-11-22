using Calculator.Exception;
using Calculator.Model;

namespace Calculator.Repository;

public class Postix(MyStack<char> operators, MyStack<char> tempOperators) : IPostix
{
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
                    operators.Push(i);
                    break;
                case ')':
                    postfix += tempNumber + " ";
                    tempNumber = "";
                    while (operators.Size > 0 && operators.Peek() != "(")
                        postfix = postfix + operators.Pop() + " ";
                    if ((operators.Size > 0 && operators.Peek() != "(") || operators.Size == 0)
                        throw new InvalidExpressionException();
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '!':
                    postfix += tempNumber + " ";
                    tempNumber = "";
                    while (Priority(Convert.ToChar(operators.Peek())) > Priority(i))
                        tempOperators.Push(Convert.ToChar(operators.Pop()));
                    operators.Push(i);
                    while (tempOperators.Size > 0)
                        operators.Push(Convert.ToChar(tempOperators.Pop()));
                    break;
                default:
                    tempNumber += i;
                    break;
            }
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