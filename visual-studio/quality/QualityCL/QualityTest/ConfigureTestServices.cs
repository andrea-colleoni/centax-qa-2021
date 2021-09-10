using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityTest
{
    class ConfigureTestServices
    {
        public IServiceProvider Services { get; private set; }

        public ConfigureTestServices()
        {
            var host = Host.CreateDefaultBuilder(null)
                .ConfigureHostConfiguration(config =>
                    config.AddJsonFile("appsettings.json", false, false)
                )
                .ConfigureServices((hostConfiguration, services) => {
                    //var mock = new Mock<DbContext>();
                })
                .Build();
            Services = host.Services;
        }
    }
}
