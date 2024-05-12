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
using WpfJobFinding.Model;
using WpfJobFinding.DAO;

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void btnSignUpForm_Click(object sender, RoutedEventArgs e)
        {

            //insert vào user account
            string role;
            if(rbCandidate.IsChecked == true)
            {
                role = "Candidate";
            }
            else if(rbCompany.IsChecked == true)
            {
                role = "Company";
            }
            else
            {
                MessageBox.Show("hãy chọn vai trò của bạn");
                return;
            }
            if(Check.CheckEmail(txtEmail.Text)==false)
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }
            if(Check.CheckEmpty(txtFullname.Text)==false||Check.CheckEmpty(txtUsername.Text)==false||Check.CheckEmpty(txtPassword.Text)==false||Check.CheckEmpty(txtEmail.Text)==false) 
            {
                MessageBox.Show("Thông tin không hợp lệ");
                return;
            }
            
            UserAccount userAccount = new UserAccount(0, this.txtFullname.Text, this.txtUsername.Text, this.txtPassword.Text, role, this.txtEmail.Text);      
            
            UserAccountDAO userAccountDAO = new UserAccountDAO(userAccount, "INSERT INTO USER_ACCOUNT (Username, UserPassword, Fullname, UserRole, UserEmail) VALUES (N'" + userAccount.Username + "', N'" + userAccount.UserPassword + "', N'" + userAccount.Fullname + "', N'" + userAccount.UserRole + "',N'" + userAccount.UserEmail + "')");
            userAccountDAO.Insert();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
