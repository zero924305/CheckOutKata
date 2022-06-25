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

        [Fact]
        public void Check_ItemPrice_Equal_SkuEnum()
        {
            var SkuA = 50;
            var SkuB = 30;
            var SkuC = 20;
            var SkuD = 15;

            Assert.Equal((int)Sku.A, SkuA);
            Assert.Equal((int)Sku.B, SkuB);
            Assert.Equal((int)Sku.C, SkuC);
            Assert.Equal((int)Sku.D, SkuD);

        }
    }
}