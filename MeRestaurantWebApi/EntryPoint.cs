using MeRestaurantWebApi;

internal class EntryPoint
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.Map("/testconnection", () =>
        {
            return "Connected!";
        });
        app.MapControllers();
        app.Run();
    }
}