using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace MyCalculator.UnitTests
{
    [TestClass]
    public class CalculatorMinusTests
    {
        ClassCalculator CC = new ClassCalculator();

        [TestMethod]
        public void CanCalculate_Subtraction_CorrectlyCalculatesIntegers()
        {
            // Arrange
            CC.tal1 = "10";
            CC.tal2 = "5";
            double finalRes = 5;

            // Act
            double res = CC.CalcResMinus();

            // Assert
            Assert.AreEqual(finalRes, res);
        }

        [TestMethod]
        public void CanCalculate_Subtraction_CorrectlyCalculatesDoubles()
        {
            // Arrange
            CC.tal1 = "33,4";
            CC.tal2 = "66,9";
            double finalRes = -33.5D;

            // Act
            double res = CC.CalcResMinus();

            // Assert
            Assert.AreEqual(finalRes, res, 0.00001);
        }
    }
}
