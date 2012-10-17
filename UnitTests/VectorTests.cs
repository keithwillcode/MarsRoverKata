using MarsRoverKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverKata.UnitTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void GetUnitVectorFromAngleWorksForZero()
        {
            var unitVector = Vector.GetUnitVectorFromAngle(0);

            Assert.AreEqual(1, unitVector.X);
            Assert.AreEqual(0, unitVector.Y);
        }

        [TestMethod]
        public void GetUnitVectorFromAngleWorksForNinety()
        {
            var unitVector = Vector.GetUnitVectorFromAngle(90);

            Assert.AreEqual(0, unitVector.X);
            Assert.AreEqual(1, unitVector.Y);
        }

        [TestMethod]
        public void GetUnitVectorFromAngleWorksForOneHundredEighty()
        {
            var unitVector = Vector.GetUnitVectorFromAngle(180);

            Assert.AreEqual(-1, unitVector.X);
            Assert.AreEqual(0, unitVector.Y);
        }

        [TestMethod]
        public void GetUnitVectorFromAngleWorksForTwoHundredSeventy()
        {
            var unitVector = Vector.GetUnitVectorFromAngle(270);

            Assert.AreEqual(0, unitVector.X);
            Assert.AreEqual(-1, unitVector.Y);
        }

        [TestMethod]
        public void TwoVectorsCanBeAdded()
        {
            var firstVector = new Vector(1, 2);
            var secondVector = new Vector(2, 3);
            var result = firstVector + secondVector;

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(5, result.Y);
        }
    }
}
