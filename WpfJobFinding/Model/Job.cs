using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding
{
    public class Job
    {
        int jobID ;
        int companyID ;
        string jobName ;
        string jobType;
        string jobSalary;
        string jobDescription;
        string jobQualification;
        string jobLocation;
        string jobSkills;
        string jobPostDate;
        bool status;

        public Job(int jobID , int companyID , string jobName, string jobType, string jobSalary, string jobDescription, string jobQualification, string jobLocation, string jobSkills, string jobPostDate, bool status)
        {
            this.jobID = jobID;
            this.companyID = companyID;
            this.jobName = jobName;
            this.jobType = jobType;
            this.jobSalary = jobSalary;
            this.jobDescription = jobDescription;
            this.jobQualification = jobQualification;
            this.jobLocation = jobLocation;
            this.jobSkills = jobSkills;
            this.jobPostDate = jobPostDate;
            this.status = status;
        }

        public int JobID { get =>jobID; set => jobID = value; } 
        public int CompanyID { get => companyID; set => companyID = value; }
        public string JobName { get => jobName; set => jobName = value; }
        public string JobType { get => jobType; set => jobType = value; }
        public string JobSalary { get => jobSalary; set => jobSalary = value; }
        public string JobDescription { get => jobDescription; set => jobDescription = value; }
        public string JobQualification { get => jobQualification; set => jobQualification = value; }
        public string JobLocation { get => jobLocation; set => jobLocation = value; }
        public string JobSkills { get => jobSkills; set => jobSkills = value; }
        public string JobPostDate { get => jobPostDate; set => jobPostDate = value; }
        public bool Status {  get => status; set => status = value;}
    }
}
