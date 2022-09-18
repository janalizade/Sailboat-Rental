namespace SailBoat_Rental.Services.Calculator
{
    public abstract class AbstractCalculator
    {
        public abstract float Calculate(CalculatorArgs args);


       protected TimeSpan getNumberOfHours(CalculatorArgs args)
        {
           return args.FromDate - args.ToDate;
        }

    }
}
