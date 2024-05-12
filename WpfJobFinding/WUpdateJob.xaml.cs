using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for WUpdateJob.xaml
    /// </summary>
    public partial class WUpdateJob : Window
    {
       
        Job jobAdd;

        public WUpdateJob(Job job)
        {
            InitializeComponent();            
            this.jobAdd = job;
            if(jobAdd.Status == true )
            {
                ckbStatus.IsChecked = true;
            }
        }

        

        private void btnUpdateJob_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = ckbStatus.IsChecked ?? false;
            Job job = new Job(jobAdd.JobID, 0, this.txtJobName.Text, this.txtJobType.Text, this.txtJobSalary.Text, this.txtJobDescription.Text, this.txtJobQualification.Text, this.txtJobLocation.Text, this.txtJobSkills.Text, "", isChecked);                     
            JobDAO jobDAO = new JobDAO(job, "UPDATE JOB SET JobName = N'" + job.JobName + "', JobType = N'" + job.JobType + "', JobSalary = N'" + job.JobSalary + "', JobDescription = N'" + job.JobDescription + "', JobQualification = N'" + job.JobQualification + "',JobLocation= N'" + job.JobLocation + "', JobSkills= N'" + job.JobSkills + "',JobStatus='"+ job.Status +"' WHERE JobID = '" + job.JobID + "'");
            jobDAO.Update();
            this.Close();           
        }

        private bool SetStatus(bool? status)
        {
            if(status == true)
            {
                return true;
            }
            return false;
        }
        

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
