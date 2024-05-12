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
    /// Interaction logic for UCCompanyHighest.xaml
    /// </summary>
    public partial class UCCompanyHighest : UserControl
    {
        Company company;
        public UCCompanyHighest(Company c,int t)
        {
            InitializeComponent();
            this.company = c;
            try
            {
                
                lblFullname.Content = c.Fullname;
                lblEmail.Content = c.UserEmail;
                lblPhone.Content = c.CompanyPhone;
                lblDescription.Content = c.CompanyDescription;
                if (Check.CheckEmpty(c.CompanyLogo) == true)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(c.CompanyLogo));
                    ImageLogo.Source = bitmap;
                }
                lblNumber.Content=t.ToString();
            }
            catch
            {
                MessageBox.Show("Không load được ảnh ");
            }
            finally
            {

            }
        }

        

        private void btnJobList_Click(object sender, RoutedEventArgs e)
        {
            UCJobList uCJobList = new UCJobList("Select * from JOB where CompanyID='" + company.UserID + "'", company.UserID);
            WJobList wJobList= new WJobList(uCJobList);
            wJobList.Show();
        }
    }
}
