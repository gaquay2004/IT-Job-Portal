using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding
{
    public class CandidateDAO : BaseDAO
    {
        Candidate candidate;
        public CandidateDAO(Candidate candidate, string stringFormat): base(stringFormat) 
        {
            this.candidate = candidate;
            this.stringFormat = stringFormat;
           
        }

    }
}
