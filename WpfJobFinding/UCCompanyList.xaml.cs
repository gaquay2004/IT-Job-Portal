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
    /// Interaction logic for UCCompanyList.xaml
    /// </summary>
    public partial class UCCompanyList : UserControl
    {
        Company a;
        public UCCompanyList(Company c)
        {
            InitializeComponent();
            lblPhone.Content = c.CompanyPhone;
            lblEmail.Content=c.UserEmail;
            lblName.Content = c.Fullname;
            a = c;
        }     

        private void btnCompanyInfo_Click(object sender, RoutedEventArgs e)
        {
            UCCompanyHighest t = new UCCompanyHighest(a, 0);
            t.lblNumber.Visibility = Visibility.Collapsed;
            t.lblText.Visibility = Visibility.Collapsed;
            WCompanyHighest b = new WCompanyHighest(t);
            b.Show();
        }
    }
}
