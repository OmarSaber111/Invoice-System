namespace Models.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public string? RequestName { get; set; }

        public ICollection<RequestRoleForm>? RequestRoleForms { get; set; }
        //public ICollection<GroupRoleAuth>? GroupRoleAuths { get; set; }
    }

}
