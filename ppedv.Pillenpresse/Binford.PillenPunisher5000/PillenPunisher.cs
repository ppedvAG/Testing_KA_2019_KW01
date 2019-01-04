using System;
using System.Collections.Generic;

namespace Binford.PillenPunisher5000
{
    public class PillenPunisher
    {

        public static void MakePill(int power, Dictionary<string, double> wirkstoffe)
        {
            Console.Beep(power, 500);
            Console.Beep(power + 100, 500);
        }
    }
}
