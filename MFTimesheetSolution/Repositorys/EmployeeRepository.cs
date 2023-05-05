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
    public class EmployeeRepository
    {
        XmlSerializer serial = new XmlSerializer(typeof(List<Employee>));

        public List<Employee> ReadXml()
        {
            List<Employee> tsData = new List<Employee>();
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    tsData = serial.Deserialize(fs) as List<Employee>;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return tsData;
        }

        public void WriteXml(List<Employee> timesheet)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.Open, FileAccess.Write))
            {
                serial.Serialize(fs, timesheet);
            }
        }
    }
}
