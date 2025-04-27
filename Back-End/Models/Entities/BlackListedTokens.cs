namespace Models.Entities
{
    public class BlackListedTokens
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
