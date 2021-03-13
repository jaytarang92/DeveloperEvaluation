using System;
using ElectronColorCode;
using ElectronColorCode.ECCProperties;
using Xunit;

namespace ElectronColorCodeTests
{
    public class ElectronColorCodeTests
    {
        private readonly OhmCalculator _ohmCalculator = new OhmCalculator();

        [Fact]
        public void CalculateOhmValue_GreenBlueRed()
        {
            var calculatedOhmValue = _ohmCalculator.CalculateOhmValue(Names.Green, Names.Blue, Names.Red);
            Assert.Equal(5600, calculatedOhmValue);
        }
        
        [Fact]
        public void CalculateOhmValue_GreenBlueRedLowerUpperCase()
        {
            var calculatedOhmValue = _ohmCalculator.CalculateOhmValue(Names.Green.ToLower(), Names.Blue.ToUpper(), Names.Red.ToUpper());
            Assert.Equal(5600, calculatedOhmValue);
        }
        
        [Fact]
        public void CalculateOhmValue_InvalidColorMagenta()
        {
            var exception = Assert.Throws<ApplicationException>(() => _ohmCalculator.CalculateOhmValue(Names.Green, Names.Blue, "Magenta"));
            Assert.Equal("ECC Name: Magenta is not valid.", exception.Message); 
        }
        
        [Fact]
        public void CalculateOhmToleranceRange_GreenBlueRedSilver()
        {
            var calculatedOhmToleranceRange = _ohmCalculator.CalculateOhmToleranceRange(Names.Green, Names.Blue, Names.Red, Names.Silver);
            Assert.Equal(new int[]{5040, 6160}, calculatedOhmToleranceRange);
        }
        
        [Fact]
        public void CalculateOhmToleranceRange_NullTolerance()
        {
            var exception = Assert.Throws<ApplicationException>(() => _ohmCalculator.CalculateOhmToleranceRange(Names.Green, Names.Blue, Names.Red, Names.Pink));
            Assert.Equal("The fourth/bandD cannot have a null tolerance", exception.Message); 
        }
    }
}