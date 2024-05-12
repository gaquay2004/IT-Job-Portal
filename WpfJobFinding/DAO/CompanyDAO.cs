using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJobFinding
{
    public class CompanyDAO : BaseDAO
    {
        Company company;
        public CompanyDAO(Company company, string stringFormat): base(stringFormat) 

        { 
            this.company = company;
            this.stringFormat = stringFormat;
           
        }

    }
}
