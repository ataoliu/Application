using Application.API.Util;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();//httpcontext
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.AddApplicationInit();//applicationservice
builder.SwaggerService(); //swagger
builder.AddAuthenticationService();//Authentication
builder.AddCorsService();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseCors("CorsPolicy");
app.UseCorsMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorizeMiddleware();
app.MapControllers();

app.Run();

