using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Concrete;
using RentACarPro.Business.DependencyResolvers.Autofac;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder => 
            {
                builder.RegisterModule<AutofacBusinessModule>();
            });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddCoreModules(new ICoreModule[]
{
    new CoreModule()
});

// for manual service providing
ServiceTool.SetProvider(builder.Services);

/// <summary>
/// WinForm service providing
/// </summary>

//var winformServices = new ServiceCollection();
//var containerBuilder = new ContainerBuilder();

//containerBuilder.Populate(
//    winformServices.AddCoreModules(new ICoreModule[]
//{
//    new CoreModule()
//}));
//containerBuilder.RegisterModule<AutofacBusinessModule>();

//ServiceTool.SetProvider(new AutofacServiceProvider(containerBuilder.Build()));

//var testA = ServiceTool.ServiceProvider.GetService<IUserService>();
//var testB = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
