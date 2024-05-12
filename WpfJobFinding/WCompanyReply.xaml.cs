using MainWindow;
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
    /// Interaction logic for WCompanyReply.xaml
    /// </summary>
    public partial class WCompanyReply : Window
    {
        Candidate candidate;
        int jobID;
        public WCompanyReply(Candidate candidate, int jobID)
        {
            InitializeComponent();
            this.candidate = candidate;
            this.jobID = jobID;
        }

        private void btnSent_Click(object sender, RoutedEventArgs e)
        {
            Reply reply = new Reply(MainWindow.userCompany.UserID, candidate.UserID, jobID, txtReplyMessage.Text, "", new bool());
            ReplyDAO replyDAO = new ReplyDAO(reply, "insert into COMPANY_REPLY (CompanyID,CandidateID, jobID, Reply) values ('" + reply.CompanyID + "','" + reply.CandidateID +"','"+reply.JobID +"',N'" + reply.ReplyMessage + "')");
            replyDAO.Insert();
            this.Close();
        }
    }
}
