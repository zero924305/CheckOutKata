using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

            var actual = CountTotalItem(itemList);

            Assert.Equal(expectTotalItem, actual);
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

        private static int CountTotalItem(List<string> itemList)
        {
            return itemList.Count;
        }


    }
}
