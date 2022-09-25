using SailBoat_Rental.Service.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sailboat_Test
{
    public class CalculatorFactoryTest
    {
        private CalculatorFactory factory = new CalculatorFactory();

        [Fact]
        public void CalculatorsTest()
        {
            var actualCalculator = factory.GetCalculator("Dinghy");
            NUnit.Framework.Assert.AreEqual(typeof(DinghyCalculator), actualCalculator.GetType());

            actualCalculator = factory.GetCalculator("SmallBoat");
            NUnit.Framework.Assert.AreEqual(typeof(SmallBoatCalculator), actualCalculator.GetType());

            actualCalculator = factory.GetCalculator("LargeBoat");
            NUnit.Framework.Assert.AreEqual(typeof(LargeBoatCalculator), actualCalculator.GetType());
        }
    }
}
