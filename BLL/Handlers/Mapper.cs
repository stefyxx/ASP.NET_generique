using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Handlers
{
    //  PAS OUBLIER public static
    public static class Mapper
    {
        public static BLL.Models.Prototype ToBLL(this DAL.Models.Prototype prototype)
        {
            if (prototype == null) return null;
            return new Models.Prototype
            {
                id = prototype.id,
                lastName = prototype.lastName,
                firstName = prototype.firstName,
                profession = prototype.profession,
                dateBirthDate = prototype.dateBirthDate,
                email = prototype.email,
                //una string puo' essere NULL tranquilmente
                login = (prototype.login is null)?null:(string)prototype.login,
                psw = (prototype.login is null) ? null : (string)prototype.psw,
                Validate = prototype.Validate
            };
        }

        public static DAL.Models.Prototype ToDAL(this BLL.Models.Prototype prototype)
        {
            if (prototype == null) return null;
            return new DAL.Models.Prototype
            {
                id = prototype.id,
                lastName = prototype.lastName,
                firstName = prototype.firstName,
                profession = prototype.profession,
                dateBirthDate = prototype.dateBirthDate,
                email = prototype.email,
                //una string puo' essere NULL tranquilmente
                login = (prototype.login is null) ? null : (string)prototype.login,
                psw = (prototype.login is null) ? null : (string)prototype.psw,
                Validate = prototype.Validate
            };
        }

    }
}
