using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    public class Company : UserAccount
    {       
        string companyLogo;
        string companyPhone;
        string companyDescription;
        

      

        public Company(int userID, string fullname, string username, string userPassword, string userRole, string userEmail, string companyLogo, string companyPhone, string companyDescription)
            : base(userID, fullname, username, userPassword, userRole, userEmail)
        {
            
            this.companyLogo = companyLogo;
            this.companyPhone = companyPhone;         
            this.companyDescription = companyDescription;
            
        }      
        public string CompanyLogo { get => companyLogo; set => companyLogo = value; }
        public string CompanyPhone { get => companyPhone; set => companyPhone = value; }
        public string CompanyDescription { get => companyDescription; set => companyDescription = value; }
        

    }
}
