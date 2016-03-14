using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Model
{
    public class AppUser
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }

    public enum Role : int
    {
        Staff = 0,
        Publisher = 1,
        Admin = 2
    }
}
