using System.Reflection;
using eShopCmc.Application.Contracts;
using eShopCmc.Application.Countries.GetCountries;
using eShopCmc.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(
    typeof(GetAllCountriesQueryHandler).GetTypeInfo().Assembly
);
builder.Services.AddScoped<IEShopCmcModule, EShopCmcModule>();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());

app.MapControllers();

app.Run();
