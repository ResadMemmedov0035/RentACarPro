using Autofac;
using Autofac.Extensions.DependencyInjection;
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

var app = builder.Build();

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
