using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MFTimesheetSolution
{
    public class JobRepository
    {
        XmlSerializer serial = new XmlSerializer(typeof(List<Job>));

        public List<Job> ReadXml()
        {
            List<Job> tsData = new List<Job>();
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    tsData = serial.Deserialize(fs) as List<Job>;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return tsData;
        }

        public void WriteXml(List<Job> timesheet)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<Job>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.Open, FileAccess.Write))
            {
                serial.Serialize(fs, timesheet);
            }
        }
    }
}
