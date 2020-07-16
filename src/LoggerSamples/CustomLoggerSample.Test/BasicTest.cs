using System;
using Xunit;

namespace CustomLoggerSample.Test
{
    public class BasicTest
    {
        [Fact]
        public void TestLoggerProviderCreatesCustomLogger()
        {
            var provider = new CustomLoggerProvider(null);
            var logger = provider.CreateLogger("any");
            Assert.True(logger is CustomLogger);
        }
    }
}
