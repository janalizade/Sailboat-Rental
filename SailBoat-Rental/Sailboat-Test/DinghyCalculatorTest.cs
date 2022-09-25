using SailBoat_Rental.Service.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
namespace Sailboat_Test
{
    public class DinghyCalculatorTest
    {
        AbstractCalculator calculator = new DinghyCalculator();
        
        [Fact]
        public void DinghyHappyOneHourTest()
        {
            var fromDate = DateTime.Now;
            var toDate = fromDate.AddHours(1);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, fromDate, toDate));
            NUnit.Framework.Assert.AreEqual(400d, actualPrice);
        }

        [Fact]
        public void DinghyHappyOneHourAndTenMinutesTest()
        {
            var fromDate = DateTime.Now;
            var toDate = fromDate.AddHours(1);
            toDate = toDate.AddMinutes(10);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, fromDate, toDate));
            NUnit.Framework.Assert.AreEqual(500d, actualPrice);
        }

        [Fact]
        public void DinghyHappyOneHourDatesSwapTest()
        {
            var fromDate = DateTime.Now;
            var toDate = fromDate.AddHours(1);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, toDate, fromDate));
            NUnit.Framework.Assert.AreEqual(400d, actualPrice);
        }

        [Fact]
        public void DinghyHappyOneHourAndTenDateMinutesDatesSwapTest()
        {
            var fromDate = DateTime.Now;
            var toDate = fromDate.AddHours(1);
            toDate = toDate.AddMinutes(10);
            var actualPrice = calculator.Calculate(new CalculatorArgs(300d, 100d, toDate, fromDate));
            NUnit.Framework.Assert.AreEqual(500d, actualPrice);
        }
    }
}
