using System;
using System.Collections.Generic;

namespace CATtask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to send a notfication? (yes/no)");
            string answer = Console.ReadLine()?.ToLower();

            if (answer == "yes")
            {
              
                NotficationFactory notficationFactory = new NotficationFactory();
                notficationFactory.AddChannel();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }

    public interface INotficationChannel
    {
        void Send();
    }

    public class Email : INotficationChannel
    {
        public void Send()
        {
            Console.WriteLine("Sending message...");
            Console.WriteLine("Email sent successfully!");
        }
    }

    public class SMS : INotficationChannel
    {
        public void Send()
        {
            Console.WriteLine("Sending message...");
            Console.WriteLine("SMS sent successfully!");
        }
    }

    public class PushNotfications : INotficationChannel
    {
        public void Send()
        {
            Console.WriteLine("Sending message...");
            Console.WriteLine("Push Notification sent successfully!");
        }
    }

    public class NotficationManager
    {
        
        private List<INotficationChannel> channels = new List<INotficationChannel>();

        public void SendNotfication(INotficationChannel channel)
        {
   
            channels.Add(channel);
            channel.Send();
        }

        public void SendAllNotfications()
        {
            if (channels.Count == 0)
            {
                Console.WriteLine("\nNo previous channels used to send notifications.");
                return;
            }

            Console.WriteLine("\nResending through all previously used channels");
            foreach (var channel in channels)
            {
                channel.Send();
            }
        }
    }
    
    public class NotficationFactory
    {
        private NotficationManager notficationManager = new NotficationManager();

        public void AddChannel()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a notfication type to send:");
                Console.WriteLine("1). Email");
                Console.WriteLine("2). SMS");
                Console.WriteLine("3). Push Notfication");
                Console.WriteLine("4). Send to all previous channels");
                Console.WriteLine("5). Exit");

                Console.Write("\nYour Choice: ");
                string choice = Console.ReadLine();

                if (choice == "5") break;
                switch (choice)
                {
                    case "1":
                        notficationManager.SendNotfication(new Email());
                        break;
                    case "2":
                        notficationManager.SendNotfication(new SMS());
                        break;
                    case "3":
                        notficationManager.SendNotfication(new PushNotfications());
                        break;
                    case "4":
                        notficationManager.SendAllNotfications();
                        break;
                    default:
                        Console.WriteLine("\nINVALID CHOICE! Please enter a number from 1 to 5.");
                        break;
                }
            }
            Console.WriteLine("Finished Notification Process.");
        }
    }
}

