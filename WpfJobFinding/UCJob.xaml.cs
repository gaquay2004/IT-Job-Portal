using System;
using System.Collections.Generic;
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
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCJob.xaml
    /// </summary>
    public partial class UCJob : UserControl
    {
        Job jobUpdate;
        
        public UCJob(Job job)
        {
            InitializeComponent();
            this.jobUpdate = job;
            lblJobName.Content = job.JobName;
            lblJobLocation.Content = job.JobLocation;
            lblJobType.Content = job.JobType;
            lblJobSalary.Content = job.JobSalary;
            lblJobPostDate.Content = job.JobPostDate;
            if(MainWindow.user.UserRole == "Candidate")
            {
                btnDeleteJob.Visibility = Visibility.Collapsed;
                btnUpdateJob.Visibility = Visibility.Collapsed;
            }
            
           
        }

        private void btnJobDetail_Click(object sender, RoutedEventArgs e)
        {  
            WjobDetail wjobDetail = new WjobDetail(jobUpdate);
            wjobDetail.Show();

        }

        private void btnDeleteJob_Click(object sender, RoutedEventArgs e)
        {
            //delete vao databse
            Reply reply = new Reply(MainWindow.userCompany.UserID, 0, jobUpdate.JobID, "", "", null);
            ReplyDAO replyDAO = new ReplyDAO(reply, "DELETE FROM COMPANY_REPLY WHERE JobID = '" + reply.JobID + "'");

            Apply apply = new Apply(0, jobUpdate.JobID, 0, "", "");
            ApplyDAO applyDAO = new ApplyDAO(apply, "DELETE FROM JOB_NOTIFICATION WHERE JobID = '" + apply.JobID + "'");
            applyDAO.Delete();

            Job job = new Job(Convert.ToInt32(jobUpdate.JobID), 0, "", "", "", "", "", "", "", "", new bool());
            JobDAO jobDAO = new JobDAO(job, "DELETE FROM JOB WHERE JobID = '" + job.JobID + "'");
            jobDAO.Delete();

            
        }

        private void btnUpdateJob_Click(object sender, RoutedEventArgs e)
        {
            WUpdateJob wUpdateJob = new WUpdateJob(jobUpdate);
            wUpdateJob.txtJobName.Text = jobUpdate.JobName;
            wUpdateJob.txtJobType.Text = jobUpdate.JobType;
            wUpdateJob.txtJobLocation.Text = jobUpdate.JobLocation;
            wUpdateJob.txtJobSkills.Text = jobUpdate.JobSkills;
            wUpdateJob.txtJobSalary.Text = jobUpdate.JobSalary;
            wUpdateJob.txtJobDescription.Text = jobUpdate.JobDescription;
            wUpdateJob.txtJobQualification.Text = jobUpdate.JobQualification;
            wUpdateJob.Show();

            
        }
    }
}
