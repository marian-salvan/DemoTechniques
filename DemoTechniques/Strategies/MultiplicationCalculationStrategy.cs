namespace DemoTechniques.Strategies
{
    public class MultiplicationCalculationStrategy : ICalculationStrategy
    {
        public OperationType OperationType => OperationType.MULTIPLICATION;

        public double Calculate(double a, double b) => a * b;
    }
}
