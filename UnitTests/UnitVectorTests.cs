using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverKata.Core;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class UnitVectorTests
    {
        [TestMethod]
        public void UnitVectorCanBeRotatedByNinetyDegrees()
        {
            var unitVector = new UnitVector(1, 0);
            var rotatedVector = unitVector.Rotate(90);

            Assert.AreEqual(0, rotatedVector.X);
            Assert.AreEqual(1, rotatedVector.Y);
        }

        [TestMethod]
        public void TheInvertOfAUnitVectorOnTheXPlaneCanBeCalculated()
        {
            var unitVector = new UnitVector(1, 0);
            var invertedVector = unitVector.Invert();

            Assert.AreEqual(-1, invertedVector.X);
            Assert.AreEqual(0, invertedVector.Y);
        }

        [TestMethod]
        public void TheInvertOfAUnitVectorOnTheYPlaneCanBeCalculated()
        {
            var unitVector = new UnitVector(0, 1);
            var invertedVector = unitVector.Invert();

            Assert.AreEqual(0, invertedVector.X);
            Assert.AreEqual(-1, invertedVector.Y);
        }
    }
}
