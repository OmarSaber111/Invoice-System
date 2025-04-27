namespace ApiContract.Dtos
{
    public class UpdateSellerDto
    {
        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? StoreName { get; set; }
        public string? TypeOFProduct { get; set; }
        public int GovernmentId { get; set; }
    }
}
