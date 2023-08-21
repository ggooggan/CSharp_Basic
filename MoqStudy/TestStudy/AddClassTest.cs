using Moq;
using MoqStudy;

namespace TestStudy
{
    [TestClass]
    public class AddClassTest
    {
        [TestMethod]
        public void AddTest()
        {
            // Arrange
            var addMock = new Mock<ICalculator>();
            addMock.Setup(calculator => calculator.Add(2, 3)).Returns(5);

            // 모의 객체 사용
            ICalculator calculator = addMock.Object;

            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
            // Act
            var addMoc111k = new Mock<Calculator>();

            //Calculator calculator1 = new Calculator();
            addMoc111k.Object.Test(calculator, 1, 1);
            addMoc111k.Verify(ad => ad.Test(calculator, 1, 1));

            // Assert
            //Assert.AreEqual(8, result);
        }
    }
}
