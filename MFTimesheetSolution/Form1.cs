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

        public Form1()
        {
            InitializeComponent();
            TimesheetService = new TimesheetService();
        }

        private void Refresh_Click(object sender, EventArgs e) //This is to apply the table to the listview
        {
            string combo1 = (string)comboBox1.SelectedItem;
            string combo2 = (string)comboBox2.SelectedItem;

            dataGridView1.DataSource = TimesheetService.GetAllTimesheet(combo1, combo2);
        }

        private void InitializeDB_Click(object sender, EventArgs e) //initializing DBs with some data. (this is for debug)
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\Employees.xml"))
            {
                List<Employee> employee = new List<Employee>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Employee>));
                employee.Add(new Employee() { Name = "Bob", JobDesc = "Developer" }); //Just example data to begin with.
                employee.Add(new Employee() { Name = "John", JobDesc = "Developer" }); //Just example data to begin with.
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
                job.Add(new Job() { JobDesc = "Developer" }); //Just example data to begin with.
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

            if (!File.Exists(Environment.CurrentDirectory + "\\Timesheet.xml"))
            {
                List<Timesheet> timesheet = new List<Timesheet>();
                XmlSerializer serial = new XmlSerializer(typeof(List<Timesheet>));
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

            List<Job> dataJob = new List<Job>();
            List<Employee> dataEmp = new List<Employee>();

            XmlSerializer serialJob = new XmlSerializer(typeof(List<Job>));
            XmlSerializer serialEmp = new XmlSerializer(typeof(List<Employee>));

            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    dataJob = serialJob.Deserialize(fs) as List<Job>;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            foreach (var datadis in dataJob)
            {
                comboBox1.Items.Add(datadis.JobDesc);
            }
            
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employees.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    dataEmp = serialEmp.Deserialize(fs) as List<Employee>;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            foreach (var datadis in dataEmp)
            {
                comboBox2.Items.Add(datadis.Name);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string combo1 = comboBox1.SelectedItem.ToString();
            string combo2 = comboBox2.SelectedItem.ToString();

            foreach (DataGridViewRow data in dataGridView1.Rows)
            {
                string weekEnd = data.Cells[2].Value.ToString();
                TimesheetService.UpdateTimesheet(
                    combo1,
                    combo2,
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
            TimesheetService.CreateTimesheet((string)comboBox1.SelectedItem, (string)comboBox2.SelectedItem, dateTimePicker1.Value.ToString("yyyyMMdd"));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string combo1 = (string)comboBox1.SelectedItem;
            string combo2 = (string)comboBox2.SelectedItem;
;
            TimesheetService.DeleteTimesheet(TimesheetService.GetAllTimesheet(combo1, combo2)[dataGridView1.CurrentCell.RowIndex]);
        }
    }
}
