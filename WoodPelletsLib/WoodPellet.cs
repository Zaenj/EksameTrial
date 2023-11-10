using System.Runtime.InteropServices;

namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{Id} {Brand} {Price} {Quality}";
        }

        public void ValidateBrand()
        {
            if (Brand == null)
                throw new ArgumentNullException(nameof(Brand),"Brand cannot be Null");

            if (Brand.Length < 2) 
                throw new ArgumentOutOfRangeException(nameof(Brand), "Brand must be atleast 2 characters");
        }

        public void ValidatePrice()
        {
            if (Price <= 0) throw new ArgumentOutOfRangeException(nameof(Price), "Price needs a postive number");
        }

        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5) 
                throw new ArgumentOutOfRangeException(nameof(Quality), "Qualityt must be between 1 and 5");
        }
        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }
    }
}