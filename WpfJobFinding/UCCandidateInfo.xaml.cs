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
using WpfJobFinding.DAO;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCCandidateInfo.xaml
    /// </summary>
    public partial class UCCandidateInfo : UserControl
    {
        Candidate candidate;
        public UCCandidateInfo(Candidate candidate)
        {
            InitializeComponent();

            this.candidate = candidate;
            try
            {

                lblFullname.Content = candidate.Fullname;
                lblEmail.Content = candidate.UserEmail;
                lblPhone.Content = candidate.CandidatePhone;
                lblDoB.Content = candidate.CandidateDoB;
                lblIntroduction.Content = candidate.CandidateIntroduction;
                lblQual.Content = candidate.Qualification;
                lblSkill.Content=candidate.Skill;
                lblYoE.Content = candidate.YearOfExperience;
                if (MainWindow.user.UserRole == "Candidate")
                {
                    btnClose.Visibility= Visibility.Collapsed;
                }
                if (Check.CheckEmpty(MainWindow.userCandidate.CandidatePicture) == true)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(candidate.CandidatePicture));
                    Potrait.Source = bitmap;
                }
               
            }
            catch
            {

                MessageBox.Show("Profile picture(s) not found. Picture(s) will not be displayed.");
            }
            finally
            {

            }

        }

        

        private void btnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            WUpdateUserInfo w = new WUpdateUserInfo();
            w.Show();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

       
    }
}
