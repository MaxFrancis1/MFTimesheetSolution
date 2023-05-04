using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFTimesheetSolution
{
    public class Timesheet
    {
        public int JobId { get; set; }
        public int EmployeeId { get; set; }
        public int Date { get; set; }
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }
    }
}
