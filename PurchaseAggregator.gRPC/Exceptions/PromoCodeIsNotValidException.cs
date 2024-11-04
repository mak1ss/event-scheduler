namespace PurchaseAggregator.gRPC.Eceptions
{
    public class PromoCodeIsNotValidException : Exception
    {
        public PromoCodeIsNotValidException() { }
        public PromoCodeIsNotValidException(string message) : base(message) { }
    }
}
