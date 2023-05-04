using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MFTimesheetSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

        }

        private void InitializeDB_Click(object sender, EventArgs e)
        {
            if(File.Exists(Environment.CurrentDirectory + "\\Employees.xml"))
            {
                MessageBox.Show("DB 'Employees' has already been Initialized.");
            }
            else
            {
                List<Employee> employee = new List<Employee>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Employee>));
                employee.Add(new Employee() { Id = 1, Name = "Bob", Job = "Developer" }); //Just example data to begin with.
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.Create, FileAccess.Write))
                {
                    serial.Serialize(fs, employee);
                    MessageBox.Show("DBs have been Initialized.");
                }
            }

            if (File.Exists(Environment.CurrentDirectory + "\\Jobs.xml"))
            {
                MessageBox.Show("DB 'Jobs' has already been Initialized.");
            }
            else
            {
                List<Job> job = new List<Job>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Job>));
                job.Add(new Job() { Id = 1, JobDesc = "Developer" }); //Just example data to begin with.
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.Create, FileAccess.Write))
                {
                    serial.Serialize(fs, job);
                    MessageBox.Show("DBs have been Initialized.");
                }
            }

            if (File.Exists(Environment.CurrentDirectory + "\\Timesheet.xml"))
            {
                MessageBox.Show("DB 'Timesheet' has already been Initialized.");
            }
            else
            {
                List<Timesheet> job = new List<Timesheet>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));
            }
        }
    }
}
