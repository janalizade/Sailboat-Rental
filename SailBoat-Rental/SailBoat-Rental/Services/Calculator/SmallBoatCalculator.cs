namespace SailBoat_Rental.Services.Calculator
{

    //Boat<40 feet:   basic fee* 1.2 + hourly rate* 1.3 * number hours


    public class SmallBoatCalculator : AbstractCalculator
    {
        public override float Calculate(CalculatorArgs args)
        {
            return args.BasicFee * 1.2f + args.HourlyRate * 1.3f * base.getNumberOfHours(args);
        }
    }
}
