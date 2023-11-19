namespace Calculator.Repository;

public class CalculationRepository : ICalculationRepository
{
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