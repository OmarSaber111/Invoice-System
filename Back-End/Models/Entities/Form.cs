namespace Models.Entities
{
    public class Form
    {
        public int FormId { get; set; }
        public string? FormName { get; set; }
        public string? Description { get; set; }

        public ICollection<RequestRoleForm>? RequestRoleForms { get; set; }
        //public ICollection<GroupRoleAuth>? GroupRoleAuths { get; set; }
    }

}
