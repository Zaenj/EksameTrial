using WoodPelletsLib;

namespace WoodPelletTest
{
    [TestClass]
    public class WoodPelletTest
    {
        private readonly WoodPellet _validPellet = new() { Brand = "EcoPellets", Quality = 3 };
        private readonly WoodPellet _nullBrand = new() { Brand = null, Quality = 4 };
        private readonly WoodPellet _shortBrand = new() { Brand = "A", Quality = 2 };
        private readonly WoodPellet _invalidQualityLow = new() { Brand = "GreenEnergy", Quality = 0 };
        private readonly WoodPellet _invalidQualityHigh = new() { Brand = "NaturePellets", Quality = 6 };

        [TestMethod]
        public void ValidateBrand()
        {
            // Valid case
            _validPellet.ValidateBrand();

            // Invalid cases
            Assert.ThrowsException<ArgumentNullException>(() => _nullBrand.ValidateBrand());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _shortBrand.ValidateBrand());
        }

        [TestMethod]
        public void ValidateQuality()
        {
            // Valid case
            _validPellet.ValidateQuality();

            // Invalid cases
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _invalidQualityLow.ValidateQuality());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _invalidQualityHigh.ValidateQuality());
        }
    }
}