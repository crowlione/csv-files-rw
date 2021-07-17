using CsvHelper;
using Microsoft.VisualBasic.FileIO;
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

            //using (var writer = new StreamWriter(@"C:\Users\Katy\Desktop\test.txt"))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(allRecords);
            //}









        }
    }
}
