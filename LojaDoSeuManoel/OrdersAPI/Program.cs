using Infrastructure.Repositories;
using LojaDoSeuManoel.Application.AppServices;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.DomainServices;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using PedidosAPI.Handlers;
using PedidosAPI.NewFolder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Autenticação básica usando cabeçalho"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DI APPServices
builder.Services.AddSingleton<IPedidosAppService, PedidosAppService>();
builder.Services.AddSingleton<ICaixasAppService, CaixasAppService>();

//DI DomainServices
builder.Services.AddSingleton<ICaixaDomainService, CaixaDomainService>();

//DI Repositories
builder.Services.AddSingleton<ICaixaRepository, CaixaRepository>();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAuthorization();

builder.Services.AddSingleton<TimeProviderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
