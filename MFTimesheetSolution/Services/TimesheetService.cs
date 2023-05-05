using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MFTimesheetSolution
{
    public class TimesheetService
    {
        private List<Timesheet> _Tsdata;
        private TimesheetRepository _Repository = new TimesheetRepository();

        public TimesheetService()
        {
            _Tsdata = _Repository.ReadXml();
        }

        public void CreateTimesheet(string jobDesc, string employee, string weekEnd)
        {
            Timesheet timesheet = new Timesheet()
            {
                JobDesc = jobDesc,
                Employee = employee,
                WeekEnd = weekEnd
            };
            _Tsdata.Add(timesheet);
            _Repository.WriteXml(_Tsdata);
        }

        public void UpdateTimesheet(string jobDesc, string employee, string weekEnd, double mon, double tue, double wed, double thu, double fri)
        {
            Timesheet timesheet = _Tsdata.Find(e => e.Employee == employee && e.JobDesc == jobDesc && e.WeekEnd == weekEnd);
            timesheet.Mon = mon;
            timesheet.Tue = tue;
            timesheet.Wed = wed;
            timesheet.Thu = thu;
            timesheet.Fri = fri;
            _Repository.WriteXml(_Tsdata);
        }

        public void DeleteTimesheet(Timesheet timesheet)
        {
            _Tsdata.Remove(timesheet);
            _Repository.WriteXml(_Tsdata);
        }

        public List<Timesheet> GetAllTimesheet(string jobDesc)
        {
            List<Timesheet> displayData = _Tsdata.FindAll(e => e.JobDesc == jobDesc);
            return displayData;
        }

        public List<Timesheet> GetEmpTimesheet(string jobDesc, string employee)
        {
            List<Timesheet> displayData = _Tsdata.FindAll(e => e.Employee == employee && e.JobDesc == jobDesc);
            return displayData;
        }
    }
}
