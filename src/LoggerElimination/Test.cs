namespace LoggerElimination;

internal class Test
{
    private ILogger Logger { get => GetStaticLogger<Test>(); }

    public void LogTest() => Logger.LogInformation("It works!");
}

internal class Test2
{
    private readonly ILogger<Test> logger;

    public Test2(ILogger<Test> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogTest() => logger.LogInformation("It works!");
}