namespace Builders_Deck.Data
{
    public class Contractor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public decimal Budget { get; set; }
        public required string Specialty { get; set; }
    }

}
