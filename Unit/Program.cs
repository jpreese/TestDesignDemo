using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Unit
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceCalculator = new PriceCalculator(new FileProvider());
            var result = priceCalculator.Calculate(@"C:\Demo\input.txt");

            Console.WriteLine($"Your result is {result}");
        }
    }
}
