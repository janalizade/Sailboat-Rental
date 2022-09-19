namespace SailBoat_Rental.Service.Calculator
{

    
    public class CalculatorArgs
    {
        public float BasicFee { get; set; }
        public float HourlyRate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public CalculatorArgs(float basicFee, float hourlyRate, DateTime fromDate, DateTime toDate)
        {
            BasicFee = basicFee;
            HourlyRate = hourlyRate;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
