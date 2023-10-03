using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MvcStartApp.DAL.Interfaces;
using System.Collections.Generic;

namespace MvcStartApp.Models.Context
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly BlogContext _context;
        private readonly DbSet<Request> _request;
        public LoggerRepository(BlogContext context)
        {
            _context = context;
            _request = context.Requests;
        }

        public async Task<bool> AddLogData(HttpContext context)
        {
            Request request = GetRequest(context);

            EntityEntry entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
            {
                await _request.AddAsync(request);
            }
            else
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Request>> GetLogData()
        {
            return await _context.Requests.ToListAsync();
        }

        private static Request GetRequest(HttpContext context)
        {
            Request request = new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = String.Concat("http://", context.Request.Host.Value, context.Request.Path)
            };

            return request;
        }
    }
}
