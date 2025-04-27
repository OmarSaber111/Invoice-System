namespace Models.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RequestRoleForm>? RequestRoleForms { get; set; }
        //public ICollection<GroupRoleAuth>? GroupRoleAuths { get; set; }
    }

}
