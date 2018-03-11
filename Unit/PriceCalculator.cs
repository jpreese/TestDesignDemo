using System.IO;

namespace Unit
{
    public class PriceCalculator
    {
        private readonly IFileProvider _fileProvider;
        public static readonly int MessageTax = 5;

        public PriceCalculator(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public int Calculate(string path)
        {
            var input = _fileProvider.ReadAllText(path);

            if (input.Length >= 20)
            {
                return 25;
            }

            if (MessageIsLarge(input))
            {
                return HandleLargeMessage(input);
            }

            return HandleSmallMessage(input);
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
