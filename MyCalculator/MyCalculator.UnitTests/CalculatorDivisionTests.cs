using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace MyCalculator.UnitTests
{
    [TestClass]
    public class CalculatorDivisionTests
    {
        ClassCalculator CC = new ClassCalculator();

        [TestMethod]
        public void CanCalculate_Division_CorrectlyCalculatesDoubles()
        {
            // Arrange
            CC.tal1 = "22,1";
            CC.tal2 = "45,6";
            double finalRes = 0.48464D;

            // Act
            double res = CC.CalcResDiv();

            // Assert
            Assert.AreEqual(finalRes, res, 0.00001D);
        }

        [TestMethod]
        public void CanCalculate_DivisionByZero_CorrectlyDefaultToZero()
        {
            // Arrange
            CC.tal1 = "35";
            CC.tal2 = "0";
            double finalRes = 0D;

            // Act
            double res = CC.CalcResDiv();

            // Assert
            Assert.AreEqual(finalRes, res);
        }
    }
}
