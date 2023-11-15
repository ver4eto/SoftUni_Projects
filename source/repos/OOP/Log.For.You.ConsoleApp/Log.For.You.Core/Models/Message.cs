using LogForYou.Core.Enums;
using LogForYou.Core.Exceptions;
using LogForYou.Core.Utils;


namespace LogForYou.Core.Models
{
    public class Message
    {
        private string _createdtime;
        private string _text;
        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string CreatedTime
        {

            get => this._createdtime;

            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }
                if (!DateTimeValidator.ValidateDateTimeFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                this._createdtime = value;
            }
        }
        public string Text
        {
            get => this._text;

            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                this._text = value;
            }
        }
        public ReportLevel ReportLevel { get; set; }
    }
}
