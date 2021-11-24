using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string email, string name)
        {
            Email = email;
            Username = name;
        }

        public string Email { get; set; }
        public string Username { get; set; }
    }
}
