using CsvHelper;
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
            String[] textBoxes = new String[] { "Cupcake", "Cake", "Candy" }; 
            
            //TO BE variable fileName
            var path = @"C:\Users\Katy\Desktop\testfile.csv";

            List<Person> allRecords;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>();
                allRecords = records.ToList();
            }

            // this is IEnumerable
            var newList = allRecords.GroupBy(r => r.country)
                     .Select(s => new { Country = s.Key, 
                         Avg = s.Average(p => p.score), 
                         Max = s.Max(p => p.score), 
                         Min = s.Min(p => p.score),
                         Count = s.Count()})
                     .OrderBy(s=>s.Avg);

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

            foreach (Record r in results)
            {
                Console.WriteLine(r.averageScore + " " + r.country + " " + r.recordCount + " " + r.maxScore + " " + r.maxScorePerson + " "
                    + r.minScore + " " + r.minScorePerson + " " + r.medianScore);
            }

            //using (var writer = new StreamWriter("ReportByCountry.csv"))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(allRecords);
            //}
            //Program program = new Program();
            // program.email_send();
        }

        //public void email_send()
        //{
        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    mail.From = new MailAddress("eg.phpmails@gmail.com");
        //    mail.To.Add("kyashicrow@gmail.com");
        //    mail.Subject = "Test Mail - 1";
        //    mail.Body = "mail with attachment";

        //    System.Net.Mail.Attachment attachment;
        //    attachment = new System.Net.Mail.Attachment(@"test.csv");
        //    mail.Attachments.Add(attachment);

        //    SmtpServer.Port = 587;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
        //    SmtpServer.EnableSsl = true;

        //    SmtpServer.Send(mail);

        //}
    }
}
