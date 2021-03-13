using System;
using ElectronColorCode.ECCProperties;

namespace ElectronColorCode
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            var ohmCalc = new OhmCalculator();
            Console.WriteLine(ohmCalc.CalculateOhmValue(Names.Green, Names.Blue, Names.Red));
            var toleranceValues = ohmCalc.CalculateOhmToleranceRange(Names.Green, Names.Blue, Names.Red, Names.Silver);
            Console.WriteLine($"{toleranceValues[0]} - {toleranceValues[1]}");
        }
    }
}
