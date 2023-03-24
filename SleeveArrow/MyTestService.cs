using Microsoft.Extensions.Logging;
using SleeveArrow.IOC;

namespace SleeveArrow;

public class MyTestService : IMyTestService
{
    private ILogger<MyTestService> _logger;

    public MyTestService(ILogger<MyTestService> logger)
    {
        _logger = logger;
    }

    public void WriteLog(string message)
    {
        _logger.LogDebug(message);
    }
}

public interface IMyTestService : ITransientDependency
{
    void WriteLog(string message);
}