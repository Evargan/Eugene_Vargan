using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Data
{
    internal class Job
    {
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string Note { get; set; }
        public Job(string jobName = "Vargan Selenium test", string jobDescription = "very important job", string note = "working, not sleeping")
        {
            JobName = jobName;
            JobDescription = jobDescription;
            Note = note;
        }
    }
}
