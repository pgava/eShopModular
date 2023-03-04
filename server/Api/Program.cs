using Autofac;
using Autofac.Extensions.DependencyInjection;
using EShopModular.Api;
using EShopModular.Api.Configuration.ExecutionContext;
using EShopModular.Common.Application;
using Microsoft.AspNetCore.HttpOverrides;

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
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new EShopAutofacModule()));

var app = builder.Build();

var container = app.Services.GetAutofacRoot();

app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());

// Register all dependencies
ContainerManager.InitializeModules(container, logger, configuration);

// nginx reverse proxy
var forwardedHeaderOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeaderOptions.KnownNetworks.Clear();
forwardedHeaderOptions.KnownProxies.Clear();
app.UseForwardedHeaders(forwardedHeaderOptions);

app.UseMiddleware<CorrelationMiddleware>();

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