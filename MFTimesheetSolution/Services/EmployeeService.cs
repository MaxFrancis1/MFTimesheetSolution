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
    public class EmployeeService
    {
        private List<Employee> _Emdata;
        private EmployeeRepository _Repository = new EmployeeRepository();

        public EmployeeService()
        {
            _Emdata = _Repository.ReadXml();
        }

        public void CreateEmployee(string newEmployee, string jobDesc)
        {
            Employee employee = new Employee()
            {
                Name = newEmployee,
                JobDesc = jobDesc
            };
            _Emdata.Add(employee);
            _Repository.WriteXml(_Emdata);
        }

        /* Dont think this is neccessary
        public void UpdateEmployee()
        {
            Employee timesheet = _Emdata.Find(e => e.Employee == employee && e.JobDesc == jobDesc && e.WeekEnd == weekEnd);
            timesheet.Mon = mon;
            timesheet.Tue = tue;
            timesheet.Wed = wed;
            timesheet.Thu = thu;
            timesheet.Fri = fri;
            _Repository.WriteXml(_Emdata);
        }*/

        public void DeleteEmployee(Employee employee)
        {
            _Emdata.Remove(employee);
            _Repository.WriteXml(_Emdata);
        }

        public List<Employee> GetAllEmployee(string jobDesc)
        {
            //adding functionality that a jobdesc needs to be added before being able to select employee dropdown
            List<Employee> displayData = _Emdata.FindAll(e => e.JobDesc == jobDesc);
            return displayData;
        }
    }
}
