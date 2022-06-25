using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CheckoutKata;

namespace CheckoutKata_Test
{
    public class CheckoutTest
    {
        [Fact]
        public void ScanItem() {
            string itemList = "ABCD";

            var Actual = new List<string>();
            Actual.Add("A");
            Actual.Add("B");
            Actual.Add("C");
            Actual.Add("D");


            var Expect = ScanItemFunc(itemList);

            Assert.Equal(Actual, Expect);

        }

        [Theory]
        [InlineData("ABCDAAADC",9)]
        [InlineData("ABCDAAADCAAAD", 13)]
        [InlineData("ABCD", 4)]
        [InlineData("AAAAAAAAAAA", 11)]
        public void Count_ItemFrom_List(string items, int expectTotalItem)
        {
            var itemList = ScanItemFunc(items);

            var actual = CountAndGroupTotalItem(itemList);

            //Assert.Equal(expectTotalItem, actual.Values);
        }

        [Theory]
        [InlineData("ABCDAAADC", 300)]
        [InlineData("ABCDAAADCAAAD", 465)]
        [InlineData("ABCD", 115)]
        [InlineData("AAAAAAAAAAA", 550)]
        public void Calculate_Total_Price(string items, int totalPrice)
        {
            var itemlist = ScanItemFunc(items);

            var groupItem = CountAndGroupTotalItem(itemlist);

            var actual = CalculateTotalPrice(groupItem);

            Assert.Equal(totalPrice, actual);

        }



        private static List<string> ScanItemFunc(string items)
        {
            if (string.IsNullOrEmpty(items))
                return null;

            var result = new List<string>();

            foreach (var item in items)
                result.Add(item.ToString());

            return result;
        }

        private static Dictionary<string,int> CountAndGroupTotalItem(List<string> itemList)
        {
            var result = itemList
                            .GroupBy(k => k)
                            .ToDictionary(k => k.Key, v => v.Count());
            return result;

        }

        private static int CalculateTotalPrice(Dictionary<string,int> items)
        {
            var result = 0;

            foreach(var item in items)
            {
                var price = GetItemPriceFromSku(item.Key);

                result += price * item.Value;
            }
            return result;
        }

        private static int GetItemPriceFromSku(string key)
        {
            var result = key switch
            {
                var x when x.Equals(nameof(EnumSku.Sku.A)) => (int)EnumSku.Sku.A,
                var x when x.Equals(nameof(EnumSku.Sku.B)) => (int)EnumSku.Sku.B,
                var x when x.Equals(nameof(EnumSku.Sku.C)) => (int)EnumSku.Sku.C,
                var x when x.Equals(nameof(EnumSku.Sku.D)) => (int)EnumSku.Sku.D,
                _ => 0
            };
            return result;
        }
    }
}
