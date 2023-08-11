using AuthorizationService.Data;
using Gateway.AsyncDataServices;
using Gateway.Data;
using Gateway.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

Console.WriteLine($"--> Environment: {builder.Environment.EnvironmentName}");
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountConn")));

builder.Services.AddScoped<IAuthorizationRepo, AuthorizationRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);
app.Run();

