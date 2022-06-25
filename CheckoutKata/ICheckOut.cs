namespace CheckoutKata
{
    public interface ICheckOut
    {
        int TotalPrice { get; }

        void Scan(string item);
    }
}