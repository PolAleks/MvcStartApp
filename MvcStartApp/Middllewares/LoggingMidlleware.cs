    using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using MvcStartApp.DAL.Interfaces;
using MvcStartApp.BLL.Services;

namespace MvcStartApp.Middlewares
{
    public class LoggingMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestServices _requestServices;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMidlleware(
            RequestDelegate next, 
            IRequestServices requestServices)
        {
            _next = next;
            _requestServices = requestServices;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Запись лога в базу данных при помощи сервиса вынесенного в слой BLL
            await _requestServices.AddRequestData(context);

            LogConsole(context);
            await LogFile(context);

            await _next.Invoke(context);
        }
        /// <summary>
        /// Логирование данных о запросе в консоль
        /// </summary>
        /// <param name="context"></param>
        private static void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        /// <summary>
        /// Логирование данных о завросе в файл
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static async Task LogFile(HttpContext context)
        {
            // Логирование в файл
            string fileLogger = "RequestLog.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs", fileLogger);

            string log = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            await File.AppendAllTextAsync(path, log);
        }
    }
}
