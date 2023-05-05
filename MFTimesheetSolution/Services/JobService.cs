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
    public class JobService
    {
        private List<Job> _Jobdata;
        private JobRepository _Repository = new JobRepository();

        public JobService()
        {
            _Jobdata = _Repository.ReadXml();
        }

        public void CreateJob(string jobDesc)
        {
            Job job = new Job()
            {
                JobDesc = jobDesc
            };
            _Jobdata.Add(job);
            _Repository.WriteXml(_Jobdata);
        }

        /*
        public void UpdateJob()
        {
            //Dont think this is neccessary for now.
            _Repository.WriteXml(_Jobdata); 
        }*/
        
        /*
        public void DeleteJob(Job job) //Not sure this is neccessary
        {
            _Jobdata.Remove(job);
            _Repository.WriteXml(_Jobdata);
        }*/

        public List<Job> GetAllJob(string jobDesc, string employee)
        {
            //List<Job> displayData = _Jobdata.FindAll(e => e.Employee == employee && e.JobDesc == jobDesc);
            return null; //was displayData
        }
    }
}
