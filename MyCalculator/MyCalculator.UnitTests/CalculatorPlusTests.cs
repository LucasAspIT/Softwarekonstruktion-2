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
        public void CanCalculateAddition()
        {
            // Arrange
            CC.tal1 = "55";
            CC.tal2 = "45";
            double finalRes = 100D;

            // Act
            double res = CC.CalcResPlus();

            // Assert
            Assert.AreEqual(finalRes, res);
        }
    }
}
