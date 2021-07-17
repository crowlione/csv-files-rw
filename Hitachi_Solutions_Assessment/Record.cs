using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
    public class Record
    {
        [Name("Country")]
        public String country { get; set; }
        [Name("Average score")]
        public double averageScore { get; set; }
        [Name("Median score")]
        public double medianScore { get; set; }
        [Name("Max score")]
        public double maxScore { get; set; }
        [Name("Max score person")]
        public String maxScorePerson { get; set; }
        [Name("Min score")]
        public double minScore { get; set; }
        [Name("Min score person")]
        public String minScorePerson { get; set; }
        [Name("Record count")]
        public int recordCount { get; set; }
    }
}
