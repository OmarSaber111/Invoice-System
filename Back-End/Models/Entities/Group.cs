using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }

        public ICollection<GroupUser>? GroupUsers { get; set; }
        public ICollection<GroupRoleAuth>? GroupRoleAuths { get; set; }
    }

}
