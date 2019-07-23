using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Globalization;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";
        private int messagesAppended;
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }
        private ConsoleAppender()
        {
            this.messagesAppended = 0;
        }

        public ConsoleAppender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string
                .Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);
            Console.WriteLine(formattedMessage);
            this.messagesAppended++;
        }
    }
}
