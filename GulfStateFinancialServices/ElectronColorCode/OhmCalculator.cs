using System;


namespace ElectronColorCode
{
    public class OhmCalculator : ICalculateOhmValues {

        private ECCTable _eccTable = new ();

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor)
        {
            var firstBand = _eccTable.GetElectronColorCode(bandAColor).SignificantFigure.ToString();
            var secondBand = _eccTable.GetElectronColorCode(bandBColor).SignificantFigure.ToString();
            var thirdBand = _eccTable.GetElectronColorCode(bandCColor).Multiplier.ToString();
            return int.Parse($"{firstBand}{secondBand}") * int.Parse(thirdBand);
        }

        // Calculates the tolerance range and returns it in an array
        public int[] CalculateOhmToleranceRange(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var fourthBand = _eccTable.GetElectronColorCode(bandDColor);
            /*
                if fourthBand/bandD has a null value for tolerance throw exception
                we can't divide null by 100 to get a percentage
             */
            if (string.IsNullOrEmpty(fourthBand.Tolerance.ToString()))
            {
                throw new ApplicationException("The fourth/bandD cannot have a null tolerance");
            }

            var calculatedOhmValue = CalculateOhmValue(bandAColor, bandBColor, bandCColor);
            var plusMinusTolerance = calculatedOhmValue * _eccTable.GetElectronColorCode(bandDColor).Tolerance/100;
            return new int[]
            {
                 calculatedOhmValue - (int) plusMinusTolerance,
                 calculatedOhmValue + (int) plusMinusTolerance,
            };
        }
    }
}