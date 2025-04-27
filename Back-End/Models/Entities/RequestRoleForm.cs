namespace Models.Entities
{
    public class RequestRoleForm
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int RoleId { get; set; }
        public int RequestId { get; set; }

        public Form? Form { get; set; }
        public Role? Role { get; set; }
        public Request? Request { get; set; }
        public ICollection<GroupRoleAuth>? GroupRoleAuths { get; set; }
    }


}
