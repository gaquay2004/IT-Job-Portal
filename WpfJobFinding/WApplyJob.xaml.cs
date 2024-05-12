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
using System.Windows.Shapes;
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for WApplyJob.xaml
    /// </summary>
    public partial class WApplyJob : Window
    {
        Job job;
        public WApplyJob(Job job)
        {
            InitializeComponent();
            this.job = job;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Apply apply = new Apply(MainWindow.userCandidate.UserID, job.JobID, job.CompanyID, txtReason.Text, "");
            ApplyDAO applyDAO = new ApplyDAO(apply, "insert into JOB_NOTIFICATION (CandidateID, JobID, CompanyID, ReasonToJoin) values ('" + apply.CandidateID + "','" + apply.JobID + "','" + apply.CompanyID + "', N'" + apply.ReasonToJoin + "')");
            applyDAO.Insert();
            this.Close();
        }
    }
}
