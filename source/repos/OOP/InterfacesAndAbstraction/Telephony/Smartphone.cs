

namespace Telephony
{
    public class Smartphone : IPhone, ISmartPhone
    {
        private string _phoneNumber;
        private string _address;

        public Smartphone( string phoneNumber, string webAddress)
        {
            WebSite = webAddress;
            Number = phoneNumber;
        }
        public string WebSite { get => this._address; 
            set 
            {
                bool hasDigit = value.Any(char.IsDigit);
                if (hasDigit)
                {
                    throw new ArgumentException("Invalid URL!"); 
                }
                this._address = value;
            } }
        public string Number { get => _phoneNumber;
            set 
            { 
                bool hasOnlyDigit = value.All(char.IsDigit);

                if (value.Length==10 && hasOnlyDigit)
                {
                    this._phoneNumber = value;
                }
                //else
                //{
                //    Console.WriteLine("Invalid number!");
                //}
            } }

        public string BrowsWeb(string site)
        {
            return $"Browsing: {site}!";
        }

        public string CallPhone(string number)
        {
            return $"Calling... {number}";
        }
    }
}
