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
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCCompanyReply.xaml
    /// </summary>
    public partial class UCCompanyReply : UserControl
    {
        Reply reply;
        public UCCompanyReply(Reply reply)
        {
            InitializeComponent();
            this.reply = reply;

            lblTitleMessage.Content = "Phản hồi ứng tuyển job " + GetJobName(reply.JobID);
            lblDataSent.Content = "Ngày gửi: " + reply.DateSent;
        }

        private string GetJobName(int jobId)
        {
            Job job = new Job(jobId, 0, "", "", "", "", "", "", "", "",new bool());
            JobDAO jobDAO = new JobDAO(job, "Select * from JOB where JobID='" + job.JobID + "'");
            return jobDAO.Load().Rows[0]["JobName"].ToString();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            WMessageDetail wMessageDetail = new WMessageDetail(reply);
            wMessageDetail.Show();
        }
    }
}
