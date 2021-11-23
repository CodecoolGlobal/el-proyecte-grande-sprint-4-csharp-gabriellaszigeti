using el_proyecte_grande_sprint_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationContext _context;

        public AuthenticationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.AddAsync(user);
            _context.SaveChanges();
        }
    }
}
