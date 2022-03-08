using System;
using Autofac;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;

namespace TaxCalculator
{
    public static class Bootstrapper
    {
		public static void Initialize()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

			containerBuilder.RegisterType<MainPage>();
			//containerBuilder.RegisterType<TaxCalculatorPage>();
			//containerBuilder.RegisterType<TaxOrderPage>();

			//Service Injections
			containerBuilder.RegisterType<TaxService>();
			//containerBuilder.RegisterType<MessageService>();

			var container = containerBuilder.Build();
			Resolver.Initialize(container);
		}
	}
}
