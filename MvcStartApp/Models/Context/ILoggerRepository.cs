using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Context
{
    public interface ILoggerRepository
    {
        public Task AddLogData(HttpContext context);

    }
}
