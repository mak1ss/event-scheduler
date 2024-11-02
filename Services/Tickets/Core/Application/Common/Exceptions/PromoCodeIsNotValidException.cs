
namespace Application.Common.Exceptions
{
    public class PromoCodeIsNotValidException : Exception
    {
        public PromoCodeIsNotValidException() { }
        public PromoCodeIsNotValidException(string message) : base(message) { }
    }
}
