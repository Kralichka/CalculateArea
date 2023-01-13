using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateArea;

namespace CalculateTests
{
    [TestClass]
    public class CalculateAreaTests
    {
        [TestMethod]
        public void AreaOfTriangle()
        {
            // Arrange
            Triangle figure = new Triangle
            {
                SideA = 7.35,
                SideB = 9.14,
                SideC = 16.2222
            };

            double expectedArea = 11.93; 

            //Act
            

            //Assert
            double area = figure.Area;
            Assert.AreEqual(expectedArea, area, 0.01, "Result is not correct.");
        }

        [TestMethod]
        public void AreaOfCircle()
        {
            // Arrange
            Circle figure = new Circle
            {
                Radius = 7
            };

            double expectedArea = 153.94;

            //Act


            //Assert
            double area = figure.Area;
            Assert.AreEqual(expectedArea, area, 0.01, "Result is not correct.");
        }

        [TestMethod]
        public void IsTriangleRight()
        {
            // Arrange
            Triangle figure = new Triangle
            {
                SideA = 3,
                SideB = 4,
                SideC = 5
            };
            Triangle figure2 = new Triangle
            {
                SideA = 5,
                SideB = 5,
                SideC = 5
            };

            //Act
            bool mustBeTrue = figure.IsTriangleRight();
            bool mustBeFalse = figure2.IsTriangleRight();

            //Assert
            Assert.IsTrue(mustBeTrue);
            Assert.IsFalse(mustBeFalse);
        }
    }
}
