using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Candidate userCandidate = new Candidate(0, "", "", "", "", "", "", "", "", "", "", "", "");
        public static Company userCompany = new Company(0, "", "", "", "", "", "", "", "");
        public static UserAccount user = new UserAccount(0, "", "", "", "", "");
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpView signUpView = new SignUpView();
            signUpView.Show();
            this.Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            user = new UserAccount(0, "", this.txtUsername.Text, this.txtPassword.Text, "", "");
            UserAccountDAO userAccountDAO = new UserAccountDAO(user, "SELECT * FROM USER_ACCOUNT WHERE Username = '" + user.Username + "' AND UserPassword= '" + user.UserPassword + "'");
            DataTable dt = userAccountDAO.Load();
            if(dt.Rows.Count > 0 )
            {
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.Fullname= dt.Rows[0]["Fullname"].ToString();
                user.UserRole = dt.Rows[0]["UserRole"].ToString();
                user.UserEmail = dt.Rows[0]["UserEmail"].ToString();

                if(user.UserRole == "Candidate")
                {
                    LoadCandidate(dt, userCandidate, user);
                    //mở form ứng viên
                    MainCandidateView mainCandidateView = new MainCandidateView();
                    mainCandidateView.lblWelcome.Content = "Nice to meet you, candidate " + userCandidate.Fullname;
                    mainCandidateView.Show();
                    this.Close();
                }
                else
                {
                    LoadCompany(dt, userCompany, user);
                    //mở from cho công ty
                    userCompany.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    MainCompanyView companyView = new MainCompanyView();
                    companyView.lblWelcome.Content = "Welcome back, Company HR manager " + userCompany.Fullname;
                    companyView.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please try again!");
            }
            
        }


        public static void LoadCandidate(DataTable dt, Candidate candidate, UserAccount user)
        {
            CandidateDAO candidateDAO = new CandidateDAO(candidate, "SELECT * FROM CANDIDATE WHERE CandidateID ='" + user.UserID.ToString() + "'");
            DataTable candidateDT = candidateDAO.Load();
            candidate.UserID = user.UserID;
            candidate.Fullname = user.Fullname;
            candidate.Username = user.Username;
            candidate.UserPassword = user.UserPassword;
            candidate.UserRole = user.UserRole;
            candidate.UserEmail = user.UserEmail;
            candidate.CandidatePhone = candidateDT.Rows[0]["CandidatePhone"].ToString();
            candidate.CandidateDoB = candidateDT.Rows[0]["CandidateDoB"].ToString();
            candidate.CandidateIntroduction = candidateDT.Rows[0]["CandidateIntroduction"].ToString();
            candidate.CandidatePicture = candidateDT.Rows[0]["CandidatePicture"].ToString();
            candidate.Qualification = candidateDT.Rows[0]["Qualification"].ToString();
            candidate.Skill = candidateDT.Rows[0]["Skill"].ToString();
            candidate.YearOfExperience = candidateDT.Rows[0]["YearOfExperience"].ToString();


        }

        public static void LoadCompany(DataTable dt, Company company, UserAccount user)
        {
            CompanyDAO companyDAO = new CompanyDAO(company, "SELECT * FROM COMPANY WHERE CompanyID ='" + user.UserID.ToString() + "'");
            DataTable companyDT = companyDAO.Load();
            company.UserID = user.UserID;
            company.Fullname = user.Fullname;
            company.Username = user.Username;
            company.UserPassword = user.UserPassword;
            company.UserRole = user.UserRole;
            company.UserEmail = user.UserEmail;
            company.CompanyPhone = companyDT.Rows[0]["CompanyPhone"].ToString();
            company.CompanyDescription = companyDT.Rows[0]["CompanyDescription"].ToString();
            company.CompanyLogo = companyDT.Rows[0]["CompanyLogo"].ToString();

            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

    }

            
    

                
            
    
    
}
