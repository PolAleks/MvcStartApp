using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MvcStartApp.Models.Db
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Now;
        public string Url { get; set; }

        public Request(string url)
        {
            Url = url;
        }
    }
}
