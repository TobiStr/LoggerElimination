# LoggerElimination
## How to eliminate injecting ILogger everywhere in .NET

Simply create a static class, that holds a Dictionary<Type, ILogger> and initialize a static LoggerFactory from your Startup Logic.

```csharp
public static class StaticLogger
{
    private static ILoggerFactory _loggerFactory;

    private static ConcurrentDictionary<Type, ILogger> loggerByType = new();

    public static void Initialize(ILoggerFactory loggerFactory)
    {
        if (_loggerFactory is not null)
            throw new InvalidOperationException("StaticLogger already initialized!");

        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

    public static ILogger GetStaticLogger<T>()
    {
        if (_loggerFactory is null)
            throw new InvalidOperationException("StaticLogger is not initialized yet.");

        return loggerByType
            .GetOrAdd(typeof(T), _loggerFactory.CreateLogger<T>());
    }
}
```
