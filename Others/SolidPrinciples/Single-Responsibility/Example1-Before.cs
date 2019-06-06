using System;
using System.Net.Mail;

namespace SolidPrinciples.Single.Responsibility.Principle.Before {

    class Program
    {
       
        public static void SendInvite(string email,string firstName,string lastname)
        {
            if(String.IsNullOrWhiteSpace(firstName)|| String.IsNullOrWhiteSpace(lastname))
            {
                throw new Exception("Name is not valid");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not Valid!");
            }
            SmtpClient client = new SmtpClient();
            client.Send(new MailMessage("Test@gmail.com", email) { Subject="Please Join the Party!"})
        }
    }
  

}