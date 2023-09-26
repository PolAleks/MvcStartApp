using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Context
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
