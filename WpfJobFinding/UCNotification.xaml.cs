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
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCNotification.xaml
    /// </summary>
    public partial class UCNotification : UserControl
    {
        Reply replySample = new Reply(0, 0, 0,"", "", null);
        public UCNotification(string format)
        {
            InitializeComponent();
            LoadNotifications(format);
        }

        public void LoadNotifications(string selectFormat)
        {
            List<Reply> replys = new List<Reply>();
            ReplyDAO replyDAO = new ReplyDAO(replySample, selectFormat);
            DataTable replyData = new DataTable();
            replyData = replyDAO.Load();
            for (int i = replyData.Rows.Count - 1; i >= 0; i--)
            {
                
                Reply reply = new Reply(MainWindow.userCompany.UserID, 0,0, "", "", null);
                if (replyData.Rows[i]["Accept_denied"] != DBNull.Value)
                {
                    reply.Accept_Denied = Convert.ToBoolean(replyData.Rows[i]["Accept_denied"]);
                }
                reply.CandidateID = Convert.ToInt32(replyData.Rows[i]["CandidateID"]);         
                reply.CompanyID = Convert.ToInt32(replyData.Rows[i]["CompanyID"]);
                reply.JobID = Convert.ToInt32(replyData.Rows[i]["JobID"]);
                reply.ReplyMessage = replyData.Rows[i]["Reply"].ToString();
                reply.DateSent = Convert.ToDateTime(replyData.Rows[i]["DateSent"]).ToShortDateString();               
                

                replys.Add(reply);

            }
            ShowNotifications(replys);
        }

        public void ShowNotifications(List<Reply> replys)
        {

            int count = 0;
            foreach (Reply j in replys)
            {
                
                if (MainWindow.user.UserRole == "Company" && j.Accept_Denied!=null)
                {
                    UCCandidateReply ucCandidateReply = new UCCandidateReply(j);
                    int dis = Convert.ToInt32(ucCandidateReply.ActualHeight);
                    ucCandidateReply.Margin = new Thickness(0, dis * count + 10, 0, 0);
                    MessageListPanel.Children.Add(ucCandidateReply);
                    
                }
                else if(MainWindow.user.UserRole == "Candidate")
                {
                    UCCompanyReply uCCompanyReply = new UCCompanyReply(j);
                    int dis = Convert.ToInt32(uCCompanyReply.ActualHeight);
                    uCCompanyReply.Margin = new Thickness(0, dis * count + 10, 0, 0);
                    MessageListPanel.Children.Add(uCCompanyReply);
                }
                count++;
            }

        }

        

        private void btnFilter_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageListPanel.Children != null)
            {
                MessageListPanel.Children.Clear();
            }
            DateTime? selectedDateNullable = dpFilterMessage.SelectedDate;

            // Kiểm tra nếu có giá trị được chọn từ DatePicker
            if (selectedDateNullable != null)
            {
                DateTime selectedDate = selectedDateNullable.Value;
                if (MainWindow.user.UserRole == "Company")
                {
                    LoadNotifications("Select * from COMPANY_REPLY where CompanyID='" + MainWindow.userCompany.UserID + "' AND DateSent ='" + selectedDate.Date + "'");
                }
                else
                {
                    LoadNotifications("Select * from COMPANY_REPLY where CandidateID='" + MainWindow.userCandidate.UserID + "' AND DateSent ='" + selectedDate.Date + "'");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ngày từ DatePicker.");
            }
        }
    }
}
