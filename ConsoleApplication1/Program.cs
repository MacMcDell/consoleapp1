using System;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFFromDatabase;
using Ninject;

namespace ConsoleApplication1
{



    internal class Program
    {
        private static IMsgRepo _repo;
        private static IMsgService _svc; 

        static void Main(string[] args)
        {
            Ninject.IKernel kernal = new StandardKernel(new Core());
            ////kernal.Bind<IMsgRepo>().To<MsgRepo>();
            _repo = kernal.Get<MsgRepo>();

            _svc = kernal.Get<MsgService>();

            var svcreplies = _svc.GetReplies();
            foreach (var x in svcreplies)
            {
                Console.WriteLine(x.Body);
            }



            Console.WriteLine("enter reply");
            var consoleReply = Console.ReadLine();

            var reply = new Reply()
            {
                Body = consoleReply,
                Created = DateTime.Now,
                TopicId = 1

            };

            _repo.InsertReply(reply);


            var replies = _repo.GetReplies();
            _repo.DeleteReply(replies.First().Id);


            foreach (var x in replies)
            {
                Console.WriteLine(x.Body);
            }



            Main(args);



            //var baseClass = new BaseClass();
            //var derivedOverride = new DerivedOverride();
            //var derivedNew = new DerivedNew();
            //var derivedOverWrite = new DerivedOverwrite();

            //baseClass.Name();
            //derivedOverride.Name();
            //derivedNew.Name();
            //derivedOverWrite.Name();

            //Console.ReadLine();
            //baseClass.Name();
            //derivedOverride.Name();
            //((BaseClass)derivedNew).Name();
            //((BaseClass)derivedOverWrite).Name();
            //Console.ReadLine();

            //var t1 = typeof(BaseClass);
            //Console.WriteLine(t1.Name);
            //Console.WriteLine(t1.Assembly);

            //Console.ReadLine();
        }

    }

    //internal class BaseClass
    //{
    //    internal virtual void Name()
    //    {
    //        Console.WriteLine("BaseClass");
    //    }
    //}

    //internal class DerivedOverride : BaseClass
    //{
    //    internal override void Name()
    //    {
    //        Console.WriteLine("DerivedOverride");
    //    }
    //}

    //internal class DerivedNew : BaseClass
    //{
    //    internal new void Name()
    //    {
    //        Console.WriteLine("New");
    //    }
    //}

    //internal class DerivedOverwrite : BaseClass
    //{
    //    internal void Name()
    //    {
    //        Console.WriteLine("Overwrite");
    //    }
    //}




}
