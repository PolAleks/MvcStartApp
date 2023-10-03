using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using MvcStartApp.BLL.Services;
using MvcStartApp.Models.Context;
using MvcStartApp.Models.Db;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcStartApp.Web.IntegrationTests
{
    [TestFixture]
    public class LogsControllerTests
    {
        [Test]
        public async Task Index_SendRequest_ShouldReturnNotNull()
        {
            // Arrange
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            // Act
            HttpResponseMessage response = await httpClient.GetAsync("logs");

            // Assert
            Assert.IsNotNull(response);
        }

    }
}
