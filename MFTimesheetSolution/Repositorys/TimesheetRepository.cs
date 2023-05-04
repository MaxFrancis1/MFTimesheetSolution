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
    public class TimesheetRepository
    {
        XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));

        public List<Timesheet> ReadXml()
        {
            List<Timesheet> tsData = new List<Timesheet>();
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Timesheets.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    tsData = serial.Deserialize(fs) as List<Timesheet>;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return tsData;
        }

        public void WriteXml(List<Timesheet> timesheet)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Timesheets.xml", FileMode.Open, FileAccess.Write))
            {
                serial.Serialize(fs, timesheet);
            }
        }
    }
}
