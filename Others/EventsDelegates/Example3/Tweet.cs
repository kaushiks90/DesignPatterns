using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventsDelegates.Example3
{
   
    internal class Program
    {
        private static void MainMethod()
        {
            Person trump = new Person("Donal trump");
            Person joe = new Person("joe");

            Person Kaushik = new Person("Kaushik");
            Person adam = new Person("adam");
            Person peter = new Person("peter");
            Kaushik.Subscribe(trump);
            adam.Subscribe(trump);
            peter.Subscribe(trump);

            adam.Subscribe(joe);
            peter.Subscribe(joe);

            trump.SendTweet("Hi Joe");
            joe.SendTweet("Hi Trump");
            peter.UnSubscribe(trump);
            joe.Subscribe(trump);

            trump.SendTweet("Hi Joe cofeffe");



            Console.ReadLine();
        }
    }
    public class Tweet : EventArgs
    {
        private Tweet()
        {

        }
        public string Message { get; set; }

        public DateTime Time { get; set; }

        public Tweet(string Message)
        {
            this.Message = Message;
            this.Time = DateTime.Now;
        }
    }
    //Here person behaves as a publisher and a subscriber
    public class Person
    {
        private Person()
        {

        }
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }

        public EventHandler<Tweet> mytweetEvent;

        public void SendTweet(string message)
        {
            Thread.Sleep(1000);
            if (mytweetEvent != null)
            {
                mytweetEvent(this, new Tweet(message));
            }
        }
        public void Subscribe(Person person)
        {
            person.mytweetEvent += ShowTweet;
        }
        public void UnSubscribe(Person person)
        {
            person.mytweetEvent -= ShowTweet;
        }
        public void ShowTweet(Object Source, Tweet args)
        {
            Person tweeter = (Person)Source;
            Console.WriteLine(this.Name + " :Tweet sent by " + tweeter.Name + " message = " +
                args.Message + " at: " + args.Time.ToLongTimeString());
        }
    }



}
