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
        [Fact]
        public void CalculatorsTest()
        {
            var factory = new CalculatorFactory();
            
            var actualCalculator = factory.GetCalculator("Dinghy");
            NUnit.Framework.Assert.AreEqual(typeof(DinghyCalculator), actualCalculator.GetType());

            actualCalculator = factory.GetCalculator("SmallBoat");
            NUnit.Framework.Assert.AreEqual(typeof(SmallBoatCalculator), actualCalculator.GetType());

            actualCalculator = factory.GetCalculator("LargeBoat");
            NUnit.Framework.Assert.AreEqual(typeof(LargeBoatCalculator), actualCalculator.GetType());

            var thrown = Assert.Throws<ArgumentException>(() => factory.GetCalculator("NOT_SUPPROTED_CATEGORY"));
            NUnit.Framework.Assert.AreEqual("NOT_SUPPROTED_CATEGORY category is not supported", thrown.Message);
        }
    }
}
