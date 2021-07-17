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

            foreach (Person p in allRecords)
            {
                Console.WriteLine(p.country);
            }

            using (var writer = new StreamWriter(@"C:\Users\Katy\Desktop\test.txt"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(allRecords);
            }
            Program program = new Program();
            program.email_send();
        }

        public void email_send()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("eg.phpmails@gmail.com");
            mail.To.Add("kyashicrow@gmail.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(@"C:\Users\Katy\Desktop\test.txt");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
