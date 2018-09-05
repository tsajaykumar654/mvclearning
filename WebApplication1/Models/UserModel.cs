using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}