using System.Text;

namespace MailClient
{
    public class Mail
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body {  get; set; }

        public Mail(string sender, string receiver, string body)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Body = body;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"From: {Sender} / To: {Receiver}");
            stringBuilder.AppendLine($"Message: {Body}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
