using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class CheckOut : ICheckOut
    {


        public void Scan(string item)
        {
            var itemList = ScanItemFunc(item);

            ScanedItemAndValues = CountAndGroupTotalItem(itemList);

        }

        public int TotalPrice => CalculateTotalPrice(ScanedItemAndValues);

        private Dictionary<string, int> ScanedItemAndValues { get; set; }

        private static List<string> ScanItemFunc(string items)
        {
            if (string.IsNullOrEmpty(items))
                return null;

            var result = new List<string>();

            foreach (var item in items)
                result.Add(item.ToString());

            return result;
        }

        private static Dictionary<string, int> CountAndGroupTotalItem(List<string> itemList)
        {
            var result = itemList
                            .GroupBy(k => k)
                            .ToDictionary(k => k.Key, v => v.Count());
            return result;

        }

        private static int CalculateTotalPrice(Dictionary<string, int> items)
        {
            var result = 0;

            foreach (var item in items)
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
