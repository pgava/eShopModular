using Autofac;
using Autofac.Extensions.DependencyInjection;
using eShopCmc.Api;
using eShopCmc.Api.Configuration.ExecutionContext;
using eShopCmc.Api.Controllers;
using eShopCmc.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Register Autofac 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

Serilog.ILogger logger = CreateLogger.GetLogger();

IConfiguration configuration = CreateConfiguration.GetConfiguration(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

// Need to register EShopCmcModule first because is used by the controllers
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new EShopCmcAutofacModule()));

var app = builder.Build();

var container = app.Services.GetAutofacRoot();

app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());

// Register all dependencies
ContainerManager.InitializeModules(container, logger, configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();