using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding.Model
{
    public class Reply
    {
        int companyID;
        int candidateID;
        int jobID;
        string replyMessage;
        string dateSent;
        bool? accept_denied;

        public Reply(int companyID, int candidateID, int jobID, string replyMessage, string dateSent, bool? accept_denied)
        {
            this.companyID = companyID;
            this.candidateID = candidateID;
            this.jobID = jobID;
            this.replyMessage = replyMessage;
            this.dateSent = dateSent;
            this.accept_denied = accept_denied;
        }

        public int CandidateID { get { return candidateID; } set { candidateID = value; } }      
        public int CompanyID { get { return companyID; } set { companyID = value; } }
        public int JobID { get { return jobID; } set { jobID = value; } }
        public string ReplyMessage { get { return replyMessage; } set { replyMessage = value; } }
        public string DateSent { get { return dateSent; } set { dateSent = value; } }
        public bool? Accept_Denied { get { return accept_denied; } set { accept_denied = value; } }
    }
}
