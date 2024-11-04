namespace Promotions.gRPC.Utils
{
    public class PromocodeGenerator
    {
        private static readonly Random _random = new Random();

        public static string GeneratePromoCode(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
