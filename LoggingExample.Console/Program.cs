// See https://aka.ms/new-console-template for more information

using LoggingExample.Core;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()          
          .AddTransient<ILoggerEngine, TextFileLogger>()
          .BuildServiceProvider();

var Logger = serviceProvider.GetService<ILoggerEngine>();

Task.Run(async () => await Logger.Write("Hello, World!", LogField.NotDefined));
Console.WriteLine("Hello, World!");
Console.ReadLine();
