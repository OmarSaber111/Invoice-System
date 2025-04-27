namespace ApiContract.Dtos
{
    public class GroupPermissionDTO
    {

        public int GroupId { get; set; }
        public int RequestRoleFormId { get; set; }

        public string? Action { get; set; }
    }
}
