﻿using System;
using Autofac;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculator.Views;

namespace TaxCalculator
{
    public static class RegisterDependencies
    {
		public static void Initialize()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

			containerBuilder.RegisterType<MainPage>();
			containerBuilder.RegisterType<TaxCalculatorView>();
			containerBuilder.RegisterType<TaxOrderView>();
			containerBuilder.RegisterType<TaxOrderDetailsView>();

			//Service Injection
			containerBuilder.RegisterType<TaxService>();
			containerBuilder.RegisterType<DialogService>();

			var container = containerBuilder.Build();
            Resolver.Initialize(container);
		}
	}
}
