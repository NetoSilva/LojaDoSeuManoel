using Microsoft.Extensions.DependencyInjection;

namespace LojaDoSeuManoel.Tests
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider { get; }

        public TestBase()
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
