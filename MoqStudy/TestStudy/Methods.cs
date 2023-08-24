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

            //var mockObject = mock.Object;
            //bool returnValue = mockObject.Submit(ref instance); // true
            ////bool returnValue = mockObject.DoSomething("Not");  // false

            // access invocation arguments when returning a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToLower());
            // Multiple parameters overloads available
            //var mockObject = mock.Object;
            //string returnValue = mockObject.DoSomethingStringy("ASDFASDF"); // 소문자로 리턴 받음


            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            //mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));
          


            // lazy evaluating return value
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);


            // async methods (see below for more about async):
            mock.Setup(foo => foo.DoSomethingAsync().Result).Returns(true);

            var mockObject = mock.Object;
            var returnValue = mockObject.DoSomethingStringy("ASDFADASF");

            Console.WriteLine(returnValue);
        }


        [TestMethod]
        public void MatchingArguments()
        {
            var mock = new Mock<IFoo>();

            // any value
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);


            // any value passed in a `ref` parameter (requires Moq 4.8 or later):
            mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny)).Returns(true);


            // matching Func<int>, lazy evaluated
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);


            var mockSetup = mock.Object;
            var result = mockSetup.DoSomething("Asdfasdf");
            var result_ = mockSetup.Add(5);

            Console.WriteLine(result);

            // matching ranges
            //mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);


            // matching regex
            //mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");
        }

        [TestMethod]
        public void Properties()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.Name).Returns("bar");

            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(foo => foo.Bar.Baz.Name).Returns("bazName");

            // expects an invocation to set the value to "foo"
            mock.SetupSet(foo => foo.Name = "foo");

            // or verify the setter directly
            //mock.VerifySet(foo => foo.Name = "foo");


            // start "tracking" sets/gets to this property
            mock.SetupProperty(f => f.Name);

            //// alternatively, provide a default value for the stubbed property
            //mock.SetupProperty(f => f.Name, "foo");


            // Now you can do:

            IFoo foo = mock.Object;
            foo.Name = "foo";
            // Initial value was stored
            Assert.AreEqual("foo", foo.Name); // SetupProperty를 설정해야 사용 가능.

            // New value set which changes the initial value
            foo.Name = "bar";
            Assert.AreEqual("bar", foo.Name);

            var mockSetup = mock.Object;
            var value = mockSetup.Bar.Baz.Name;

            Console.WriteLine(value);


            var mock1 = new Mock<IFoo>();
            mock1.SetupSequence(f => f.GetCount())
                .Returns(3)  // will be returned on 1st invocation
                .Returns(2)  // will be returned on 2nd invocation
                .Returns(1)  // will be returned on 3rd invocation
                .Returns(0)  // will be returned on 4th invocation
                .Throws(new InvalidOperationException());  // will be thrown on 5th invocation

            var a = mock1.Object;
            var b = a.GetCount();

            Console.WriteLine(b);
        }
    }
}
