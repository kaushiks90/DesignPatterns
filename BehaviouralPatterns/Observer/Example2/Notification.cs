using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDelegates.ObserverPattern.Example2
{
    class Notification
    {
    }
    public interface INotification
    {
        void Notify();
    }
    public class EmailNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("Email Notified");
        }
    }
    public class SmsNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("Sms Notified");
        }
    }
    public class PersonalNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("Personal Notified");
        }
    }
    public class Notifier
    {
        private List<INotification> _notifications = new List<INotification>();
        public void Attach(INotification notification)
        {
            _notifications.Add(notification);
        }
        public void Detach(INotification notification)
        {
            _notifications.Remove(notification);
        }
        public void NotifyAll()
        {
            foreach (INotification notification in _notifications)
            {
                notification.Notify();
            }
        }
    }

}
