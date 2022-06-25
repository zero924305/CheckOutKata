using Xunit;

namespace CheckoutKata_Test
{
    public class UnitTest1
    {
        public enum Sku
        { 
            A = 50,
            B = 30,
            C = 20,
            D = 15
        }


        [Fact]
        public void Check_ItemName_Equal_SkuEnum()
        {
            var SkuA = "A";
            var SkuB = "B";
            var SkuC = "C";
            var SkuD = "D";

            Assert.Equal(nameof(Sku.A), SkuA);
            Assert.Equal(nameof(Sku.B), SkuB);
            Assert.Equal(nameof(Sku.C), SkuC);
            Assert.Equal(nameof(Sku.D), SkuD);
        }
    }
}