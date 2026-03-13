namespace Expenses
{
    public static class Program
    {

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static void SetupConfig(this IConfigurationBuilder configurationBuilder, IHostEnvironment hostEnvironment)
        {
            configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configurationBuilder.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
            configurationBuilder.AddEnvironmentVariables();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) => builder.SetupConfig(context.HostingEnvironment))
                .ConfigureWebHostDefaults(webBuilder => _ = webBuilder.UseStartup<Startup>());
    }
}
