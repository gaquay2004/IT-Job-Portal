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

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for MainCompanyView.xaml
    /// </summary>
    public partial class MainCompanyView : Window
    {
        
        public MainCompanyView()
        {
            InitializeComponent();
            
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
       

        private void btnJobList_Click(object sender, RoutedEventArgs e)
        {
            if(spListjob.Children.Count > 0)
            {
                spListjob.Children.Clear();
            }
            UCJobList jobList = new UCJobList("SELECT * FROM JOB WHERE CompanyID='" + MainWindow.userCompany.UserID + "'");
            //jobList.Margin = new Thickness(0, 0 , 0, 0);
            jobList.Height = spListjob.ActualHeight;
            jobList.Width = spListjob.ActualWidth;
            spListjob.Children.Add(jobList);
           
        }

        private void btnCompanyInfo_Click(object sender, RoutedEventArgs e)
        {
            if (spListjob.Children.Count > 0)
            {
                spListjob.Children.Clear();
            }
            UCCompanyInfo userInfo = new UCCompanyInfo();
            //userInfo.Margin = new Thickness(0, 0, 0, 0);
            userInfo.Height = spListjob.ActualHeight;
            userInfo.Width = spListjob.ActualWidth;
            spListjob.Children.Add(userInfo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (spListjob.Children.Count > 0)
            {
                spListjob.Children.Clear();
            }
            UCNotification uCNotification = new UCNotification("select * from COMPANY_REPLY where CompanyID='" + MainWindow.userCompany.UserID + "'");
            //uCNotification.Margin = new Thickness(0, 0, 0, 0);
            uCNotification.Height = spListjob.ActualHeight;
            uCNotification.Width = spListjob.ActualWidth;
            spListjob.Children.Add(uCNotification);
        }

        private void btnCandidateList_Click(object sender, RoutedEventArgs e)
        {
            if (spListjob.Children.Count > 0)
            {
                spListjob.Children.Clear();
            }
            UCCandidateList userInfo = new UCCandidateList("SELECT * FROM CANDIDATE ");
            userInfo.Height = spListjob.ActualHeight;
            userInfo.Width = spListjob.ActualWidth;
            spListjob.Children.Add(userInfo);

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
