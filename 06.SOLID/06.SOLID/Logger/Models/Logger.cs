﻿using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        ICollection<IAppender> appenders;

        public IReadOnlyCollection<IAppender> Appenders =>
            (IReadOnlyCollection<IAppender>)appenders;

        public Logger( ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (var appender in this.Appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}