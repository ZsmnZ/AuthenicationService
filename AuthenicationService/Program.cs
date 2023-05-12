using AuthenicationService;
using AuthenicationService.Repopsitory;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddConfigureService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseLogMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
public static class ServicesProvider
{
    public static void AddConfigureService(this IServiceCollection services)
    {
        services.AddSingleton<AuthenicationService.ILogger, Logger>();
        services.AddSingleton<IUserRepository, UserRepository>();
        var mapperConfig = new MapperConfiguration((v) =>
        {
            v.AddProfile(new MappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddAuthentication(options => options.DefaultScheme = "Cookies")
            .AddCookie("Cookies", options =>
            {
                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });
    }
}