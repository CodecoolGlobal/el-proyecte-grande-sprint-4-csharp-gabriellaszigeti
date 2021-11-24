using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Repository
{
    public interface IAuthenticationRepository
    {
        Task AddUser(User user);
    }
}