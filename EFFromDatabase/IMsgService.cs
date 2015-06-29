using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFromDatabase
{
    public interface IMsgService
    {
        IQueryable<Reply> GetReplies();
        Reply FindById(int id);
    }

  public class MsgService : IMsgService
  {

      private readonly IMsgRepo _repo;

      public MsgService(IMsgRepo repo)
      {
          _repo = repo;
      }
     
      public IQueryable<Reply> GetReplies()
      {
        return  _repo.GetReplies(); 
      }

      public Reply FindById(int id)
      {
          return _repo.FindById(id); 
      }
  }
}
