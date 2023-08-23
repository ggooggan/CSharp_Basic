using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqStudy;

namespace TestStudy
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Methods
    {

        [TestMethod]
        public void MyTestMethod()
        {
            var mock = new Mock<IFoo>();

            // 1. set up 확인
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

            //var mockObject = mock.Object;
            //bool returnValue = mockObject.DoSomething("ping"); // true
            //bool returnValue = mockObject.DoSomething("Not");  // false

            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            //var mockObject = mock.Object;
            //string value = "";
            //bool returnValue = mockObject.TryParse("ping", out value); // true, value에 ack 값이 들어 옴.
            ////bool returnValue = mockObject.TryParse("test", out value); // false, value에는 빈 문자열로 리턴이 됨.


            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);


            // access invocation arguments when returning a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToLower());
            // Multiple parameters overloads available


            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));


            // lazy evaluating return value
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);


            // async methods (see below for more about async):
            mock.Setup(foo => foo.DoSomethingAsync().Result).Returns(true);
        }
    }
}
