namespace SailBoat_Rental.Service.Calculator
{

    //Boat >= 40: feet basic fee* 1.5 + hourly rate* 1.4 * number hours


    public class LargeBoatCalculator : AbstractCalculator
    {
        public override double Calculate(CalculatorArgs args)
        {
            if (args is null)
            {
                throw new ArgumentException("args is null");
            }
            return (args.BasicFee * 1.5d) + (args.HourlyRate * 1.4d * base.getNumberOfHours(args));
        }
    }
}
