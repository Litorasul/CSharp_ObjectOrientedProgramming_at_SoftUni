using System;

namespace P04.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] toCall = Console.ReadLine()
                .Split();

            string[] toBrowse = Console.ReadLine()
                .Split();

            var phone = new Smartphone();
            foreach (var number in toCall)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in toBrowse)
            {
                try
                {
                    Console.WriteLine(phone.Browse(site));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                  
                }
            }
        }
    }
}
