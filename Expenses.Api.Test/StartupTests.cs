using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Expenses.Api.Test
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void ConfigureServicesTest()
        {
            // Arrange
            IWebHost webHost = WebHost.CreateDefaultBuilder()
                                .UseStartup<Startup>().UseEnvironment(Environments.Development)
                                .UseDefaultServiceProvider(options =>
                                 options.ValidateScopes = false)
                                .Build();

            IHostEnvironment hostEnvironment = webHost.Services.GetRequiredService<IHostEnvironment>();

            // Assert
            Assert.IsNotNull(webHost);
            Assert.IsNotNull(hostEnvironment);
            Assert.AreEqual(Environments.Development, hostEnvironment.EnvironmentName);

        }

        [TestMethod]
        public void ConfigureTest()
        {
            // Arrange
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.Environment.EnvironmentName = Environments.Development;

            Startup.ConfigureServices(builder.Services);
            WebApplication app = builder.Build();

            // Act
            Startup.Configure(app, builder.Environment);

            // Assert
            Assert.IsTrue(app.Environment.IsDevelopment());
        }
    }
}
