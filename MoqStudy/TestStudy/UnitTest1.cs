using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqStudy;
using System.Text.RegularExpressions;

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

        [TestMethod]
        public void MatchingTest()
        {
            var mock = new Mock<IFoo>();

            // any value
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);

            // any value passed in a `ref` parameter (requires Moq 4.8 or later):
            mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny)).Returns(true);

            // matching Func<int>, lazy evaluated
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);

            // matching ranges
            //mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);

            // matching regex
            mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");

            IFoo foo = mock.Object;
            Bar _bar = new Bar();
            Baz _baz = new Baz();

            var value01 = foo.DoSomething("anykey");
            var value02 = foo.Submit(ref _bar);
            var value03 = foo.Add(1);
            var value04 = foo.Add(2);
            var value05 = foo.DoSomethingStringy("aaaaaaaaaaaa");
            var value06 = foo.DoSomethingStringy("eeeeeeeeeeeeeee");

            Console.WriteLine("end");
        }

        [TestMethod]
        public void CallbackTest()
        {
            var mock = new Mock<IFoo>();
            var calls = 0;
            var callArgs = new List<string>();

            mock.Setup(foo => foo.DoSomething("ping"))
                .Callback(() => calls++)
                .Returns(true);

            // access invocation arguments
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Callback((string s) => callArgs.Add(s))
                .Returns(true);

            // alternate equivalent generic method syntax
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Callback<string>(s => callArgs.Add(s))
                .Returns(true);

            // access arguments for methods with multiple parameters
            mock.Setup(foo => foo.DoSomething(It.IsAny<int>(), It.IsAny<string>()))
                .Callback<int, string>((i, s) => callArgs.Add(i.ToString()))
                .Returns(true)
                .Callback<int, string>((i, s) => callArgs.Add((i+100).ToString()));


            //// callbacks can be specified before and after invocation
            //mock.Setup(foo => foo.DoSomething("ping"))
            //    .Callback(() => Console.WriteLine("Before returns"))
            //    .Returns(true)
            //    .Callback(() => Console.WriteLine("After returns"));

            IFoo foo = mock.Object;
            var a = foo.DoSomething(1, "ping");
             
            Assert.IsTrue(a);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            var mock = new Mock<IFoo>();
            var _mockObject = mock.Object;

            mock.Setup(foo => foo.Name).Returns("bar");
            var value01 = _mockObject.Name;

            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(foo => foo.Bar.Baz.Name).Returns("baz");

            // expects an invocation to set the value to "foo"
            mock.SetupSet(foo => foo.Name = "foo");

            //// or verify the setter directly
            //mock.VerifySet(foo => foo.Name = "foo");

            var value02 = _mockObject.Bar.Baz.Name;
            var value03 = _mockObject.Name;

            // start "tracking" sets/gets to this property
            mock.SetupProperty(f => f.Name);
            // alternatively, provide a default value for the stubbed property
            mock.SetupProperty(f => f.Name, "foo_defaultName");

            var foo = mock.Object;
            // Initial value was stored
            //Assert.("foo", foo.Name);
            var value04 = foo.Name;

            // New value set which changes the initial value
            foo.Name = "bar";
            //Assert.Equal("bar", foo.Name);
            var value05 = foo.Name;

            Console.WriteLine("");

        }
    }
}