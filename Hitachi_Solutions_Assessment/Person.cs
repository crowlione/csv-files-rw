using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
   public class Person
    {
        [Index(0)]
        public String firstName { get; set; }
        [Index(1)]
        public String lastName { get; set; }
        [Index(2)]
        public String country { get; set; }
        [Index(3)]
        public String city { get; set; }
        [Index(4)]
        public int score { get; set; }

        public override string ToString()
        {
            return base.ToString() + ": " + firstName.ToString();
            ;
        }
    }
}
