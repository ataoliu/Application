using Application.Service.DataManager;
using Application.Service.UserManager;



namespace Application.API.Util
{
    public static class BuildService
    {
        public static void AddApplicationService(this WebApplicationBuilder builder)
        {
            IServiceCollection? service = builder.Services;
            service.AddSingleton<UserService>();
            service.AddSingleton<ClaimsIdentityService>();
            service.AddSingleton<Service.DataManager.CorsService>();


        }
    }
}

