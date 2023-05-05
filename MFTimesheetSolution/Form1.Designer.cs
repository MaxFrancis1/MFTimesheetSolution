namespace MFTimesheetSolution
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Refresh = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Job = new System.Windows.Forms.Label();
            this.Employee = new System.Windows.Forms.Label();
            this.MFTimesheetSolution = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Delete = new System.Windows.Forms.Button();
            this.CrJob = new System.Windows.Forms.Button();
            this.CrEmployee = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(84, 592);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(66, 23);
            this.Refresh.TabIndex = 4;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 188);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(263, 188);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // Job
            // 
            this.Job.AutoSize = true;
            this.Job.Location = new System.Drawing.Point(13, 169);
            this.Job.Name = "Job";
            this.Job.Size = new System.Drawing.Size(24, 13);
            this.Job.TabIndex = 7;
            this.Job.Text = "Job";
            // 
            // Employee
            // 
            this.Employee.AutoSize = true;
            this.Employee.Location = new System.Drawing.Point(260, 169);
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(53, 13);
            this.Employee.TabIndex = 8;
            this.Employee.Text = "Employee";
            // 
            // MFTimesheetSolution
            // 
            this.MFTimesheetSolution.AutoSize = true;
            this.MFTimesheetSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MFTimesheetSolution.Location = new System.Drawing.Point(13, 13);
            this.MFTimesheetSolution.Name = "MFTimesheetSolution";
            this.MFTimesheetSolution.Size = new System.Drawing.Size(287, 31);
            this.MFTimesheetSolution.TabIndex = 9;
            this.MFTimesheetSolution.Text = "MF-TimesheetSolution";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1000, 371);
            this.dataGridView1.TabIndex = 11;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 592);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(66, 23);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(787, 185);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(100, 20);
            this.Create.TabIndex = 13;
            this.Create.Text = "Create Timesheet";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(893, 185);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(946, 592);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(66, 23);
            this.Delete.TabIndex = 15;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // CrJob
            // 
            this.CrJob.Location = new System.Drawing.Point(139, 188);
            this.CrJob.Name = "CrJob";
            this.CrJob.Size = new System.Drawing.Size(98, 21);
            this.CrJob.TabIndex = 16;
            this.CrJob.Text = "Create Job";
            this.CrJob.UseVisualStyleBackColor = true;
            this.CrJob.Click += new System.EventHandler(this.CrJob_Click);
            // 
            // CrEmployee
            // 
            this.CrEmployee.Location = new System.Drawing.Point(390, 188);
            this.CrEmployee.Name = "CrEmployee";
            this.CrEmployee.Size = new System.Drawing.Size(98, 21);
            this.CrEmployee.TabIndex = 17;
            this.CrEmployee.Text = "Create Employee";
            this.CrEmployee.UseVisualStyleBackColor = true;
            this.CrEmployee.Click += new System.EventHandler(this.CrEmployee_Click);
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(156, 592);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(81, 23);
            this.Print.TabIndex = 18;
            this.Print.Text = "Print Report";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 627);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.CrEmployee);
            this.Controls.Add(this.CrJob);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MFTimesheetSolution);
            this.Controls.Add(this.Employee);
            this.Controls.Add(this.Job);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Save);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Job;
        private System.Windows.Forms.Label Employee;
        private System.Windows.Forms.Label MFTimesheetSolution;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button CrJob;
        private System.Windows.Forms.Button CrEmployee;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

