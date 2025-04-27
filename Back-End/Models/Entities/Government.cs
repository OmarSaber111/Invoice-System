using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Government
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Seller>? Sellers { get; set; }
    }

}
