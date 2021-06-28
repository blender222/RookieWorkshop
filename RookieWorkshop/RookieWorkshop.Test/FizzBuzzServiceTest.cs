using Xunit;
using RookieWorkshop.Service;
using RookieWorkshop.Interface;

namespace RookieWorkshop.Test
{
    public class FizzBuzzServiceTest
    {
        private readonly IDataService _fizzBuzzService;

        public FizzBuzzServiceTest()
        {
            this._fizzBuzzService = new FizzBuzzService();
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("Fizz", 3)]
        [InlineData("4", 4)]
        [InlineData("Buzz", 5)]
        [InlineData("Fizz", 6)]
        [InlineData("7", 7)]
        [InlineData("8", 8)]
        [InlineData("Fizz", 9)]
        [InlineData("Buzz", 10)]
        [InlineData("11", 11)]
        [InlineData("Fizz", 12)]
        [InlineData("13", 13)]
        [InlineData("14", 14)]
        [InlineData("FizzBuzz", 15)]
        public void FizzBuzz(string expected, int input)
        {
            // Act
            var actual = this._fizzBuzzService.GetData(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
