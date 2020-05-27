using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAppPractice.Data.Entities
{
    public class Account
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public int age { get; set; }

    }
}
