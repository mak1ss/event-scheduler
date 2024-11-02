namespace Promotions.gRPC.Entities
{
    public class Promotion
    {
        public int Id {  get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxUses { get; set; }
        public int TimesUsed { get; set; }
        public int EventId { get; set; }

    }
}
