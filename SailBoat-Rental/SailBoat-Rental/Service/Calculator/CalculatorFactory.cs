namespace SailBoat_Rental.Service.Calculator
{
    public class CalculatorFactory
    {
        public AbstractCalculator GetCalculator(String category)
        {
            switch (category)
            {
                case "Dinghy":
                    return new DinghyCalculator();
                case "SmallBoat":
                    return new SmallBoatCalculator();
                case "LargeBoat":
                    return new LargeBoatCalculator();
                default:
                    throw new ArgumentException(category + " not supported"); 
            }
        }
    }

   

}
