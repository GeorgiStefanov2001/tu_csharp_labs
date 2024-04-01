using System;

namespace PrCSharp_lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            Console.WriteLine("Create Contact");
            Console.WriteLine("Create Message");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Contact Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Contact Age: ");
                    int age = int.Parse(Console.ReadLine());
                    var Contact = new Contact(name, age);

                    //add contact to db
                    break;
                case 2:
                    Console.Write("Enter Contact Name: ");
                    var author = new Contact("test", 12); // get it from db

                    Console.Write("Enter Message Text: ");
                    string text = Console.ReadLine();
                    var message = new Message(author, text);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
