namespace SailBoat_Rental.Service.Calculator
{
    //Dinghy: basic fee + hourly rate * number of hours
    public class DinghyCalculator : AbstractCalculator
    {
      
        public override double Calculate(CalculatorArgs args)
        {
            if (args is null)
            {
                throw new ArgumentException("args is null");
            }
            return args.BasicFee + (args.HourlyRate * base.getNumberOfHours(args));
        }
    }
}
