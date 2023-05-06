using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public void CalcOvertime(List<Timesheet> timesheet)
        {
            foreach (Timesheet data in timesheet) 
            {
                if ((data.Mon >= 10) || (data.Tue >= 10) || (data.Wed >= 10) || (data.Thu >= 10) || (data.Fri >= 10))
                {
                    string subject = $"Overtime alert - {data.Employee}";
                    string body = $"{data.Employee} has gone over allocated hours for job {data.JobDesc}";

                    /*
                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("TimesheetSolutions@gmail.com", "examplePassword");

                        smtpClient.Send("smtp@example.com", "whoever@example.com", subject, body);
                    }*/ //The above is how I would implement a email notification however I don't have a smtp server available.
                    MessageBox.Show($"{subject} - {body}");
                }
            }
        }

        public double CalcHoursSpent (string jobDesc)
        {
            double hoursSpent = 0;
            List<Timesheet> timesheet = GetAllTimesheet(jobDesc);

            foreach (Timesheet data in timesheet)
            {
                hoursSpent = data.Mon + data.Tue + data.Wed + data.Thu + data.Fri;
            }
            return hoursSpent;
        }

        public void UpdateTimesheet(string employee, string jobDesc, string weekEnd, double mon, double tue, double wed, double thu, double fri)
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
            CalcOvertime(displayData);
            return displayData;
        }

        public List<Timesheet> GetEmpTimesheet(string jobDesc, string employee)
        {
            List<Timesheet> displayData = _Tsdata.FindAll(e => e.Employee == employee && e.JobDesc == jobDesc);
            CalcOvertime(displayData);
            return displayData;
        }
    }
}
