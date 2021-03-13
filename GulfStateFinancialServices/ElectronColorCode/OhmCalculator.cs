using ElectronColorCode.ECCProperties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ElectronColorCode
{
    public class OhmCalculator : ICalculateOhmValues {

        private readonly Dictionary<string, ElectronColorCode> _eccTable = new Dictionary<string, ElectronColorCode>()
        {
            // Property values are grabbed from ECCProperties to create ECC Structs
            { Names.None, new ElectronColorCode(Names.None, Colors.None, SignificantFigures.None, Multipliers.None, Tolerances.None) },
            { Names.Pink, new ElectronColorCode(Names.Pink, Colors.Pink, SignificantFigures.Pink, Multipliers.Pink, Tolerances.Pink) },
            { Names.Silver, new ElectronColorCode(Names.Silver, Colors.Silver, SignificantFigures.Silver, Multipliers.Silver, Tolerances.Silver) },
            { Names.Gold, new ElectronColorCode(Names.Gold,Colors.Gold, SignificantFigures.Gold, Multipliers.Gold, Tolerances.Gold) },
            { Names.Black, new ElectronColorCode(Names.Black, Colors.Black, SignificantFigures.Black, Multipliers.Black, Tolerances.Black) },
            { Names.Brown, new ElectronColorCode(Names.Brown, Colors.Brown, SignificantFigures.Brown, Multipliers.Brown, Tolerances.Brown) },
            { Names.Red, new ElectronColorCode(Names.Red, Colors.Red, SignificantFigures.Red, Multipliers.Red, Tolerances.Red) },
            { Names.Orange, new ElectronColorCode(Names.Orange, Colors.Orange, SignificantFigures.Orange, Multipliers.Orange, Tolerances.Orange) },
            { Names.Yellow,  new ElectronColorCode(Names.Yellow, Colors.Yellow, SignificantFigures.Yellow, Multipliers.Yellow, Tolerances.Yellow) },
            { Names.Green, new ElectronColorCode(Names.Green, Colors.Green, SignificantFigures.Green, Multipliers.Green, Tolerances.Green) },
            { Names.Blue, new ElectronColorCode(Names.Blue, Colors.Blue, SignificantFigures.Blue, Multipliers.Blue, Tolerances.Blue) },
            { Names.Violet, new ElectronColorCode(Names.Violet, Colors.Violet, SignificantFigures.Violet, Multipliers.Violet, Tolerances.Violet) },
            { Names.Grey, new ElectronColorCode(Names.Grey, Colors.Grey, SignificantFigures.Grey, Multipliers.Grey, Tolerances.Grey) },
            { Names.White, new ElectronColorCode(Names.White, Colors.White, SignificantFigures.White, Multipliers.White, Tolerances.White) }
        };

        // Gets the ECC struct out of dictionary if exists
        public ElectronColorCode GetElectronColorCode(string eccName)
        {
            // Normalize case before TryGetValue. ToLower then TitleCase
            if (_eccTable.TryGetValue(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(eccName.ToLower()), out var eccValue))
            {
                return eccValue;
            }
            throw new ApplicationException($"ECC Name: {eccName} is not valid.");
        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor)
        {
            var firstBand = GetElectronColorCode(bandAColor).SignificantFigure.ToString();
            var secondBand = GetElectronColorCode(bandBColor).SignificantFigure.ToString();
            var thirdBand = GetElectronColorCode(bandCColor).Multiplier.ToString();
            return int.Parse($"{firstBand}{secondBand}") * int.Parse(thirdBand);
        }

        // Calculates the tolerance range and returns it in an array
        public int[] CalculateOhmToleranceRange(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var fourthBand = GetElectronColorCode(bandDColor);
            /*
                if fourthBand/bandD has a null value for tolerance throw exception
                we can't divide null by 100 to get a percentage
             */
            if (string.IsNullOrEmpty(fourthBand.Tolerance.ToString()))
            {
                throw new ApplicationException("The fourth/bandD cannot have a null tolerance");
            }

            var calculatedOhmValue = CalculateOhmValue(bandAColor, bandBColor, bandCColor);
            var plusMinusTolerance = calculatedOhmValue * GetElectronColorCode(bandDColor).Tolerance/100;
            return new int[]
            {
                 calculatedOhmValue - (int) plusMinusTolerance,
                 calculatedOhmValue + (int) plusMinusTolerance,
            };
        }
    }
}