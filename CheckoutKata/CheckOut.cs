using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class CheckOut
    {

        public void Scan(string item)
        {
            var itemList = ScanItemFunc(item);

            var itemCount = itemList.Count;
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
