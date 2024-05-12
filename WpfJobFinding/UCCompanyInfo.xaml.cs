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

namespace WpfJobFinding
{
    /// <summary>
    /// Interaction logic for UCCompanyInfo.xaml
    /// </summary>
    public partial class UCCompanyInfo : UserControl
    {
        public UCCompanyInfo()
        {
            try
            {
                InitializeComponent();
                lblFullname.Content = MainWindow.user.Fullname;
                lblEmail.Content = MainWindow.userCompany.UserEmail;
                lblPhone.Content = MainWindow.userCompany.CompanyPhone;
                lblDescription.Content = MainWindow.userCompany.CompanyDescription;
                if (Check.CheckEmpty(MainWindow.userCompany.CompanyLogo) == true)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(MainWindow.userCompany.CompanyLogo));
                    ImageLogo.Source = bitmap;
                }
            }
            catch
            {
                MessageBox.Show("Không load được ảnh " );
            }
            finally
            {

            }

        }

        private void btnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            WUpdateUserInfo w=new WUpdateUserInfo();
            w.Show();
        }
    }
}
