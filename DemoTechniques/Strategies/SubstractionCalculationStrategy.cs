namespace DemoTechniques.Strategies
{
    public class SubstractionCalculationStrategy : ICalculationStrategy
    {
        public CalculationType CalculationType => CalculationType.SUBSTRACTION;

        public double Calculate(double a, double b) => a - b;
    }
}
