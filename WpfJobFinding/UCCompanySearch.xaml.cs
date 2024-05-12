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
//using System.Windows.Forms;
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
    /// Interaction logic for UCCompanySearch.xaml
    /// </summary>
    public partial class UCCompanySearch : UserControl
    {
        Company companySamble = new Company(0, "", "", "", "", "", "", "", "");
        public UCCompanySearch(string format)
        {
            InitializeComponent();
            LoadCompanyList(format);
        }
        public void LoadCompanyList(string selectFormat) 
        {
           List<Company> list = new List<Company>();
           CompanyDAO c=new CompanyDAO(companySamble, selectFormat);
           DataTable dt=new DataTable();
            dt = c.Load();
            for (int i =dt.Rows.Count - 1; i >= 0; i--)
            {
                Company com = new Company(0,"", "", "", "", "", "", "","");
                com.UserID = Convert.ToInt32(dt.Rows[i]["CompanyID"].ToString());
                com.CompanyPhone = dt.Rows[i]["CompanyPhone"].ToString();
                com.CompanyLogo = dt.Rows[i]["CompanyLogo"].ToString();
                com.CompanyDescription = dt.Rows[i]["CompanyDescription"].ToString();
                UserAccount account = new UserAccount(com.UserID, "", "", "", "", "");
                UserAccountDAO Dao = new UserAccountDAO(account, "SELECT *FROM USER_ACCOUNT WHERE UserID='" + com.UserID.ToString() + "'");
                DataTable dataTable = Dao.Load();
                com.Fullname = dataTable.Rows[0]["Fullname"].ToString();
                com.UserEmail = dataTable.Rows[0]["UserEmail"].ToString();
                list.Add(com);
            }
            ShowCompanyList(list);
        }
        public void ShowCompanyList(List<Company> list)
        {
            int count = 0;
            foreach (Company c in list)
            {
                UCCompanyList ucCL = new UCCompanyList(c);
                int dis = Convert.ToInt32(ucCL.ActualHeight);
                ucCL.Margin = new Thickness(0, dis * count + 10, 0, 0);
                CompanyListPanel.Children.Add(ucCL);
                count++;

            }
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            CompanyDAO a = new CompanyDAO(MainWindow.userCompany, "SELECT *FROM COMPANY");
            DataTable dt = a.Load();
            int c = Convert.ToInt32(dt.Rows[0]["JobNumber"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["JobNumber"].ToString() != "")
                {
                    if (Convert.ToInt32(dt.Rows[i]["JobNumber"]) >= c)
                    {
                        c = Convert.ToInt32(dt.Rows[i]["JobNumber"]);
                    }
                }
            }
            Company d = new Company(0, "", "", "", "", "", "", "", "");
            
            CompanyDAO D = new CompanyDAO(d, "SELECT *FROM COMPANY WHERE JobNumber='" + c.ToString() + "'");
            DataTable Dt = D.Load();
            d.UserID = Convert.ToInt32(Dt.Rows[0]["CompanyID"]);
            d.CompanyLogo = Dt.Rows[0]["CompanyLogo"].ToString();
            d.CompanyPhone = Dt.Rows[0]["CompanyPhone"].ToString();
            d.CompanyDescription = Dt.Rows[0]["CompanyDescription"].ToString();
            UserAccount account = new UserAccount(d.UserID,"","","","","");
            UserAccountDAO Dao= new UserAccountDAO(account, "SELECT *FROM USER_ACCOUNT WHERE UserID='" + d.UserID.ToString() + "'");
            DataTable dataTable=Dao.Load();
            d.Fullname = dataTable.Rows[0]["Fullname"].ToString();
            d.UserEmail = dataTable.Rows[0]["UserEmail"].ToString();
            UCCompanyHighest high= new UCCompanyHighest(d,c);
            WCompanyHighest t=new WCompanyHighest(high);
            t.Show();
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyListPanel.Children != null)
            {
                CompanyListPanel.Children.Clear();
            }
            if (txtSearchCompany.Text == null)
            {
                LoadCompanyList("SELECT * FROM COMPANY order by (select CandidateID from APPLY_JOB) DESC");
            }
            else
            {
                UserAccount userAccount = new UserAccount(0, txtSearchCompany.Text, "", "", "", "");
                UserAccountDAO userAccountDAO = new UserAccountDAO(userAccount, "Select * FROM USER_ACCOUNT WHERE Fullname LIKE N'%" + userAccount.Fullname + "%'");
                DataTable dt = userAccountDAO.Load();
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    LoadCompanyList("SELECT * FROM COMPANY where CompanyID=" + Convert.ToInt32(dt.Rows[i]["UserID"]));
                }
            }
        }
    }
}
