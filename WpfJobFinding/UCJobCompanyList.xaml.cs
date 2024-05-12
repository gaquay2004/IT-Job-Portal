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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCJobCompanyList.xaml
    /// </summary>
    public partial class UCJobCompanyList : UserControl
    {
        Job jobSample = new Job(0, 0, "", "", "", "", "", "", "", "", new bool());
        Company company;

        public UCJobCompanyList(Company c)
        {
            InitializeComponent();
            company = c;
            JobDAO a = new JobDAO(jobSample, "SELECT * FROM JOB WHERE CompanyID='" + c.UserID + "'");
            DataTable dt = a.Load();

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                Job job = new Job(0, MainWindow.userCompany.UserID, "", "", "", "", "", "", "", "", new bool());
                job.JobID = Convert.ToInt32(dt.Rows[i]["JobID"]);
                job.CompanyID = Convert.ToInt32(dt.Rows[i]["CompanyID"]);
                job.JobName = dt.Rows[i]["JobName"].ToString();
                job.JobType = dt.Rows[i]["JobType"].ToString();
                job.JobSalary = dt.Rows[i]["JobSalary"].ToString();
                job.JobDescription = dt.Rows[i]["JobDescription"].ToString();
                job.JobQualification = dt.Rows[i]["JobQualification"].ToString();
                job.JobLocation = dt.Rows[i]["JobLocation"].ToString();
                job.JobSkills = dt.Rows[i]["JobSkills"].ToString();
                job.JobPostDate = Convert.ToDateTime(dt.Rows[i]["JobPostDate"]).ToShortDateString();
                UCJob f=new UCJob(job);
                Panel.Children.Add(f);

            }

        
       
        }


    }
}
