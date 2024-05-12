using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJobFinding.Model;

namespace WpfJobFinding.DAO
{
    public class ReplyDAO :BaseDAO
    {
        Reply reply;
        public ReplyDAO(Reply reply, string format) : base(format)
        {
            this.reply = reply;
            this.stringFormat = format;
        }
    }
}
