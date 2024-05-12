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
    /// Interaction logic for WCandidateInfo.xaml
    /// </summary>
    public partial class WCandidateInfo : Window
    {
        public WCandidateInfo(Candidate candidate)
        {
            InitializeComponent();
            UCCandidateInfo uCCandidateInfo = new UCCandidateInfo(candidate);
            uCCandidateInfo.btnUpdateInfo.Visibility = Visibility.Collapsed;
            this.Content = uCCandidateInfo;
        }
    }
}
