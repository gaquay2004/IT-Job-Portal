using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJobFinding.Model;

namespace WpfJobFinding.DAO
{
    public class UserAccountDAO : BaseDAO
    {
        UserAccount userAccount;

        public UserAccountDAO(UserAccount userAccount, string stringFormat) : base(stringFormat)
        {
            this.userAccount = userAccount;
            this.stringFormat = stringFormat;
        }
    }
}
