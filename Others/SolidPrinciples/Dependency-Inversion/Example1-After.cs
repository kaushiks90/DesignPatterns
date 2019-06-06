using System.Collections.Generic;

namespace SolidPrinciples.Dependency.Invertion.Before
{
   
    //Notification and Email/SMS? We need to introduce an abstraction, 
    //  one that Notification can rely on and that Email and SMS can implement.Let's call that IMessage.
    public interface IMessage
    {
        void SendMessage();
    }

    public class Email: IMessage
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public void SendMessage()
        {
            //Send email
        }
    }

    public class SMS: IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public void SendMessage()
        {
            //Send Sms
        }
    }
    //And, finally, we can make Notification depend on the a
    public class Notification
    {
        private ICollection<IMessage> _messages;

        public Notification(ICollection<IMessage> messages)
        {
            this._messages = messages;
        }
        public void Send()
        {
            foreach (var message in _messages)
            {
                message.SendMessage();
            }
        }
    }



}