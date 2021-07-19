using Xunit;
using RookieWorkshop.Service;
using RookieWorkshop.Interface;
using System.Collections.Generic;
using NSubstitute;
using System;

namespace RookieWorkshop.Test
{
    public class FooBarQixServiceTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FooBarQix(string input, string expected)
        {
            // Arrange
            var randomService = Substitute.For<IInputService>();
            //randomService.GetValue(2).Returns(1);
            //randomService.GetValue(4).Returns(2);
            //randomService.GetValue(6).Returns(3);
            //randomService.GetValue(8).Returns(4);
            //randomService.GetValue(10).Returns(5);

            var cacheService = Substitute.For<ICacheService>();
            //cacheService.Get<string>("1", TimeSpan.FromSeconds(10), () => "1").Returns("1");
            //cacheService.Get<string>("2", TimeSpan.FromSeconds(10), () => "2").Returns("2");
            //cacheService.Get<string>("3", TimeSpan.FromSeconds(10), () => "FooFoo").Returns("FooFoo");
            //cacheService.Get<string>("4", TimeSpan.FromSeconds(10), () => "4").Returns("4");
            //cacheService.Get<string>("5", TimeSpan.FromSeconds(10), () => "BarBar").Returns("BarBar");
            //cacheService.Get<string>("6", TimeSpan.FromSeconds(10), () => "Foo").Returns("Foo");
            //cacheService.Get<string>("7", TimeSpan.FromSeconds(10), () => "QixQix").Returns("QixQix");
            //cacheService.Get<string>("8", TimeSpan.FromSeconds(10), () => "8").Returns("8");
            //cacheService.Get<string>("9", TimeSpan.FromSeconds(10), () => "Foo").Returns("Foo");
            //cacheService.Get<string>("10", TimeSpan.FromSeconds(10), () => "Bar").Returns("Bar");

            cacheService.Remove("10");


            IDataService fooBarQixService = new FooBarQixService(randomService, cacheService);

            // Act
            var actual = fooBarQixService.GetData(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data = new List<object[]>
        {
            new object[] { "1", "1" },
            new object[] { "2", "2" },
            new object[] { "3", "FooFoo" },
            new object[] { "4", "4" },
            new object[] { "5", "BarBar" },
            new object[] { "6", "Foo" },
            new object[] { "7", "QixQix" },
            new object[] { "8", "8" },
            new object[] { "9", "Foo" },
            new object[] { "10", "Bar" },
            //new object[] { "13", "Foo" },
            //new object[] { "15", "FooBarBar" },
            //new object[] { "21", "FooQix" },
            //new object[] { "33", "FooFooFoo" },
            //new object[] { "51", "FooBar" },
            //new object[] { "53", "BarFoo" },
        };
    }
}
