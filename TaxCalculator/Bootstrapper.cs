using System;
using Autofac;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculator.Views;

namespace TaxCalculator
{
    public static class Bootstrapper
    {
		public static void Initialize()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

			containerBuilder.RegisterType<MainPage>();
			containerBuilder.RegisterType<TaxCalculatorView>();
			containerBuilder.RegisterType<TaxOrderView>();

			//Service Injection
			containerBuilder.RegisterType<TaxService>();

			var container = containerBuilder.Build();
			Resolver.Initialize(container);
		}
	}
}
