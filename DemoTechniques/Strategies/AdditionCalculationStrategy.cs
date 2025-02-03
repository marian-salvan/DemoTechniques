namespace DemoTechniques.Strategies
{
    public class AdditionCalculationStrategy : ICalculationStrategy
    {
        public OperationType OperationType => OperationType.ADDITION;

        public double Calculate(double a, double b) => a + b;
    }
}
