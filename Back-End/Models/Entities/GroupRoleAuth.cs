namespace Models.Entities
{
    public class GroupRoleAuth
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int RequestRoleFormId { get; set; }
        public string Action { get; set; } = "Allow";

        public Group? Group { get; set; }
        public RequestRoleForm? RequestRoleForm { get; set; }
    }

}
