using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDelegates.Example2
{
   
    internal class Notify
    {
        private static void MainMethod()
        {
            Publisher pub1 = new Publisher();
            pub1.Name = "Kaushik";

            Subscriber sub1 = new Subscriber();
            Subscriber sub2 = new Subscriber();
            Subscriber sub3 = new Subscriber();
            sub1.Subscribe(pub1);
            sub2.Subscribe(pub1);
            sub3.Subscribe(pub1);

            pub1.Notify("Thank you for subscribing");
            sub2.UnSubscribe(pub1);
            pub1.Notify("Subscriber 2 unsubscribed");

            Console.ReadLine();
        }
    }
    public class EventArguments : EventArgs
    {
        public string Message { get; set; }

        public EventArguments(string Message)
        {
            this.Message = Message;
        }
    }
    public class Publisher
    {
        public string Name { get; set; }

        public EventHandler<EventArguments> myEvent;

        public void Notify(string message)
        {
            if (myEvent != null)
            {
                myEvent(this, new EventArguments(message));
            }
        }
    }
    public class Subscriber
    {
        public void Subscribe(Publisher pub)
        {
            pub.myEvent += Update;
        }
        public void UnSubscribe(Publisher pub)
        {
            pub.myEvent -= Update;
        }
        public void Update(object source, EventArguments args)
        {
            Publisher pub = (Publisher)source;
            Console.WriteLine(pub.Name + " Sent a message: " + args.Message);
        }
    }


}
