namespace ElectronColorCode
{
    public struct ElectronColorCode

    {
    public ElectronColorCode(string name, string? color, int? significantFigure, double? multiplier, double? tolerance)
    {
        Name = name;
        Color = color;
        SignificantFigure = significantFigure;
        Multiplier = multiplier;
        Tolerance = tolerance;
    }

    public string Name;
    public string Color;
    public int? SignificantFigure;
    public double? Multiplier;
    public double? Tolerance;
    }
}
