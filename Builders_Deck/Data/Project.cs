namespace Builders_Deck.Data
{
    public class Project
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public DateTime CompletionDate { get; set; }
        public required string ContractorName { get; set; }
    }

}
