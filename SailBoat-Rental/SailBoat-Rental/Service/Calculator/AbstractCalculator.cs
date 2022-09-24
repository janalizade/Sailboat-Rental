namespace SailBoat_Rental.Service.Calculator
{
    public abstract class AbstractCalculator
    {
        public abstract double Calculate(CalculatorArgs args);


       protected int getNumberOfHours(CalculatorArgs args)
        {
            TimeSpan diff = args.FromDate.Subtract(args.FromDate);
            int finalDiff;
            if (diff.Minutes > 0) { finalDiff = diff.Hours + 1; } else { finalDiff = diff.Hours; }
                
            return   finalDiff;
        }

    }
}
