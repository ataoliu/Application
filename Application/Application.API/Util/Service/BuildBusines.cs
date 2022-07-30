using Application.Busines.DataManager;
using Application.Busines.UserManager;
using Application.IBusines.DataManager;

namespace Application.API.Util
{
    public static class BuildBusines
	{

		public static void AddApplicationBusines(this WebApplicationBuilder builder)
		{
			IServiceCollection? service = builder.Services;
			service.AddSingleton<UserBLL>();
			service.AddSingleton<ClaimsIdentityBLL>();
			service.AddSingleton<CorsBLL>();
        }
	}
}

