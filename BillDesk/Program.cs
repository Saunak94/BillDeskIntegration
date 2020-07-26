using System;

namespace BillDesk
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program Starting");
            Console.ReadLine();
            Integration billDeskInegation = new Integration();
            var response = billDeskInegation.CreateHMAC().Result;
            Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
