
using Telephony;

public class StartUp
{
    public static void Main(string[] args)
    {

        string[] phoneNumbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
        string[] pwebsites= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


      
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone(phoneNumber);
                    Console.WriteLine(stationaryPhone.CallPhone(phoneNumber));
                }
                else if(phoneNumber.Length==10)
                {
                    Smartphone smartphone = new Smartphone(phoneNumber, string.Empty);
                    Console.WriteLine(smartphone.CallPhone(phoneNumber));
                }
            else
            {
                Console.WriteLine("Invalid number!");
            }
            }


        try
        {
            foreach (string phoneNumber in pwebsites)
            {
                Smartphone smartphone = new Smartphone(string.Empty, phoneNumber);
                Console.WriteLine(smartphone.BrowsWeb(phoneNumber));
            }
        }
        catch ( Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
            
       
        
    }
    

    
}