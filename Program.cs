using Microsoft.Extensions.DependencyInjection; 
using ECommerce_console.controllers;
using ECommerce_console.services;
using ECommerce_console.Views;

var serviceProvider = new ServiceCollection()
    .AddScoped<IProductsService, ProductsService>()
    .AddScoped<ProductView>()
    .AddScoped<ProductController>()
    .BuildServiceProvider();

var controller = serviceProvider.GetService<ProductController>();

await controller.InitApplication();