using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    //PAS OUBLIER 'public'

    //IDENTIQUE à la table dans la BD: 1 colonne dans DB -> 1 propriété ici
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
