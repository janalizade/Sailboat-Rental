﻿namespace SailBoat_Rental.Service.Calculator
{
    //Dinghy: basic fee + hourly rate * number of hours
    public class DinghyCalculator : AbstractCalculator
    {
      
        public override double Calculate(CalculatorArgs args)
        {
            return args.BasicFee + args.HourlyRate * base.getNumberOfHours(args);
        }
    }
}
