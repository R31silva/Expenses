using Microsoft.Extensions.Hosting;

namespace Expenses.Api.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CreateHostBuilderShouldReturnIHostBuilder()
        {
            // Act
            IHostBuilder hostBuilder = Program.CreateHostBuilder([]);

            // Assert
            Assert.IsNotNull(hostBuilder);
            Assert.IsInstanceOfType(hostBuilder, typeof(IHostBuilder));
        }

        [TestMethod]
        public void CreateHostBuilderShouldBuildHostSuccessfully()
        {
            // Act
            using IHost host = Program.CreateHostBuilder([]).Build();

            // Assert
            Assert.IsNotNull(host);
        }
    }
}