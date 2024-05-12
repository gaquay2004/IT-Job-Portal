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
    /// Interaction logic for UCCandidateList.xaml
    /// </summary>
    public partial class UCCandidateList : UserControl
    {
        Candidate candidateSample = new Candidate(0, "", "", "", "","","","","","", "", "", "");
        public UCCandidateList(string format)
        {
            InitializeComponent();
            LoadCandidateList(format);
        }
        public void LoadCandidateList(string format)
        {
            List<Candidate> list = new List<Candidate>();
            CandidateDAO c = new CandidateDAO(candidateSample, format);
            DataTable dt = new DataTable();
            dt = c.Load();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                Candidate com = new Candidate(MainWindow.userCandidate.UserID, "", "", "", "", "", "", "", "", "", "", "", "");
                com.UserID = Convert.ToInt32(dt.Rows[i]["CandidateID"].ToString());
                com.CandidatePhone = dt.Rows[i]["CandidatePhone"].ToString();
                if (dt.Rows[i]["CandidateDoB"] != DBNull.Value)
                {
                    com.CandidateDoB = Convert.ToDateTime(dt.Rows[i]["CandidateDoB"]).ToShortDateString();
                }
                com.CandidateIntroduction = dt.Rows[i]["CandidateIntroduction"].ToString();
                com.CandidatePicture = dt.Rows[i]["CandidatePicture"].ToString();
                com.Qualification = dt.Rows[i]["Qualification"].ToString();
                com.Skill = dt.Rows[i]["Skill"].ToString();
                com.YearOfExperience = dt.Rows[i]["YearOfExperience"].ToString();
                UserAccount account = new UserAccount(com.UserID, "", "", "", "", "");
                UserAccountDAO Dao = new UserAccountDAO(account, "SELECT *FROM USER_ACCOUNT WHERE UserID='" + com.UserID.ToString() + "'");
                DataTable dataTable = Dao.Load();
                com.Fullname = dataTable.Rows[0]["Fullname"].ToString();
                com.UserEmail = dataTable.Rows[0]["UserEmail"].ToString();
                list.Add(com);
               
            }
            ShowCandidateList(list);
        }
        public void ShowCandidateList(List<Candidate>list)
        {
            int count = 0;
            foreach (Candidate c in list)
            {
                UCCandidateC ucCL = new UCCandidateC(c);
                int dis = Convert.ToInt32(ucCL.ActualHeight);
                ucCL.Margin = new Thickness(0, dis * count + 10, 0, 0);
                panel.Children.Add(ucCL);
                count++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CandidateDAO a = new CandidateDAO(MainWindow.userCandidate, "SELECT *FROM Candidate");
            DataTable dt = a.Load();
            int c = Convert.ToInt32(dt.Rows[0]["Likes"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Likes"].ToString() != "")
                {
                    if (Convert.ToInt32(dt.Rows[i]["Likes"]) >= c)
                    {
                        c = Convert.ToInt32(dt.Rows[i]["Likes"]);
                    }
                }
            }
            Candidate d = new Candidate(0, "", "", "", "", "", "", "", "", "", "", "", "");

            CandidateDAO D = new CandidateDAO(d, "SELECT *FROM Candidate WHERE Likes='" + c.ToString() + "'");
            DataTable Dt = D.Load();
            d.UserID = Convert.ToInt32(Dt.Rows[0]["CandidateID"]);
            d.CandidatePicture = Dt.Rows[0]["CandidatePicture"].ToString();
            d.CandidatePhone = Dt.Rows[0]["CandidatePhone"].ToString();
            d.CandidateDoB = Dt.Rows[0]["CandidateDoB"].ToString();
            d.CandidateIntroduction = Dt.Rows[0]["CandidateIntroduction"].ToString();
            d.Qualification = Dt.Rows[0]["Qualification"].ToString();
            d.Skill = Dt.Rows[0]["Skill"].ToString();
            d.YearOfExperience = Dt.Rows[0]["YearOfExperience"].ToString();
            UserAccount account = new UserAccount(d.UserID, "", "", "", "", "");
            UserAccountDAO Dao = new UserAccountDAO(account, "SELECT *FROM USER_ACCOUNT WHERE UserID='" + d.UserID.ToString() + "'");
            DataTable dataTable = Dao.Load();
            d.Fullname = dataTable.Rows[0]["Fullname"].ToString();
            d.UserEmail = dataTable.Rows[0]["UserEmail"].ToString();
       
            WCandidateInfo t= new WCandidateInfo(d);
            t.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (panel.Children != null)
            {
                panel.Children.Clear();
            }
            if (txtSearchCandidate.Text == null)
            {
                LoadCandidateList("SELECT * FROM CANDIDATE ");
            }
            else
            {
                UserAccount userAccount = new UserAccount(0, txtSearchCandidate.Text, "", "", "", "");
                UserAccountDAO userAccountDAO = new UserAccountDAO(userAccount, "Select * FROM USER_ACCOUNT WHERE Fullname LIKE N'%" + userAccount.Fullname + "%'");
                DataTable dt = userAccountDAO.Load();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LoadCandidateList("SELECT * FROM CANDIDATE where CandidateID=" + Convert.ToInt32(dt.Rows[i]["UserID"]));
                }
               
            }
        }
    }
}
