using System;
using System.Net.Mail;

namespace SolidPrinciples.Single.Responsibility.Principle.After
{
    internal class Program
    {
 
        
        public static void SendInvite(string email, string firstName, string lastname)
        {

            UserNameService.Validate(firstName, lastname);
            EmailService.validate(email);
            SmtpClient client = new SmtpClient();
            client.Send(new MailMessage("Test@gmail.com", email) { Subject = "Please Join the Party!" });
        }
    }
    public static class UserNameService
    {
        public static void Validate(string firstname, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Name is not valid");
            }
        }
    }

    public static class EmailService
    {
        public static void validate(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not Valid!");
            }
        }
    }

}