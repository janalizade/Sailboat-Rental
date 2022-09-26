namespace SailBoat_Rental.Service.Calculator
{
    public abstract class AbstractCalculator
    {
        public abstract double Calculate(CalculatorArgs args);

        protected int getNumberOfHours(CalculatorArgs args)
        {
            var fromDate = args.FromDate;
            var toDate = args.ToDate;

            //     A signed number indicating the relative values of t1 and t2.
            //     Value Type – Condition
            //     Less than zero –t1 is earlier than t2.
            //     Zero –t1 is the same as t2.
            //     Greater than zero –t1 is later than t2.

            if (DateTime.Compare(fromDate, toDate) > 0)
            {
                var swapDate = fromDate;
                fromDate = toDate;
                toDate = swapDate;
            }

            var timeSpan = toDate.Subtract(fromDate);
            return timeSpan.Minutes > 0 ? timeSpan.Hours + 1 : timeSpan.Hours;
        }

    }
}
