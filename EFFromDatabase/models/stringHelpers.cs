using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFromDatabase.Models
{
 public static class  StringHelpers
 {
     public static string MsgPretty(string msg)
     {
         if (msg.Length > 50)
             return msg.Substring(0, 47) + "...";
         return msg; 

     }



    }
}
