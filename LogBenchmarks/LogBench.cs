using BenchmarkDotNet.Attributes;
using Serilog;
using Serilog.Data;

namespace LogBenchmarks;

[MemoryDiagnoser]
public class LogBench
{
    private ILogger logger;
    private int number = 10;

    [GlobalSetup]
    public void Setup()
    {
        logger = new LoggerConfiguration()
            .MinimumLevel.Error()
          .WriteTo.Console()
          .CreateLogger();
    }

    [Benchmark]
    public void BenchmarkPlainTextLog()
    {
        
        logger.Information("Teste de log");
    }

    [Benchmark]
    public void BenchmarkStringInterplolationLog()
    {

        logger.Information($"Teste de log {number}");
    }

    [Benchmark]
    public void BenchmarkStringConcatenatedLog()
    {
        logger.Information($"Teste de log "+ number);
    }

    [Benchmark]
    public void BenchmarkPlainTextLogDisabled()
    {
        if (logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            logger.Information("Teste de log");
    }

    [Benchmark]
    public void BenchmarkStringInterplolationLogDisabled()
    {
        if (logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            logger.Information($"Teste de log {number}");
    }

    [Benchmark]
    public void BenchmarkStringConcatenatedLogDisabled()
    {
        if (logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            logger.Information($"Teste de log " + number);
    }
}