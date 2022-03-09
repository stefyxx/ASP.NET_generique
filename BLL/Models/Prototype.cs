using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    //PAS OUBLIER 'public'
    public class Prototype
    {
        public int id { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string profession { get; set; }
      
        public DateTime dateBirthDate { get; set; }

        public string email { get; set; }

        public string? login { get; set; }

        public string? psw { get; set; }

        public bool Validate { get; set; }


    }
}
