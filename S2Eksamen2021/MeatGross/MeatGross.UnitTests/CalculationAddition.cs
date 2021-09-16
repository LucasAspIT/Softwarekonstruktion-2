using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace MeatGross.UnitTests
{
    [TestClass]
    public class CalculationAddition
    {
        ClassBIZ BIZ = new ClassBIZ();

        [TestMethod]
        public void CanCalculate_Addition_CorrectlyCalculateIntegers()
        {
            // Arrange
            BIZ.Number1 = 55;
            BIZ.Number2 = 45;
            int finalRes = 100;

            // Act
            double res = BIZ.CalcResAddition();

            // Assert
            Assert.AreEqual(finalRes, res, 0.0000);
        }
    }
}