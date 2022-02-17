using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace MinecraftBotManagerWPF.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = new ServiceCollection();
            services.AddSingleton<StartupVM>();
            services.AddSingleton<MainViewModel>();
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

        public StartupVM? Startup
        {
            get
            {
                return Ioc.Default.GetService<StartupVM>();
            }
        }

        public MainViewModel? MainViewModel
        {
            get
            {
                return Ioc.Default.GetService<MainViewModel>();
            }
        }
    }

}
