using BIZ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.UnitTests
{
    [TestClass]
    public class CalculatorMultiplicationTests
    {
        ClassCalculator CC = new ClassCalculator();

        [TestMethod]
        public void CanCalculate_Multiplication_CorrectlyCalculatesIntegers()
        {
            // Arrange
            CC.tal1 = "27";
            CC.tal2 = "88";
            double finalRes = 2376D;

            // Act
            double res = CC.CalcResGange();

            // Assert
            Assert.AreEqual(finalRes, res);
        }

        [TestMethod]
        public void CanCalculate_Multiplication_CorrectlyCalculatesDoubles()
        {
            // Arrange
            CC.tal1 = "22,1";
            CC.tal2 = "45,6";
            double finalRes = 1007.76D;

            // Act
            double res = CC.CalcResGange();

            // Assert
            Assert.AreEqual(finalRes, res, 0.00001D);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Overflow exception expected.")]
        public void CanHandle_Multiplication_ThrownOverflowException()
        {
            // Arrange
            CC.tal1 = "9999999999";
            CC.tal2 = "9999999999";
            // double finalRes = 1007.76D;

            // Act
            int res = Convert.ToInt32(CC.CalcResGange());

            // Assert
            // Assert.AreEqual(finalRes, res, 0.00001D);
        }
    }
}
