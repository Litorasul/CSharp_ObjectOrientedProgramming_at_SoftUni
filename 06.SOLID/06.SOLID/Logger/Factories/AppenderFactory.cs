﻿using Logger.Exeptions;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Files;
using System;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeExeption();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")          
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeExeption();
            }

            return appender;
        }
    }
}
