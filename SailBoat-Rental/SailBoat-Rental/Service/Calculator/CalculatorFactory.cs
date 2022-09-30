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
                case "Catamaren":
                    return new SmallBoatCalculator();
                case "Trimaran":
                    return new LargeBoatCalculator();
                default:
                    throw new ArgumentException(category + " category is not supported"); 
            }
        }
    }

   

}
