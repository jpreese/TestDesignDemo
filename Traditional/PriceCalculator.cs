using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Traditional
{
    public class PriceCalculator
    {
        public int Calculate(string path)
        {
            var input = File.ReadAllText(path);

            if (input.Length >= 20)
            {
                return 25;
            }

            if (input.Length >= 3)
            {
                return input.Length + 5;
            }

            return input.Length;
        }
    }
}
