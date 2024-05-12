using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding.Model
{
    public  class Apply
    {
        int candidateID;
        int jobID;
        int companyID;
        string reasonToJoin;
        string dateSent;

        public Apply(int candidateID, int jobID, int companyID, string reasonToJoin, string dateSent)
        {
            this.candidateID = candidateID;
            this.jobID = jobID;
            this.companyID = companyID;           
            this.reasonToJoin = reasonToJoin;
            this.dateSent = dateSent;
        }

        public int CandidateID {  get { return candidateID; } set { candidateID = value; } }
        public int JobID { get { return jobID; } set {  jobID = value; } }
        public int CompanyID { get { return companyID; } set { companyID = value; } }
        public string ReasonToJoin { get {  return reasonToJoin; } set {  reasonToJoin = value; } }
        public string DateSent { get {  return dateSent; } set {  dateSent = value; } }
    }
}
