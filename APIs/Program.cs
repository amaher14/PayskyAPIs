using Hangfire;
using Jizan.Voting.APIs.ConfigurationServices;
using Core.Interfaces.IMobileServices;
using APIs.Middlewares;
using Application.ConfigurationServices;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();



//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(TokenDecryptionMiddleware));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
