using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.DAL.Interfaces
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
