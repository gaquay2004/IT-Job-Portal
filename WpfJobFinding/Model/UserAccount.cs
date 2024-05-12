using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding.Model
{
    public class UserAccount
    {
        int userID;
        string fullname;
        string username;
        string userPassword;
        string userRole;
        string userEmail;

        public UserAccount(int userID, string fullname, string username, string userPassword, string userRole, string userEmail)
        {
            this.userID = userID;
            this.fullname = fullname;
            this.username = username;
            this.userPassword = userPassword;
            this.userRole = userRole;
            this.userEmail = userEmail;
        }

        
        public int UserID { get=> userID; set=>userID = value; }
        public string Fullname { get=>fullname; set=>fullname = value; }
        public string Username { get => username; set => username = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserRole { get => userRole; set => userRole = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }

    }
}
