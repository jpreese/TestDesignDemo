using System;
using System.Collections.Generic;
using System.Text;
using FsCheck;
using FsCheck.Xunit;
using Moq;
using Xunit;

namespace Unit.Tests
{
    public class PriceCalculatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("ab")]
        public void Calculate_WhenSmallMessage_ReturnsMessageSize(string input)
        {
            var fileProvider = new Mock<IFileProvider>();
            fileProvider.Setup(fp => fp.ReadAllText(It.IsAny<string>())).Returns(input);
            var priceCalculator = new PriceCalculator(fileProvider.Object);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.Equal(input.Length, result);
        }

        [Theory]
        [InlineData("abc")]
        public void Calculate_WhenLargeMessage_AddsMessageTax(string input)
        {
            var fileProvider = new Mock<IFileProvider>();
            fileProvider.Setup(fp => fp.ReadAllText(It.IsAny<string>())).Returns(input);
            var priceCalculator = new PriceCalculator(fileProvider.Object);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.Equal(input.Length + PriceCalculator.MessageTax, result);
        }

        [Property(Verbose = true)]
        public void Calculate_WhenMessageExceedsMaximumSize_ReturnsMaximumCost(NonNull<string> input)
        {
            var fileProvider = new Mock<IFileProvider>();
            fileProvider.Setup(fp => fp.ReadAllText(It.IsAny<string>())).Returns(input.Get);
            var priceCalculator = new PriceCalculator(fileProvider.Object);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.True(result <= 25);
        }
    }
}
