namespace ApiContract.Dtos
{
    public class FormPermissionDto
    {
        public int FormId { get; set; }
        public string FormName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public List<string> Actions { get; set; } = new();
    }
}
