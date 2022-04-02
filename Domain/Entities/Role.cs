using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<User> Usuarios { get; set; }
        //public Role()
        //{
        //    Usuarios = new HashSet<User>();
        //}
    }
}
