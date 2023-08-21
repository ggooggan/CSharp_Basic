using Moq;
using MoqStudy;

namespace TestStudy
{
    [TestClass]
    public class MoqTest
    {
        [TestMethod]
        public void Test01()
        {
            var mock = new Mock<IFoo>();
            IFoo foo = mock.Object;

            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            // TryParse는 true를 반환하고 out 인수는 "ack"를 반환하고 지연 평가됩니다.
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);


            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            // 호출에 대한 ref 인수가 동일한 인스턴스인 경우에만 일치합니다.
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            //var valueInstance = mock.Object.Submit(ref instance);


            // access invocation arguments when returning a value
            // 값을 반환할 때 호출 인수에 액세스
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToUpper());

           
            string result = foo.DoSomethingStringy("adsf");

            // Multiple parameters overloads available
            // 여러 매개변수 오버로드 가능

            // throwing when invoked with specific parameters
            // 특정 매개변수로 호출될 때 발생
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));


            // lazy evaluating return value
            // 지연 평가 반환 값
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);


            // async methods (see below for more about async):
            // 비동기 메서드(비동기에 대한 자세한 내용은 아래 참조):
            mock.Setup(foo => foo.DoSomethingAsync().Result).Returns(true);
        }
    }
}