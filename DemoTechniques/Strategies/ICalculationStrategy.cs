namespace DemoTechniques.Strategies
{
    public interface ICalculationStrategy
    {
        public OperationType OperationType { get; }
        public double Calculate(double a, double b);
    }
}
