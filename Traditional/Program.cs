using System;

namespace Traditional
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceCalculator = new PriceCalculator();
            var result = priceCalculator.Calculate(@"C:\Demo\input.txt");

            Console.WriteLine($"Your cost is {result}");
        }
    }
}
