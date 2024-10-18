using LojaDoSeuManoel.Application.AppServices;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.DomainServices;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LojaDoSeuManoel.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICaixaDomainService, CaixaDomainService>();
            services.AddSingleton<ICaixasAppService, CaixasAppService>();
        }
    }
}
