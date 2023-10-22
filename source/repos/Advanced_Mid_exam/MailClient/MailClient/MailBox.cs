using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public MailBox(int capacity)
        {
            Inbox = new List<Mail>(Capacity);
            Archive = new List<Mail>();
            Capacity = capacity;
        }

        public void IncomingMail(Mail mail)
        {
            int currentCapacity = Inbox.Count();
            if (currentCapacity < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail currentMail = Inbox.FirstOrDefault(x => x.Sender == sender);
            if (currentMail == null)
            {
                return false;
            }
            else
            {
                Inbox.Remove(currentMail);
                return true;
            }
        }

        public int ArchiveInboxMessages()
        {
            int countOfMailArchived = 0;

            foreach (Mail mail in Inbox)
            {
                Archive.Add(mail);
                countOfMailArchived++;
            }
            Inbox.Clear();
            return  countOfMailArchived;
        }

        public string GetLongestMessage()
        {
            Mail currentMail = Inbox.OrderByDescending(m => m.Body.Length).First();
            return currentMail.ToString();
        }

        public string InboxView()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                stringBuilder.AppendLine(mail.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
