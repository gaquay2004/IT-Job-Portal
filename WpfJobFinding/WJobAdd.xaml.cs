using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for WJobAdd.xaml
    /// </summary>
    /// 


    public partial class WJobAdd : Window
    {
       
        public WJobAdd()
        {
            InitializeComponent();
        }

        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            //insert vao databse
            Job job = new Job(0, MainWindow.userCompany.UserID, txtJobName.Text, txtJobType.Text, txtJobSalary.Text, txtJobDescription.Text, txtJobQualification.Text, txtJobLocation.Text, txtJobSkills.Text, "",true);
            JobDAO jobDAO = new JobDAO(job, "INSERT INTO JOB (CompanyID, JobName, JobType, JobSalary, JobDescription, JobQualification, JobLocation, JobSkills, JobStatus) VALUES (" + job.CompanyID + " , N'" + job.JobName + "', N'" + job.JobType + "', N'" + job.JobSalary + "', N'" + job.JobDescription + "', N'" + job.JobQualification + "', N'" + job.JobLocation + "', N'" + job.JobSkills +"','"+ job.Status +"')");
            jobDAO.Insert();

                  

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();          
        }
    }
}
