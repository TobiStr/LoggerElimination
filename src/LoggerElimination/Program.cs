using LoggerElimination;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddLogging(b => b.AddConsole())
    .AddSingleton<Test>();

var serviceProvider = services.BuildServiceProvider();

StaticLoggerFactory.Initialize(serviceProvider.GetRequiredService<ILoggerFactory>());

var test = serviceProvider.GetRequiredService<Test>();
test.LogTest();

var test2 = serviceProvider.GetRequiredService<Test2>();
test2.LogTest();

Console.ReadLine();