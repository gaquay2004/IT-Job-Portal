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
    /// Interaction logic for UCCandidateC.xaml
    /// </summary>
    public partial class UCCandidateC : UserControl
    { 
        Candidate a;
        public UCCandidateC(Candidate c)
        {
            InitializeComponent();
            lblName.Content=c.Fullname;
            lblEmail.Content = c.UserEmail;
            lblPhone.Content = c.CandidatePhone;
            a = c;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            WCandidateInfo t = new WCandidateInfo(a);
            t.Show();
        }
    }
}
