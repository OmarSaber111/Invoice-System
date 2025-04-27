namespace ApiContract.Dtos
{
    public class SignUpDTO
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NationalId { get; set; }
        public bool IsSeller { get; set; }


        public string? StoreName { get; set; }
        public string? ProductType { get; set; }
        public int GovernmentId { get; set; }



    }

}
