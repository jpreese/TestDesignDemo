using System.IO;

namespace Unit
{
    public class PriceCalculator
    {
        private readonly IFileProvider _fileProvider;
        public static readonly int MessageTax = 5;
        public static readonly int MaximumCost = 25;

        public PriceCalculator(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public int Calculate(string path)
        {
            var input = _fileProvider.ReadAllText(path);

            if (MessageExceedsMaximumLength(input))
            {
                return MaximumCost;
            }

            if (MessageIsLarge(input))
            {
                return HandleLargeMessage(input);
            }

            return HandleSmallMessage(input);
        }

        private static bool MessageExceedsMaximumLength(string input)
        {
            return input.Length >= 20;
        }

        private static int HandleSmallMessage(string input)
        {
            return input.Length;
        }

        private static int HandleLargeMessage(string input)
        {
            return input.Length + 5;
        }

        private static bool MessageIsLarge(string input)
        {
            return input.Length >= 3;
        }
    }
}
