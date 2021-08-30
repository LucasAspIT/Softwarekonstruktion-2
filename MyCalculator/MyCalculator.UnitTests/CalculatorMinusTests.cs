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
        public void CanCalculateSubtraction()
        {
            // Arrange
            CC.tal1 = "10";
            CC.tal2 = "5";
            double finalRes = 5D;

            // Act
            double res = CC.CalcResMinus();

            // Assert
            Assert.AreEqual(finalRes, res);
        }
    }
}
