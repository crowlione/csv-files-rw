using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
   public class Person
    {
        [Name("First Name")]
        public String firstName { get; set; }
        [Name("Last Name")]
        public String lastName { get; set; }
        [Name("Country")]
        public String country { get; set; }
        [Name("City")]
        public String city { get; set; }
        [Name("Score")]
        public int score { get; set; }

        public override string ToString()
        {
            return base.ToString() + ": " + firstName.ToString();
            ;
        }
    }
}
