// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
//using EasyArchitectCore.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfigurationRoot configuraiton = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

var builder = Host.CreateApplicationBuilder(args);  
builder.Services.AddScoped<EasyArchitectCore.Core.ConfigurationManager>(configure => new EasyArchitectCore.Core.ConfigurationManager(null, configuraiton, null))
                .BuildServiceProvider();

var serviceProvider = builder.Build().Services;
var logger = serviceProvider.GetRequiredService<EasyArchitectCore.Core.ConfigurationManager>();

//do the actual work here
string minutes = EasyArchitectCore.Core.ConfigurationManager.AppSettings["TimeoutMinutes"];
Console.WriteLine($"ASP.NET Core Host Timeout minutes id {minutes}");
Console.ReadLine();
