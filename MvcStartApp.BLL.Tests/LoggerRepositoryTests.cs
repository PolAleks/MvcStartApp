using Microsoft.AspNetCore.Http;
using Moq;
using MvcStartApp.DAL.Interfaces;
using MvcStartApp.Models.Context;
using MvcStartApp.Models.Db;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStartApp.BLL.Tests
{
    [TestFixture]
    public class LoggerRepositoryTests
    {
   
        [Test]
        public async Task GetLogData_MustBeReturn_ListRequests()
        {
            // Arrange
            List<Request> requests = new()
            {
                new Request() {Id = Guid.NewGuid(), Date = new DateTime(2023-01-01), Url = @"http://localhost:5001/"},
                new Request() {Id = Guid.NewGuid(), Date = new DateTime(2023-02-02), Url = @"http://localhost:5001/logs"},
                new Request() {Id = Guid.NewGuid(), Date = new DateTime(2023-03-03), Url = @"http://localhost:5001/Home/Privacy"}
            };

            // Act
            var mock = new Mock<ILoggerRepository>();
            mock.Setup(log => log.GetLogData()).ReturnsAsync(requests);

            // Assert
            Assert.AreEqual(await mock.Object.GetLogData(), requests);

        }

    }
}
