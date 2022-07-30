namespace Application.API.Util
{
    public static class CorsService
    {
        public static void AddCorsService(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var result = bool.Parse(configuration["Cors"]);
            if (result)
            {
                builder.Services.AddCors(policy =>
                {
                    policy.AddPolicy("CorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                    //policy.AddPolicy("CorsPolicy", opt => opt.WithOrigins(ipAddresses.ToArray()).AllowAnyHeader().AllowAnyMethod());
                });
            }
        }
    }
}

