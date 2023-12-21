namespace Calculator.Repository;

public interface ICalculationRepository
{
    double Add(double number1, double number2);
    double Subtract(double number1, double number2);
    double Product(double number1, double number2);
    double Divide(double number1, double number2);
    double Power(double number1, int number2);
    int Factorial(int number);

    double Calculate(string infix);
}
