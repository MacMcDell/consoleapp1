using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFFromDatabase;
using Ninject.Modules;

namespace ConsoleApplication1
{
  public class Core : NinjectModule
    {
        public override void Load()
        {
            Bind<IMsgRepo>().To< MsgRepo>();
            Bind<IMsgService>().To<MsgService>();
        }
    }
}
