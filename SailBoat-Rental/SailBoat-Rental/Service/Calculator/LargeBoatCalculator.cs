namespace SailBoat_Rental.Service.Calculator
{

    //Boat >= 40: feet basic fee* 1.5 + hourly rate* 1.4 * number hours


    public class LargeBoatCalculator : AbstractCalculator
    {
        public override float Calculate(CalculatorArgs args)
        {
            return args.BasicFee * 1.5f + args.HourlyRate * 1.4f * base.getNumberOfHours(args);
        }
    }
}
