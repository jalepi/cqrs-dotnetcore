using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Atma.Atlas.Startup))]

namespace Atma.Atlas
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSwashBuckle(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
