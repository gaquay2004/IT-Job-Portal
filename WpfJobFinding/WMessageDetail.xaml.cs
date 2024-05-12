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
using System.Windows.Shapes;
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for WMessageDetail.xaml
    /// </summary>
    public partial class WMessageDetail : Window
    {
        Apply apply;        
        Candidate candidate;
        Reply reply;
        public WMessageDetail( Apply apply,Candidate candidate)
        {
            InitializeComponent();
            this.apply = apply;
            this.candidate = candidate;

            lblMessageTitle.Content = "Đơn ứng tuyển công việc " + GetJobName(apply.JobID);
            lblMessageFrom.Content =  candidate.Fullname;
            lblDateSent.Content =  this.apply.DateSent;
            lblMessage.Content = apply.ReasonToJoin;

            VisibilityAndEnabledForCompay();
        }

        public WMessageDetail(Reply reply)
        {
            InitializeComponent();
            this.reply = reply;

            lblMessageTitle.Content = "Thư phản hồi cho công việc " + GetJobName(reply.JobID);
            lblMessageFrom.Content = GetCompanyName(reply.CompanyID);
            lblDateSent.Content = reply.DateSent;
            lblMessage.Content = reply.ReplyMessage;

            VisibilityAndEnabledForCandidate();


        }

        private void VisibilityAndEnabledForCompay()
        {
            ApplyDAO applyDAO = new ApplyDAO(apply, "Select* from COMPANY_REPLY where CompanyID='" + apply.CompanyID + "'AND JobID='" + apply.JobID + "' AND CandidateID='"+apply.CandidateID+"'");

            if (applyDAO.Load().Rows.Count > 0)
            {
                btnReply.IsEnabled = false;
            }
            lblPhanHoiYeuCauPV.Visibility = Visibility.Collapsed;
            rbAccept.Visibility = Visibility.Collapsed;
            rbDenied.Visibility = Visibility.Collapsed;
        }

        private void VisibilityAndEnabledForCandidate()
        {
            lblXemHoSoUV.Visibility = Visibility.Collapsed;
            btnWatchCandidateInfo.Visibility = Visibility.Collapsed;
            if (reply.Accept_Denied !=null)
            {
                btnReply.IsEnabled = false;
                rbDenied.IsEnabled = false;
                rbAccept.IsEnabled = false;
            }
            if (reply.Accept_Denied == true)
            {
                rbAccept.IsChecked = true;
            }
            else
            {
                rbDenied.IsChecked = true;
            }
            
        }

        private string GetJobName(int jobID)
        {
            Job job = new Job(jobID, MainWindow.userCompany.UserID, "", "", "", "", "", "", "", "", new bool());
            JobDAO jobDAO = new JobDAO(job, "select * from JOB where jobID='" + job.JobID + "'");
            return jobDAO.Load().Rows[0]["JobName"].ToString();
        }

        private string GetCompanyName(int companyID)
        {
            Company company = new Company(companyID, "", "", "", "", "", "", "", "");
            CompanyDAO companyDAO = new CompanyDAO(company, "Select * from USER_ACCOUNT where UserID='" + company.UserID + "'");
            return companyDAO.Load().Rows[0]["Fullname"].ToString();
        }

        private void btnWatchCandidateInfo_Click(object sender, RoutedEventArgs e)
        {
            WCandidateInfo wCandidateInfo = new WCandidateInfo(candidate);
            wCandidateInfo.Show();
        }

        private void btnReply_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.user.UserRole == "Company")
            {
                WCompanyReply reply = new WCompanyReply(candidate, apply.JobID);
                reply.Show();
            }
            else
            {
                if(rbAccept.IsChecked == true || rbDenied.IsChecked == true)
                {
                    if (rbDenied.IsChecked == true)
                    {
                        DeleteApply();
                    }
                    Accepted_DeniedUpdate();
                    MessageBox.Show("Cảm ơn vì đã phản hồi");
                }
                else
                {
                    MessageBox.Show("Xin hãy chọn đi phỏng vấn hoặc không");
                }

            }
            GetWindow(this).Close();
           
        }

        private void DeleteApply()
        {
            Apply apply = new Apply(MainWindow.userCandidate.UserID, reply.JobID, reply.CompanyID, "", "");
            ApplyDAO applyDAO = new ApplyDAO(apply, "DELETE FROM JOB_NOTIFICATION WHERE CandidateID='" + apply.CandidateID + "' AND JobID='" + apply.JobID + "'");
            applyDAO.Delete();
        }

        private void Accepted_DeniedUpdate()
        {
            bool interviewReply;
            if(rbDenied.IsChecked == true)
            {
                interviewReply= false;
            }
            else
            {
                interviewReply = true;
            }

            ReplyDAO replyDAO = new ReplyDAO(reply, "Update COMPANY_REPLY set Accept_denied='" + interviewReply + "'");
            replyDAO.Update();
        }
    }
}
