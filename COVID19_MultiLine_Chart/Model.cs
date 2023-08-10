using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19_MultiLine_Chart
{
    public class JoblessCategory
    {
        public DateTime Year { get; set; }
        public double CompletedTempJobs { get; set; }
        public double NotOnTempLayoff { get; set; }
        public double OnTemporaryLayoff { get; set; }
        public double JobLeavers { get; set; }
        public double Reentrants { get; set; }
        public double NewEntrants { get; set; }

        public JoblessCategory(DateTime year, double jobless1, double jobless2, double jobless3, double jobless4, double jobless5, double jobless6)
        {
            Year = year;
            CompletedTempJobs = jobless1;
            NotOnTempLayoff = jobless2;
            OnTemporaryLayoff = jobless3;
            JobLeavers = jobless4;
            Reentrants = jobless5;
            NewEntrants = jobless6;
        }
    }
}
