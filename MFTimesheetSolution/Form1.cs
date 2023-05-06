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

        private Bitmap bitmap;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshJobs();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.Text;

            foreach (DataGridViewRow data in dataGridView1.Rows)
            {
                string weekEnd = data.Cells[2].Value.ToString();
                TimesheetService.UpdateTimesheet(
                    employee == "" ? (string)data.Cells[0].Value : employee,
                    jobDesc,
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
            if ((comboBox1.SelectedItem == null) || (comboBox2.SelectedItem == null))
            {
                MessageBox.Show("Please select a Job and Employee");
                return;
            }
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.SelectedItem.ToString();

            TimesheetService.CreateTimesheet(jobDesc, employee, dateTimePicker1.Value.ToString("yyyyMMdd"));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null) || (comboBox2.SelectedItem == null))
            {
                MessageBox.Show("Please select a Job and Employee");
                return;
            }
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.SelectedItem.ToString();
;
            TimesheetService.DeleteTimesheet(TimesheetService.GetEmpTimesheet(jobDesc, employee)[dataGridView1.CurrentCell.RowIndex]);
        }

        private void CrEmployee_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null) || (comboBox2.Text == ""))
            {
                MessageBox.Show("Please select a Job with a name");
                return;
            };
            string jobDesc = comboBox1.SelectedItem.ToString();
            string employee = comboBox2.Text;

            EmployeeService.CreateEmployee(employee, jobDesc);
        }

        private void CrJob_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "") || (JobhoursUpDown.Value == 0))
            {
                MessageBox.Show("Please select a enter a name and predicted hours for this job");
                return;
            };
            string jobDesc = comboBox1.Text;
            double jobHours = (double)JobhoursUpDown.Value;

            JobService.CreateJob(jobDesc, jobHours);
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

        private void Print_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void CalcHours_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a Job");
                return;
            };

            string jobDesc = comboBox1.Text;

            double jobHours = JobService.JobHours(jobDesc);
            double hoursSpent = TimesheetService.CalcHoursSpent(jobDesc);

            if (hoursSpent > jobHours)
            {
                MessageBox.Show($"Exceeded predicted hours on job {jobDesc}");
            }
            else
            {
                MessageBox.Show($"{jobHours - hoursSpent} hours remaining on job {jobDesc}");
            };
        }
    }
}
