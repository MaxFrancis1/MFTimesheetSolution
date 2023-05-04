using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFTimesheetSolution
{
    public class Timesheet
    {
        public int EmployeeId { get; set; }
        public string JobDesc { get; set; }
        public int Date { get; set; }
        public double Mon { get; set; }
        public double Tue { get; set; }
        public double Wed { get; set; }
        public double Thu { get; set; }
        public double Fri { get; set; }
    }
}
