using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.DAL.Interfaces
{
    public interface ILoggerRepository
    {
        public Task<bool> AddLogData(HttpContext context);
        public Task<List<Request>> GetLogData();
    }
}
