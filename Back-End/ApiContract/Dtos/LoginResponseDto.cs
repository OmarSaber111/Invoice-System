namespace ApiContract.Dtos
{
    public class LoginResponseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int? SellerId { get; set; }
        public int? BuyerId { get; set; }

        public List<FormPermissionDto> AllowedForms { get; set; } = new();
    }
}
