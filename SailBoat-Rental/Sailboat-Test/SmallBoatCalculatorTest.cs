
using SailBoat_Rental.Service.Calculator;
using Assert = NUnit.Framework.Assert;
namespace Sailboat_Test
{
    public class SmallBoatCalculatorTest
    {
        private AbstractCalculator calculator = new SmallBoatCalculator();
        private DateTime fromDate = DateTime.Now;

        [Fact]
        public void SmallBoatHappyOneHourTest()
        {
            var toDate = fromDate.AddHours(1);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, fromDate, toDate));
            NUnit.Framework.Assert.AreEqual(490, actualPrice);
        }

        [Fact]
        public void SmallBoatHappyOneHourAndTenMinutesTest()
        {
            var toDate = fromDate.AddHours(1);
            toDate = toDate.AddMinutes(10);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, fromDate, toDate));
            NUnit.Framework.Assert.AreEqual(620d, actualPrice);
        }

        [Fact]
        public void SmallBoatHappyOneHourAndOneMinutesTest()
        {
            var toDate = fromDate.AddHours(1);
            toDate = toDate.AddMinutes(1);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, fromDate, toDate));
            NUnit.Framework.Assert.AreEqual(620d, actualPrice);
        }

        [Fact]
        public void SmallBoatUnhappyTest()
        {
            var thrown = Assert.Throws<ArgumentException>(() => calculator.Calculate(null));
            NUnit.Framework.Assert.AreEqual("args is null", thrown.Message);
        }
    }
}