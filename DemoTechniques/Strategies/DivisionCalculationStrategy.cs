namespace DemoTechniques.Strategies
{
    public class DivisionCalculationStrategy : ICalculationStrategy
    {
        public CalculationType CalculationType => CalculationType.DIVISION;
        public double Calculate(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by zero", nameof(b));
            }

            return a / b;
        }
    }
}
