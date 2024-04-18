using LocadoraAPI.Interfaces;
using LocadoraAPI.Repositories;
using LocadoraAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<Context>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRentalService, RentalService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
