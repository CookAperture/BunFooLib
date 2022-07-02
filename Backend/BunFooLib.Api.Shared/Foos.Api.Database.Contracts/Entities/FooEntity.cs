namespace Foos.Api.Database.Contracts.Entities
{
    public class FooEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FooCategoryEntity Category { get; set; }
        public RecommendedAmountPerDayEntity RecommendedAmountPerDay { get; set; }
    }
}
