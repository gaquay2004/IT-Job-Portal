using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for WjobDetail.xaml
    /// </summary>
    public partial class WjobDetail : Window
    {
        private List<Candidate> candidates = new List<Candidate>();
        Job job;

        public WjobDetail(Job job)
        {
            InitializeComponent();
            this.job = job;
            JobName.Content = job.JobName;
            JobType.Content = job.JobType;
            JobLocation.Content = job.JobLocation;
            JobPostdate.Content = job.JobPostDate;
            JobSalary.Content = job.JobSalary;
            JobDescription.Content = job.JobDescription;
            JobQualification.Content = job.JobQualification;
            JobSkill.Content = job.JobSkills;
            if (MainWindow.user.UserRole == "Company")
            {
                btnApplyJob.Visibility = Visibility.Collapsed;
                LoadCandidateList();
                cbListCandidate.ItemsSource = candidates;
                cbListCandidate.DisplayMemberPath = "Fullname";
                lblNoCandidate.Content = "Số ứng viên: " + candidates.Count;
                

            }
            else
            {
                VisibilityAndEnebledForCandidate();
            }

        }

        private void VisibilityAndEnebledForCandidate()
        {
            Apply apply = new Apply(MainWindow.userCandidate.UserID, job.JobID, 0, "", "");
            ApplyDAO applyDAO = new ApplyDAO(apply, "SELECT * FROM JOB_NOTIFICATION WHERE JobID='" + apply.JobID + "' AND CandidateID='" + apply.CandidateID + "'");
            
            if (job.Status == false || applyDAO.Load().Rows.Count > 0)
            {
                btnApplyJob.IsEnabled = false;
            }
            lblNoCandidate.Visibility = Visibility.Collapsed;
            cbListCandidate.Visibility = Visibility.Collapsed;
        }

        private void LoadCandidateList()
        {
            Candidate candidate = new Candidate(0, "", "", "", "", "", "", "", "", "", "", "", "");
            CandidateDAO candidateDAO = new CandidateDAO(candidate, "Select CandidateID from JOB_NOTIFICATION where JobID='" + this.job.JobID + "'");
            DataTable listCandidateID = candidateDAO.Load();
            for (int i = 0; i < listCandidateID.Rows.Count; i++)
            {
                UserAccount user1 = new UserAccount(Convert.ToInt32(listCandidateID.Rows[i]["CandidateID"]), "", "", "", "", "");
                UserAccountDAO userAccountDAO = new UserAccountDAO(user1, "SELECT * FROM USER_ACCOUNT WHERE UserID='" + user1.UserID + "'");
                DataTable user = userAccountDAO.Load();

                Candidate candidate1 = new Candidate(0, "", "", "", "", "", "", "", "", "","","","");
                CandidateDAO candidateDAO1 = new CandidateDAO(candidate, "Select * from CANDIDATE where CandidateID='" + Convert.ToInt32(listCandidateID.Rows[i]["CandidateID"]) + "'");
                DataTable candidatedt = candidateDAO1.Load();

                candidate1.UserID = Convert.ToInt32(listCandidateID.Rows[i]["CandidateID"]);
                candidate1.Fullname = user.Rows[0]["Fullname"].ToString();
                candidate1.UserEmail = user.Rows[0]["UserEmail"].ToString();
                candidate1.CandidateDoB = candidatedt.Rows[0]["CandidateDOB"].ToString();
                candidate1.CandidatePhone = candidatedt.Rows[0]["CandidatePhone"].ToString();
                candidate1.CandidateIntroduction = candidatedt.Rows[0]["CandidateIntroduction"].ToString();
                candidate1.CandidatePicture = candidatedt.Rows[0]["CandidatePicture"].ToString();
                candidate1.Qualification = candidatedt.Rows[0]["Qualification"].ToString();
                candidate1.Skill = candidatedt.Rows[0]["Skill"].ToString();
                candidate.YearOfExperience = candidatedt.Rows[0]["YearOfExperience"].ToString();
                candidates.Add(candidate1);


            }
        }

        private void btnApplyJob_Click(object sender, RoutedEventArgs e)
        {
            WApplyJob wApplyJob = new WApplyJob(job);
            wApplyJob.Show();
        }

        private void cbListCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            for(int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Fullname == (cbListCandidate.SelectedItem as Candidate).Fullname)
                {
                    Apply apply = new Apply(candidates[i].UserID, this.job.JobID, MainWindow.userCompany.UserID, "", "");
                    ApplyDAO applyDAO = new ApplyDAO(apply, "select * from JOB_NOTIFICATION where CandidateID='" + apply.CandidateID + "' and JobID='" + apply.JobID + "' and CompanyID='" + apply.CompanyID + "'");
                    DataTable data = applyDAO.Load();
                    apply.ReasonToJoin = data.Rows[0]["ReasonToJoin"].ToString();
                    apply.DateSent = Convert.ToDateTime(data.Rows[0]["DateSent"]).ToShortDateString();
                    WMessageDetail wMessageDetail = new WMessageDetail(apply, candidates[i]); 
                    wMessageDetail.Show();
                    
                    return;
                }
            }
        }
    }
}
