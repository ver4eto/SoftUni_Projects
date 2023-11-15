
using System.Globalization;


namespace LogForYou.Core.Utils
{
    public static class DateTimeValidator
    {
        //Така се запазват само в паметта и като приключим програмата те се изтриват. Ако искаме да ги запишем , без да ги губим трябва да се запишат във файл.
        private static readonly ISet<string> formats = new HashSet<string> 
        { "M/dd/yyyy h:mm:ss tt" };
        //"M/dd/yyyy h:mm:ss tt"

        public static void AddFormat(string format) => formats.Add(format);
        public static bool ValidateDateTimeFormat(string dateTime)
        {
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(dateTime,format,  CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                { 
                    return true;
                }               

            }
                   return false;
        }
    }
}
