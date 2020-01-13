using System;
using Building.Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test
{

    [TestClass]
    public class TestPriceCalculator
    {
        [TestMethod]
        public void TestWorkCalculationShouldBeCalculateCorrect()
        {
            var calculator = new WindowPriceCalculator();

            decimal unitofwork = 4m;
            decimal workperhour = 5m;
            decimal costwork = 12m;
            decimal expectedresult = 22.4m;
            decimal actualresult = (unitofwork * workperhour) + ((unitofwork * workperhour) * costwork / 100);
            calculator.CalculateWork();
            Assert.AreEqual(actualresult,expectedresult);
        
        }  
        
    }
}
