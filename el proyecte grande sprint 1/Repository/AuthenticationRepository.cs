using el_proyecte_grande_sprint_1.Data;
using el_proyecte_grande_sprint_1.Models.DTO;
using el_proyecte_grande_sprint_1.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationContext _context;
        private readonly IUtility _utility;
        public AuthenticationRepository(ApplicationContext context, IUtility utility)
        {
            _context = context;
            _utility = utility;
        }

        public async Task AddUser(User user)
        {
            user.Password = _utility.HashPassword(user.Password);
            await _context.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<bool> CheckIfUserAlreadyRegistered(UserDTO partialUserData)
        {
            return await  _context.Users.AnyAsync(user => user.Email == partialUserData.Email || user.Username == partialUserData.Username);

        }
    }
}
