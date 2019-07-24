using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Models.Logger(appenders);
            Engine engine = new Engine(logger);

            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount,
            ICollection<IAppender> appenders,
            AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelString = "INFO";

                if (appenders.Count == 3)
                {
                    levelString = appendersInfo[2];
                }
               
                try
                {
                    IAppender appender = appenderFactory
                        .GetAppender(appenderType, layoutType, levelString);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
