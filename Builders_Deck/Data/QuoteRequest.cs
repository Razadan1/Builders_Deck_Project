namespace Builders_Deck.Data
{
    public class QuoteRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Message { get; set; }
    }
}
