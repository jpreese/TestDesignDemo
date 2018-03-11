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
            var priceCalculator = CreatePriceCalculatorWithInput(input);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.Equal(input.Length, result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("abcd")]
        public void Calculate_WhenLargeMessage_AddsMessageTax(string input)
        {
            var priceCalculator = CreatePriceCalculatorWithInput(input);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.Equal(input.Length + PriceCalculator.MessageTax, result);
        }

        [Property]
        public void Calculate_WhenMessageExceedsMaximumSize_ReturnsMaximumCost(NonNull<string> input)
        {
            var priceCalculator = CreatePriceCalculatorWithInput(input.Get);

            var result = priceCalculator.Calculate(It.IsAny<string>());

            Assert.True(result <= PriceCalculator.MaximumCost);
        }

        private PriceCalculator CreatePriceCalculatorWithInput(string input)
        {
            var fileProvider = new Mock<IFileProvider>();
            fileProvider.Setup(fp => fp.ReadAllText(It.IsAny<string>())).Returns(input);

            return new PriceCalculator(fileProvider.Object);
        }
    }
}
