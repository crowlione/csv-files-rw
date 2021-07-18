using CsvHelper;
using CsvHelper.Configuration;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            String fileName;
            String senderEmailAddress;
            String password;
            String receiverEmailAddress;

            do
            {
                Console.WriteLine("Please select a language. Type in either EN or DE.\n" +
                   "Bitte wählen Sie eine Sprache. Geben Sie entweder EN oder DE ein.");
                Globals.LANGUAGE = Console.ReadLine().ToUpper();
            }
            while (Globals.LANGUAGE != "DE" && Globals.LANGUAGE != "EN");

            if (Globals.LANGUAGE == "DE")
            {
                Globals.changeLanguage();
            }

            Console.WriteLine(Globals.FILE_NAME);
            
            fileName = Console.ReadLine();

            List<Person> allRecords = new List<Person>();

            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", DetectDelimiter = true};
            try
            {
                using (var reader = new StreamReader(fileName)) 
                       
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<Person>();
                    allRecords = records.ToList();
                }
           
                if(allRecords.Count() == 0)
                {
                    Console.WriteLine(Globals.EMPTY_WARNING);
                }

                if (allRecords.Count() != 0)
                {
                    var newList = allRecords.GroupBy(r => r.country)
                         .Select(s => new { Country = s.Key, 
                             Avg = s.Average(p => p.score), 
                             Max = s.Max(p => p.score), 
                             Min = s.Min(p => p.score),
                             Count = s.Count()})
                         .OrderByDescending(s=>s.Avg);

                List<Record> results = new List<Record>();

                Person maxPerson;
                Person minPerson;
                double median;

                foreach (var p in newList)
                {
                    maxPerson = allRecords.Find(r => r.score == p.Max);
                    minPerson = allRecords.Find(r => r.score == p.Min);
                    median = allRecords.FindAll(r => r.country == p.Country)
                        .OrderByDescending(r => r.score)
                        .ElementAt(p.Count % 2 == 0 ? p.Count/2 : (p.Count-1)/2).score;
       

                    results.Add(new Record(p.Country, p.Avg, median, p.Max, maxPerson.firstName + " " + maxPerson.lastName, 
                        p.Min, minPerson.firstName + " " + minPerson.lastName, p.Count));
                }

                using (var writer = new StreamWriter("ReportByCountry.csv"))
                    using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(results);
                }

                    Console.WriteLine(Globals.EMAIL);
                    senderEmailAddress = Console.ReadLine();

                    Console.WriteLine(Globals.PASSWORD);
                    password = Console.ReadLine();

                    Console.WriteLine(Globals.RECEIVER_EMAIL);
                    receiverEmailAddress = Console.ReadLine();

                    Program program = new Program();
                    try
                    {
                        program.email_send(senderEmailAddress, password, receiverEmailAddress);
                    }
                     catch (MailKit.Security.AuthenticationException)
                    {
                        Console.WriteLine(Globals.FORMAT_ERROR);
                    }
                    catch (MailKit.Net.Smtp.SmtpCommandException)
                    {
                        Console.WriteLine(Globals.WRONG_RECEIVER);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(Globals.FILE_NOT_FOUND);
            }
            catch (CsvHelper.MissingFieldException)
            {
                Console.WriteLine(Globals.INCOMPLETE_DATA);
            }
            catch (CsvHelper.HeaderValidationException)
            {
                Console.WriteLine(Globals.INCOMPLETE_DATA);
            }
        }

        public void email_send(String senderEmail, String senderPassword, String receiverEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(senderEmail));
            email.To.Add(MailboxAddress.Parse(receiverEmail));
            email.Subject = Globals.EMAIL_TITLE;

            var builder = new BodyBuilder();
            builder.TextBody = Globals.GREETING + receiverEmail.Split('@')[0] + Globals.EMAIL_BODY;
            builder.Attachments.Add("ReportByCountry.csv");
            email.Body = builder.ToMessageBody();
            
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            if (senderEmail.Contains("@abv.bg")){
                smtp.Connect("smtp.abv.bg", 465, true);
            }
            else if (senderEmail.Contains("@mail.bg"))
            {
                smtp.Connect("smtp.mail.bg", 465, true);
            }
            else
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            }
            smtp.Authenticate(senderEmail, senderPassword);
            smtp.Send(email);
            Console.WriteLine(Globals.SUCCESS);
            smtp.Disconnect(true);            
        }
    }
}
