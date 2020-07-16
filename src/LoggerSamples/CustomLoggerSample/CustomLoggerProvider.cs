using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        ILogger m_logger;
        IConfiguration m_config;
        private bool m_disposed = false; // To detect redundant calls

        public CustomLoggerProvider(IConfiguration configuration)
        {
            m_config = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (null == m_logger)
            {
                // do some work against config to initialize logging

                m_logger = new CustomLogger();
            }

            return m_logger;
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_logger = null;
                }

                m_disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
