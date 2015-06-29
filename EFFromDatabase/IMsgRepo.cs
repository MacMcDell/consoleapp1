using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFromDatabase
{
   public  interface IMsgRepo
    {
    

        IQueryable<Reply> GetReplies();
        bool InsertReply(Reply newReply);
       Reply FindById(int id);
        bool DeleteReply(int id);


    }
}
