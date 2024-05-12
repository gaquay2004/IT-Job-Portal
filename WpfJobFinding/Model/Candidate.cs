using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJobFinding.Model;

namespace WpfJobFinding
{
    public class Candidate : UserAccount
    { 
        string candidatePicture;    
        string candidatePhone;       
        string candidateDoB;
        string candidateIntroduction;
        string qualification;
        string skill;
        string yearOfExperience;



        public Candidate(int userID, string fullname, string username, string userPassword, string userRole, string userEmail, string candidatePicture, string candidatePhone, string candidateDoB, string candidateIntroduction, string qualification, string skill, string yearOfExperience) 
            : base (userID, fullname,  username,  userPassword,  userRole, userEmail)
        {          
            this.candidatePicture = candidatePicture;          
            this.candidatePhone = candidatePhone;           
            this.candidateDoB = candidateDoB;
            this.candidateIntroduction = candidateIntroduction;   
            this.qualification= qualification;
            this.skill = skill;
            this.yearOfExperience = yearOfExperience;

        }
    
        public string CandidatePicture { get => candidatePicture; set => candidatePicture = value; }
        public string CandidatePhone { get => candidatePhone; set => candidatePhone = value; }
        public string CandidateDoB { get => candidateDoB; set => candidateDoB = value; }
        public string CandidateIntroduction { get => candidateIntroduction; set => candidateIntroduction = value; }
        
        public string Qualification {  get => qualification; set => qualification = value; }
        public string Skill { get => skill; set => skill = value; }
        public string YearOfExperience {  get => yearOfExperience; set => yearOfExperience = value; }

    }
}
