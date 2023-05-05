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
        private TimesheetService TimesheetService;
        private JobService JobService;
        private EmployeeService EmployeeService;

        public Form1()
        {
            InitializeComponent();
            TimesheetService = new TimesheetService();
            JobService = new JobService();
            EmployeeService = new EmployeeService();
        }

        private void Refresh_Click(object sender, EventArgs e) //This is to apply the table to the listview
        {
            if ((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null)) {
                string jobDesc = comboBox1.SelectedItem.ToString();
                string employee = comboBox2.SelectedItem.ToString();

                dataGridView1.DataSource = TimesheetService.GetEmpTimesheet(jobDesc, employee);
            }
            else if ((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem == null))
            {
                string jobDesc = comboBox1.SelectedItem.ToString();
                dataGridView1.DataSource = TimesheetService.GetAllTimesheet(jobDesc);
            }
        }

        public void RefreshJobs()
        {
            comboBox1.Items.Clear();
            List<Job> dataJob = JobService.GetAllJob();

            foreach (var datadis in dataJob)
            {
                comboBox1.Items.Add(datadis.JobDesc);
            }
        }

        private void InitializeDB_Click(object sender, EventArgs e) //initializing DBs with some data. (this is for debug)
        {
            List<Employee> employee = new List<Employee>();
            XmlSerializer emSerial = new XmlSerializer(typeof(List<Employee>));
            employee.Add(new Employee() { Name = "Bob", JobDesc = "Developer" }); //Just example data to begin with.
            employee.Add(new Employee() { Name = "John", JobDesc = "Developer" }); //Just example data to begin with.
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.Create, FileAccess.Write))
            {
                emSerial.Serialize(fs, employee);
                MessageBox.Show("DB 'Employees' has been Initialized.");
            }


            List<Job> job = new List<Job>();
            XmlSerializer jbSerial = new XmlSerializer(typeof(List<Job>));
            job.Add(new Job() { JobDesc = "Developer" }); //Just example data to begin with.
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.Create, FileAccess.Write))
            {
                jbSerial.Serialize(fs, job);
                MessageBox.Show("DB 'Jobs' has been Initialized.");
            }
            
            List<Timesheet> timesheet = new List<Timesheet>();
            XmlSerializer tsSerial = new XmlSerializer(typeof(List<Timesheet>));
            timesheet.Add(new Timesheet()
            {
                Employee = "Bob",
                JobDesc = "Developer",
                WeekEnd = "20230505",
                Mon = 7.5,
                Tue = 7.5,
                Thu = 7.5,
                Fri = 7.5
            }); //Just example data to begin with.
            timesheet.Add(new Timesheet()
            {
                Employee = "John",
                JobDesc = "Developer",
                WeekEnd = "20230505",
                Mon = 4.5,
                Tue = 5.5,
                Wed = 7.5,
                Thu = 3,
                Fri = 1
            }); //Just example data to begin with.
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Timesheets.xml", FileMode.Create, FileAccess.Write))
            {
                tsSerial.Serialize(fs, timesheet);
                MessageBox.Show("DB 'Timesheets' has been Initialized.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshJobs();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.SelectedItem.ToString();

            foreach (DataGridViewRow data in dataGridView1.Rows)
            {
                string weekEnd = data.Cells[2].Value.ToString();
                TimesheetService.UpdateTimesheet(
                    jobDesc,
                    employee,
                    weekEnd,
                    (double)data.Cells[3].Value,
                    (double)data.Cells[4].Value,
                    (double)data.Cells[5].Value,
                    (double)data.Cells[6].Value,
                    (double)data.Cells[7].Value
                    );
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.SelectedItem.ToString();

            TimesheetService.CreateTimesheet(jobDesc, employee, dateTimePicker1.Value.ToString("yyyyMMdd"));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.SelectedItem.ToString();
;
            TimesheetService.DeleteTimesheet(TimesheetService.GetEmpTimesheet(jobDesc, employee)[dataGridView1.CurrentCell.RowIndex]);
        }

        private void CrEmployee_Click(object sender, EventArgs e)
        {
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.Text;

            EmployeeService.CreateEmployee(employee, jobDesc);
        }

        private void CrJob_Click(object sender, EventArgs e)
        {
            string jobDesc = comboBox1.Text;

            JobService.CreateJob(jobDesc);
            RefreshJobs();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            try
            {
                string jobDesc = comboBox1.Text;
                List<Employee> dataEmp = EmployeeService.GetAllEmployee(jobDesc);

                foreach (var datadis in dataEmp)
                {
                    comboBox2.Items.Add(datadis.Name);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
