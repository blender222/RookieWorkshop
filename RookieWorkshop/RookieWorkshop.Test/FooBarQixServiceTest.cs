using Xunit;
using RookieWorkshop.Service;
using RookieWorkshop.Interface;
using System.Collections.Generic;
using NSubstitute;

namespace RookieWorkshop.Test
{
    public class FooBarQixServiceTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FooBarQix(int input, string expected)
        {
            // Arrange
            var randomService = Substitute.For<IInputService>();
            randomService.GetValue(2).Returns(1);
            randomService.GetValue(4).Returns(2);
            randomService.GetValue(6).Returns(3);
            randomService.GetValue(8).Returns(4);
            randomService.GetValue(10).Returns(5);

            IDataService fooBarQixService = new FooBarQixService(randomService);

            // Act
            var actual = fooBarQixService.GetData(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data = new List<object[]>
        {
            new object[] { 2, "1" },
            new object[] { 4, "2" },
            new object[] { 6, "FooFoo" },
            new object[] { 8, "4" },
            new object[] { 10, "BarBar" },

            //new object[] { 1, "1" },
            //new object[] { 2, "2" },
            //new object[] { 3, "FooFoo" },
            //new object[] { 4, "4" },
            //new object[] { 5, "BarBar" },
            //new object[] { 6, "Foo" },
            //new object[] { 7, "QixQix" },
            //new object[] { 8, "8" },
            //new object[] { 9, "Foo" },
            //new object[] { 10, "Bar" },
            //new object[] { 13, "Foo" },
            //new object[] { 15, "FooBarBar" },
            //new object[] { 21, "FooQix" },
            //new object[] { 33, "FooFooFoo" },
            //new object[] { 51, "FooBar" },
            //new object[] { 53, "BarFoo" },
        };
    }
}
