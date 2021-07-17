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

        public Record(string country, double averageScore, double maxScore, double minScore, int recordCount)
        {
            this.country = country;
            this.averageScore = averageScore;
            this.maxScore = maxScore;
            this.minScore = minScore;
            this.recordCount = recordCount;
        }

        public Record(string country, double averageScore, double medianScore, double maxScore, string maxScorePerson, double minScore, string minScorePerson, int recordCount)
        {
            this.country = country;
            this.averageScore = averageScore;
            this.medianScore = medianScore;
            this.maxScore = maxScore;
            this.maxScorePerson = maxScorePerson;
            this.minScore = minScore;
            this.minScorePerson = minScorePerson;
            this.recordCount = recordCount;
        }

    }
}
