using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCJobList.xaml
    /// </summary>
    public partial class UCJobList : UserControl
    {
        Job jobSample = new Job(0, 0, "", "", "", "", "", "", "", "", new bool());
        int companyID = 0;
        public UCJobList(string format)
        {

            InitializeComponent();
          
            LoadJobList(format);
            if(MainWindow.user.UserRole == "Candidate")
            {
                btnAddJobForm.Visibility = Visibility.Collapsed;
            }
        }

        public UCJobList(String format, int companyID)
        {
            InitializeComponent();
            this.companyID = companyID;
            LoadJobList(format);
            if (MainWindow.user.UserRole == "Candidate")
            {
                btnAddJobForm.Visibility = Visibility.Collapsed;
            }

        }

        public void LoadJobList(string selectFormat)
        {
            List<Job> jobs = new List<Job>();
            JobDAO jobDAO = new JobDAO(jobSample, selectFormat);
            DataTable jobData = new DataTable();
            jobData = jobDAO.Load();
            for (int i = jobData.Rows.Count - 1; i >= 0; i--)
            {
                Job job = new Job(0, MainWindow.userCompany.UserID, "", "", "", "", "", "", "", "", new bool());
                job.JobID = Convert.ToInt32(jobData.Rows[i]["JobID"]);
                job.CompanyID = Convert.ToInt32(jobData.Rows[i]["CompanyID"]);
                job.JobName = jobData.Rows[i]["JobName"].ToString();
                job.JobType = jobData.Rows[i]["JobType"].ToString();
                job.JobSalary = jobData.Rows[i]["JobSalary"].ToString();
                job.JobDescription = jobData.Rows[i]["JobDescription"].ToString();
                job.JobQualification = jobData.Rows[i]["JobQualification"].ToString();
                job.JobLocation = jobData.Rows[i]["JobLocation"].ToString();
                job.JobSkills = jobData.Rows[i]["JobSkills"].ToString();
                job.JobPostDate = Convert.ToDateTime(jobData.Rows[i]["JobPostDate"]).ToShortDateString();
                job.Status = Convert.ToBoolean(jobData.Rows[i]["JobStatus"]);
                if(job==null)
                {
                    throw new Exception("?");
                }
                jobs.Add(job);

            }
            ShowJobList(jobs);
        }

        public void ShowJobList(List<Job> jobs)
        {

            int count = 0;
            foreach (Job j in jobs)
            {
                UCJob ucjob = new UCJob(j);
                int dis = Convert.ToInt32(ucjob.ActualHeight);
                ucjob.Margin = new Thickness(0, dis * count + 10, 0, 0);
                JobListPanel.Children.Add(ucjob);
                count++;

            }

        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WJobAdd wJobAdd = new WJobAdd();
            wJobAdd.Show();

        }

        

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (JobListPanel.Children != null)
            {
                JobListPanel.Children.Clear();
            }

            if(companyID==0)
            {
                SearchJobForNormalJobList();
            }
            else
            {
                SearchJobForCompanyHighestJobList();
            }
        }

        private void SearchJobForNormalJobList()
        {
                      
            if (MainWindow.user.UserRole == "Company")
            {
                if(txtSearchJob.Text != null)
                {
                    LoadJobList("select * from job where CompanyID=" + MainWindow.userCompany.UserID + " AND (JOB.JobType = N'" + txtSearchJob.Text + "' OR JOB.JobSkills like '%'+ N'" + txtSearchJob.Text + "'+ '%')");
                }
                else
                {
                    LoadJobList("select * from job where CompanyID = " + MainWindow.userCompany.UserID);
                }
            }
            else
            {
                if(txtSearchJob.Text != null)
                {
                    LoadJobList("select * from job where JOB.JobType = N'" + txtSearchJob.Text + "' OR JOB.JobSkills like '%'+ N'" + txtSearchJob.Text + "'+ '%'");
                }
                else
                {
                    LoadJobList("select * from job");
                }
            }
        }

        private void SearchJobForCompanyHighestJobList()
        {
            if (txtSearchJob.Text != null)
            {
                LoadJobList("select * from job where CompanyID=" + companyID + " AND (JOB.JobType = N'" + txtSearchJob.Text + "' OR JOB.JobSkills like '%'+ N'" + txtSearchJob.Text + "'+ '%')");
            }
            else
            {
                LoadJobList("select * from job where CompanyID = " + companyID);
            }


        }
    }
}
