using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJobFinding.Model;

namespace WpfJobFinding.DAO
{
    internal class ApplyDAO:BaseDAO
    {
        Apply apply;
        public ApplyDAO(Apply apply,string format):base(format)
        {
            this.apply = apply;
            this.stringFormat = format;
        }
    }
}
