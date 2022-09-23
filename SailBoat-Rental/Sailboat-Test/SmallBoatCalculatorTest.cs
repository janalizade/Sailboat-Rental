
using SailBoat_Rental.Service.Calculator;
using NUnit.Framework;
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
            var actualPrice = smallBoatCalculator.Calculate(new CalculatorArgs(12, 40, handOverDate, returnDate));
           NUnit.Framework.Assert.AreEqual(14.41f, actualPrice);

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