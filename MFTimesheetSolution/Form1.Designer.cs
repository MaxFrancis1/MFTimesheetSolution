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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Job = new System.Windows.Forms.Label();
            this.Employee = new System.Windows.Forms.Label();
            this.MFTimesheetSolution = new System.Windows.Forms.Label();
            this.InitializeDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 215);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1000, 371);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(946, 592);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(66, 23);
            this.Next.TabIndex = 2;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(874, 592);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(66, 23);
            this.Previous.TabIndex = 3;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(12, 592);
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
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(139, 188);
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
            this.Employee.Location = new System.Drawing.Point(136, 169);
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
            // InitializeDB
            // 
            this.InitializeDB.Location = new System.Drawing.Point(957, 12);
            this.InitializeDB.Name = "InitializeDB";
            this.InitializeDB.Size = new System.Drawing.Size(66, 23);
            this.InitializeDB.TabIndex = 10;
            this.InitializeDB.Text = "InitializeDB";
            this.InitializeDB.UseVisualStyleBackColor = true;
            this.InitializeDB.Click += new System.EventHandler(this.InitializeDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 627);
            this.Controls.Add(this.InitializeDB);
            this.Controls.Add(this.MFTimesheetSolution);
            this.Controls.Add(this.Employee);
            this.Controls.Add(this.Job);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Job;
        private System.Windows.Forms.Label Employee;
        private System.Windows.Forms.Label MFTimesheetSolution;
        private System.Windows.Forms.Button InitializeDB;
    }
}

