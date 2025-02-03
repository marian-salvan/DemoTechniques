namespace DemoTechniques.Strategies
{
    public class MultiplicationCalculationStrategy : ICalculationStrategy
    {
        public CalculationType CalculationType => CalculationType.MULTIPLICATION;

        public double Calculate(double a, double b) => a * b;
    }
}
