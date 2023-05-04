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

        private void Refresh_Click(object sender, EventArgs e) //This is to apply the table to the listview
        {
            List<TimesheetDisplay> display = new List<TimesheetDisplay>();
            List<Timesheet> data = new List<Timesheet>();
            string combo1 = (string)comboBox1.SelectedItem;
            string combo2 = (string)comboBox2.SelectedItem;

            XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Timesheets.xml", FileMode.Open, FileAccess.Read))
            {
                data = serial.Deserialize(fs) as List<Timesheet>;
            }
            foreach (var datadis in data)
            {
                if ((combo1 == datadis.JobDesc) && (combo2 == datadis.Employee))
                {
                    display.Add(new TimesheetDisplay()
                    {
                        WeekEnd = datadis.WeekEnd,
                        Mon = datadis.Mon,
                        Tue = datadis.Tue,
                        Wed = datadis.Wed,
                        Thu = datadis.Thu,
                        Fri = datadis.Fri
                    });
                }
            }
            dataGridView1.DataSource = display;
        }

        private void InitializeDB_Click(object sender, EventArgs e) //initializing DBs with some data.
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\Employees.xml"))
            {
                List<Employee> employee = new List<Employee>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Employee>));
                employee.Add(new Employee() { Id = 1, Name = "Bob", JobDesc = "Developer" }); //Just example data to begin with.
                employee.Add(new Employee() { Id = 2, Name = "John", JobDesc = "Developer" }); //Just example data to begin with.
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.Create, FileAccess.Write))
                {
                    serial.Serialize(fs, employee);
                    MessageBox.Show("DB 'Employees' has been Initialized.");
                }
            }
            else 
            { 
                MessageBox.Show("DB 'Employees' has already been Initialized."); 
            }

            if (!File.Exists(Environment.CurrentDirectory + "\\Jobs.xml"))
            {
                List<Job> job = new List<Job>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Job>));
                job.Add(new Job() { Id = 1, JobDesc = "Developer" }); //Just example data to begin with.
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.Create, FileAccess.Write))
                {
                    serial.Serialize(fs, job);
                    MessageBox.Show("DB 'Jobs' has been Initialized.");
                }
            }
            else
            {
                MessageBox.Show("DB 'Jobs' has already been Initialized.");
            }

            if (File.Exists(Environment.CurrentDirectory + "\\Timesheet.xml"))
            {
                List<Timesheet> timesheet = new List<Timesheet>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));
                timesheet.Add(new Timesheet()
                {
                    Employee = "Bob",
                    JobDesc = "Developer",
                    WeekEnd = 20230505,
                    Mon = 7.5,
                    Tue = 7.5,
                    Thu = 7.5,
                    Fri = 7.5
                }); //Just example data to begin with.
                timesheet.Add(new Timesheet()
                {
                    Employee = "John",
                    JobDesc = "Developer",
                    WeekEnd = 20230505,
                    Mon = 4.5,
                    Tue = 5.5,
                    Wed = 7.5,
                    Thu = 3,
                    Fri = 1
                }); //Just example data to begin with.
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Timesheets.xml", FileMode.Create, FileAccess.Write))
                {
                    serial.Serialize(fs, timesheet);
                    MessageBox.Show("DB 'Timesheets' has been Initialized.");
                }
            }
            else
            {
                MessageBox.Show("DB 'Timesheet' has already been Initialized.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
