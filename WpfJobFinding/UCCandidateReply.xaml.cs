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
using WpfJobFinding.Model;
using WpfJobFinding.DAO;
namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCCandidateReply.xaml
    /// </summary>
    public partial class UCCandidateReply : UserControl
    {
        Reply reply;
        public UCCandidateReply(Reply reply)
        {
            InitializeComponent();
            this.reply = reply;
            SetMessageTitle();
            lblDataSent.Content = "Ngày gửi: "+reply.DateSent;
        }

        private void SetMessageTitle()
        {
            string name = FindCandidateName(reply.CandidateID);
            if (reply.Accept_Denied == true)
            {
                lblTitleMessage.Content = "Ứng viên " + name + " đồng ý phỏng vấn cho công việc " + SetJobName(reply.JobID);
            }
            else if(reply.Accept_Denied == false)
            {
                lblTitleMessage.Content = "Ứng viên " + name + " từ chối phỏng vấn "+ SetJobName(reply.JobID);
            }
        }

        private string SetJobName(int jobID)
        {
            Job job = new Job(jobID, 0, "", "", "", "", "", "", "", "", new bool());
            JobDAO jobDAO = new JobDAO(job, "SELECT * FROM JOB where JobID='" + job.JobID + "'");
            return jobDAO.Load().Rows[0]["JobName"].ToString();
        }

        private string FindCandidateName(int candidateID)
        {
            Candidate candidate = new Candidate(candidateID, "", "", "", "", "", "", "", "", "", "", "", "");
            CandidateDAO candidateDAO = new CandidateDAO(candidate, "Select * from USER_ACCOUNT where UserID='" + candidateID + "'");
            DataTable dataTable = candidateDAO.Load();
            return dataTable.Rows[0]["Fullname"].ToString();
        }
    }
}
