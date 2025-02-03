namespace DemoTechniques.Strategies
{
    public class SubstractionCalculationStrategy : ICalculationStrategy
    {
        public OperationType OperationType => OperationType.SUBSTRACTION;

        public double Calculate(double a, double b) => a - b;
    }
}
