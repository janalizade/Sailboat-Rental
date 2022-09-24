
using SailBoat_Rental.Service.Calculator;
using Assert = NUnit.Framework.Assert;
namespace Sailboat_Test
{
    public class AbstractCalculatorTest
    {
        [Fact]
        public void SmallBoatSuccessTest()
        {
            var handOverDate = DateTime.Now;
            var returnDate = handOverDate.AddHours(1);

            AbstractCalculator smallBoatCalculator = new SmallBoatCalculator();
            var actualPrice = smallBoatCalculator.Calculate(new CalculatorArgs(2000, 400, handOverDate, returnDate));
           NUnit.Framework.Assert.AreEqual(2400.0d, actualPrice);

        }
        [Fact]
        public void SmallBoatNullTest()
        {
           

            var handOverDate = DateTime.Now;
            var returnDate = handOverDate.AddHours(1);
            
            AbstractCalculator smallBoatCalculator = new SmallBoatCalculator();
            var thrown = Assert.Throws<ArgumentException>(() => smallBoatCalculator.Calculate(null));
            NUnit.Framework.Assert.AreEqual("Value cannot be null. (Parameter 'args')", thrown.Message);

           

        }
    }
}