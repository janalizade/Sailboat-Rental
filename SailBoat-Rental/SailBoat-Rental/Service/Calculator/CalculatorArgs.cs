namespace SailBoat_Rental.Service.Calculator
{

    
    public class CalculatorArgs
    {
        public double BasicFee { get; set; }
        public double HourlyRate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public CalculatorArgs(double basicFee, double hourlyRate, DateTime fromDate, DateTime toDate)
        {
            BasicFee = basicFee;
            HourlyRate = hourlyRate;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
