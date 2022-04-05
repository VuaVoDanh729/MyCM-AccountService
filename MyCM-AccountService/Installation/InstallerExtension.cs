using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCM_AccountService.Installation
{
    public static class InstallerExtension
    {
        public static void InstallerServicesInAssemly(this IServiceCollection services, IConfiguration configuration)
        {
            var installer = typeof(Startup).Assembly.ExportedTypes
                .Where(a => typeof(IInstaller).IsAssignableFrom(a) && !a.IsAbstract && !a.IsInterface)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(a => a.InstallerService(services, configuration));
        }

    }
}
