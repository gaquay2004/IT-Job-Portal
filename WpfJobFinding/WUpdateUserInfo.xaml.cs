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
using System.Windows.Shapes;
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for WUpdateUserInfo.xaml
    /// </summary>
    public partial class WUpdateUserInfo : Window
    {
        Candidate candidate;
        public WUpdateUserInfo()
        {          
            InitializeComponent();
           if(MainWindow.user.UserRole == "Candidate")
            {
                txtName.Text = MainWindow.userCandidate.Fullname;
                txtEmail.Text = MainWindow.userCandidate.UserEmail;
                txtImage.Text = MainWindow.userCandidate.CandidatePicture;
                txtPhoneNumber.Text = MainWindow.userCandidate.CandidatePhone;
                txtDescription.Text = MainWindow.userCandidate.CandidateIntroduction;
                txtQual.Text = MainWindow.userCandidate.Qualification;
                txtSkill.Text = MainWindow.userCandidate.Skill;
                txtYoE.Text = MainWindow.userCandidate.YearOfExperience;
                dpUserDob.Text = MainWindow.userCandidate.CandidateDoB;
           }
           else
           {
                dpUserDob.Visibility = Visibility.Collapsed;
                lblUserDoB.Visibility = Visibility.Collapsed;
                txtName.Text = MainWindow.userCompany.Fullname;
                txtEmail.Text = MainWindow.userCompany.UserEmail;
                txtImage.Text = MainWindow.userCompany.CompanyLogo;
                txtPhoneNumber.Text = MainWindow.userCompany.CompanyPhone;
                txtDescription.Text = MainWindow.userCompany.CompanyDescription;
            }

        }

        public WUpdateUserInfo(Candidate candidate)
        {
            InitializeComponent();
            this.candidate = candidate;
            txtName.Text = candidate.Fullname;
            txtEmail.Text = candidate.UserEmail;
            txtImage.Text = candidate.CandidatePicture;
            txtPhoneNumber.Text = candidate.CandidatePhone;
            txtDescription.Text = candidate.CandidateIntroduction;
            txtQual.Text = candidate.Qualification;
            txtSkill.Text = candidate.Skill;
            txtYoE.Text = candidate.YearOfExperience;
            dpUserDob.Text = candidate.CandidateDoB;
        }

        private void btnUpdateUserInfo_Click(object sender, RoutedEventArgs e)
        {
            if(Check.CheckEmpty(txtName.Text)==false|| Check.CheckEmpty(txtPhoneNumber.Text)==false|| Check.CheckEmpty(txtImage.Text)==false|| Check.CheckEmpty(txtEmail.Text)==false)
            {
                MessageBox.Show("Không được để trống thông tin quan trọng");
                return;
            }
            if (Check.CheckEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }
            if (Check.CheckPhone(txtPhoneNumber.Text)==false) 
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }

            MainWindow.user.Fullname = txtName.Text;
            MainWindow.user.UserEmail = txtEmail.Text;
            UserAccountDAO userAccountDAO = new UserAccountDAO(MainWindow.user, "Update USER_ACCOUNT SET Fullname= N'" + MainWindow.user.Fullname + "', UserEmail='" + MainWindow.user.UserEmail + "' where UserID='" + MainWindow.user.UserID + "'");
            userAccountDAO.Update();

            if (MainWindow.user.UserRole=="Company")
            {
                MainWindow.userCompany.CompanyPhone = txtPhoneNumber.Text;
                MainWindow.userCompany.CompanyDescription = txtDescription.Text;
                MainWindow.userCompany.CompanyLogo = txtImage.Text;

                CompanyDAO companyDAO = new CompanyDAO(MainWindow.userCompany, "Update COMPANY SET CompanyPhone='" + MainWindow.userCompany.CompanyPhone + "', CompanyDescription= N'" + MainWindow.userCompany.CompanyDescription + "', CompanyLogo= '" + MainWindow.userCompany.CompanyLogo + "' where CompanyID='" + MainWindow.userCompany.UserID + "'");
                companyDAO.Update();
            }
            else
            {
                MainWindow.userCandidate.CandidatePhone = txtPhoneNumber.Text;
                MainWindow.userCandidate.CandidatePicture = txtImage.Text;
                MainWindow.userCandidate.CandidateIntroduction = txtDescription.Text;
                MainWindow.userCandidate.CandidateDoB = dpUserDob.Text;
                MainWindow.userCandidate.Qualification = txtQual.Text;
                MainWindow.userCandidate.Skill=txtSkill.Text;
                MainWindow.userCandidate.YearOfExperience=txtYoE.Text;
                CandidateDAO candidateDAO = new CandidateDAO(MainWindow.userCandidate, "Update CANDIDATE SET CandidatePhone='" + MainWindow.userCandidate.CandidatePhone + "', CandidateDoB='" + MainWindow.userCandidate.CandidateDoB + "', CandidateIntroduction= N'" + MainWindow.userCandidate.CandidateIntroduction + "', CandidatePicture= N'" + MainWindow.userCandidate.CandidatePicture + "', Qualification= N'"+MainWindow.userCandidate.Qualification + "', Skill= N'"+MainWindow.userCandidate.Skill+ "',YearOfExperience= N'" + MainWindow.userCandidate.YearOfExperience + "' where CandidateID='" + MainWindow.userCandidate.UserID + "'");
                candidateDAO.Update();
            }

            this.Close();
        }
    }
}
