using System.Collections.Concurrent;

namespace LoggerElimination;

internal static class StaticLoggerFactory
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