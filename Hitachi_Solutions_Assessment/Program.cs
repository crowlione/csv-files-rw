using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
                   "Bitte wählen Sie eine Sprache. Geben Sie entweder EN oder DE ein.\n");
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


            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";"};
            try
            {
                using (var reader = new StreamReader(fileName)) 
                       
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<Person>();
                    allRecords = records.ToList();
                }
           

                // this is IEnumerable
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
                     catch (FormatException)
                    {
                        Console.WriteLine(Globals.FORMAT_ERROR);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(Globals.FILE_NOT_FOUND);
            }
        }

        public void email_send(String senderEmail, String senderPassword, String receiverEmail)
        {
            
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(receiverEmail);
                mail.Subject = Globals.EMAIL_TITLE;
                mail.Body = Globals.GREETING + senderEmail + Globals.EMAIL_BODY;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("ReportByCountry.csv");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
                SmtpServer.EnableSsl = true;

               try
               {
                   SmtpServer.Send(mail);
               }
               catch (SmtpException)
               {
                   Console.WriteLine(Globals.UNAUTHORIZED_ERROR);
               }
         

        }
    }
}
