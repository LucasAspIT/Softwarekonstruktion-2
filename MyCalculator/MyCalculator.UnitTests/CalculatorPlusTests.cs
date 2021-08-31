using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace MyCalculator.UnitTests
{
    [TestClass]
    public class CalculatorPlusTests
    {
        ClassCalculator CC = new ClassCalculator();

        [TestMethod]
        public void CanCalculate_Addition_ReturnsCalculatedIntegers()
        {
            // Arrange
            CC.tal1 = "55";
            CC.tal2 = "45";
            double finalRes = 100;

            // Act
            double res = CC.CalcResPlus();

            // Assert
            Assert.AreEqual(finalRes, res);
        }

        [TestMethod]
        public void CanCalculate_Addition_CorrectlyCalculatesDoubles()
        {
            // Arrange
            CC.tal1 = "33,4";
            CC.tal2 = "66,9";
            double finalRes = 100.3D;

            // Act
            double res = CC.CalcResPlus();

            // Assert
            Assert.AreEqual(finalRes, res, 0.00001);
        }
    }
}
