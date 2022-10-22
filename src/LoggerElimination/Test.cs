namespace LoggerElimination;

internal class Test
{
    private ILogger Logger { get => GetStaticLogger<Test>(); }

    public void LogTest()
    {
        Logger.LogInformation("It works!");
    }
}