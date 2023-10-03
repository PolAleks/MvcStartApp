using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.BLL.Services
{
    public interface IRequestServices
    {
        Task<IBaseResponse<List<Request>>> GetRequestAsync();
        Task<IBaseResponse<bool>> AddRequestData(HttpContext httpContext);
    }
}
