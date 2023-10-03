using Microsoft.AspNetCore.Http;
using MvcStartApp.DAL.Interfaces;
using MvcStartApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcStartApp.BLL.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly ILoggerRepository _loggerRepository;

        public RequestServices(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        public async Task<IBaseResponse<bool>> AddRequestData(HttpContext httpContext)
        {
            var response = new BaseResponse<bool>();
            try
            {
                bool isSaveLog = await _loggerRepository.AddLogData(httpContext);
                if (isSaveLog)
                {
                    response.Description = "Запись Log успешно внесена в базу данных";
                    response.Data = true;
                    response.StatusCode = StatusCode.OK;
                }
                response.Description = "Что-то пошло не так...";
                response.StatusCode = StatusCode.InternalServerError;
                response.Data = false;
            }
            catch (Exception ex)
            {
                response.Description = $"В методе [AddRequestModelData] возникла ошибка: {ex.Message}";
                response.Data = false;
                response.StatusCode = StatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<IBaseResponse<List<Request>>> GetRequestAsync()
        {
            var response = new BaseResponse<List<Request>>();
            try
            {
                var requests = await _loggerRepository.GetLogData();
                if (requests.Count == 0)
                {
                    response.Description = "Найдено 0 элементов";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                    response.Data = requests;
                    response.StatusCode = StatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.Description = $"\"В методе [GetRequestModelAsync] возникла ошибка: {ex.Message}";
                response.StatusCode = StatusCode.InternalServerError;
            }
            return response;
        }

    }
}
