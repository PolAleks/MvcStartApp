using Microsoft.AspNetCore.Http;

namespace MvcStartApp.BLL.Services
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        // Поле для хранение ошибок
        public string Description { get; set; }

        // Код ошибки
        public StatusCode StatusCode { get; set; }

        // Хранит результат запроса
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get; }
    }
}