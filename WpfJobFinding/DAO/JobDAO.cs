using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding
{
    public class JobDAO : BaseDAO
    {
        Job job;
        public JobDAO(Job job, string stringFormat) : base(stringFormat)
        {            
            this.job = job;
            this.stringFormat = stringFormat;
            
        } 
    }
}
