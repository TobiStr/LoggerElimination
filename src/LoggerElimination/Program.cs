using LoggerElimination;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddLogging(b => b.AddConsole())
    .AddSingleton<Test>();

var serviceProvider = services.BuildServiceProvider();

StaticLogger.Initialize(serviceProvider.GetRequiredService<ILoggerFactory>());

var test = serviceProvider.GetRequiredService<Test>();
test.LogTest();

Console.ReadLine();