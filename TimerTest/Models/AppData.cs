using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTest.Models
{
    static public class AppData
    {
        static public OOO_MalyshEntities db = new OOO_MalyshEntities();
        static public int CurrentAccessLevel = 0;

        public static class UserPermissions
        {
            public static int CurrentAccessLevel { get; set; }
        }
    }
}
