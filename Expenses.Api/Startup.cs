namespace Expenses.Api
{
    public class Startup(IConfiguration configuration)
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}