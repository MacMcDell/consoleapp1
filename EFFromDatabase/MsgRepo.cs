using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EFFromDatabase.Models;

namespace EFFromDatabase
{
    public class MsgRepo : IMsgRepo
    {
        private readonly MsgboardContext _ctx;

        public MsgRepo(MsgboardContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Reply> GetReplies()
        {
            return _ctx.Replies;

        }
        public bool InsertReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public Reply FindById(int id)
        {
            return _ctx.Replies.Single(x => x.Id == id);
        }

        public bool DeleteReply(int id)
        {
           var reply = _ctx.Replies.Single(x => x.Id == id);
            _ctx.Replies.Remove(reply);
            _ctx.SaveChanges();
            return true;
        }
    }
}
