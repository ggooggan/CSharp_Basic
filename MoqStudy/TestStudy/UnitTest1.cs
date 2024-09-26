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
            // TryParse�� true�� ��ȯ�ϰ� out �μ��� "ack"�� ��ȯ�ϰ� ���� �򰡵˴ϴ�.
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);


            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            // ȣ�⿡ ���� ref �μ��� ������ �ν��Ͻ��� ��쿡�� ��ġ�մϴ�.
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            //var valueInstance = mock.Object.Submit(ref instance);


            // access invocation arguments when returning a value
            // ���� ��ȯ�� �� ȣ�� �μ��� �׼���
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToUpper());


            string result = foo.DoSomethingStringy("adsf");

            // Multiple parameters overloads available
            // ���� �Ű����� �����ε� ����

            // throwing when invoked with specific parameters
            // Ư�� �Ű������� ȣ��� �� �߻�
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));


            // lazy evaluating return value
            // ���� �� ��ȯ ��
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);


            // async methods (see below for more about async):
            // �񵿱� �޼���(�񵿱⿡ ���� �ڼ��� ������ �Ʒ� ����):
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
                .Callback<int, string>((i, s) => callArgs.Add(s))
                .Returns(true);

            var _mock = mock.Object;
            var a = _mock.DoSomething(1, "asdfasdf");

            Console.WriteLine(a);
            //// callbacks can be specified before and after invocation
            //mock.Setup(foo => foo.DoSomething("ping"))
            //    .Callback(() => Console.WriteLine("Before returns"))
            //    .Returns(true)
            //    .Callback(() => Console.WriteLine("After returns"));

            //// callbacks for methods with `ref` / `out` parameters are possible but require some work (and Moq 4.8 or later):
            //delegate void SubmitCallback(ref Bar bar);

            //mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny))
            //    .Callback(new SubmitCallback((ref Bar bar) => Console.WriteLine("Submitting a Bar!")));

            //// returning different values on each invocation
            //var mock = new Mock<IFoo>();
            //var calls = 0;
            //mock.Setup(foo => foo.GetCount())
            //    .Callback(() => calls++)
            //    .Returns(() => calls);
            //// returns 0 on first invocation, 1 on the next, and so on
            //Console.WriteLine(mock.Object.GetCount());

            //// access invocation arguments and set to mock setup property
            //mock.SetupProperty(foo => foo.Bar);
            //mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
            //    .Callback((string s) => mock.Object.Bar = s)
            //    .Returns(true);
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

        [TestMethod]
        public void EventTest()
        {
            var mock = new Mock<IFoo>();
            var _mockObject = mock.Object;
            _mockObject.MyEvent += (num, e) =>
            {
                Console.WriteLine($"num: {num} / boolen: {e}");
            };

            int foodValue = 42;
            mock.Raise(m => m.MyEvent += null, 1, true);


            Console.WriteLine("end");
        }
    }
}