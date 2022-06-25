using CheckoutKata;

string items = "ABCD";

var checkOut = new CheckOut();

checkOut.Scan(items);
Console.WriteLine(checkOut.TotalPrice);
