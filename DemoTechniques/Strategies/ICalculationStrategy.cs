namespace DemoTechniques.Strategies
{
    public interface ICalculationStrategy
    {
        public CalculationType CalculationType { get; }
        public double Calculate(double a, double b);
    }
}
