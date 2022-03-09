using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Handlers
{
    public class Mapper
    {
        public static Prototype ToProtitype(IDataRecord record)
        {
            if (record is null) return null;
            return new Prototype
            {
                id = (int)record[nameof(Prototype.id)],
                lastName = (string)record[nameof(Prototype.lastName)],
                firstName = (string)record[nameof(Prototype.firstName)],
                profession = (string)record[nameof(Prototype.profession)],
                //profession = (record[nameof(Prototype.profession)] == DBNull.Value) ? null : (string)record[nameof(Prototype.profession)],
                dateBirthDate = (DateTime)record[nameof(Prototype.dateBirthDate)],
                email = (string)record[nameof(Prototype.email)],
                //PROPRIéTé NULLABLE:
                //login = (string)record[nameof(Prototype.login)],
                //psw = (string)record[nameof(Prototype.psw)],
                login = (record[nameof(Prototype.login)] == DBNull.Value) ? null : (string)record[nameof(Prototype.login)],
                psw = (record[nameof(Prototype.psw)] == DBNull.Value) ? null : (string)record[nameof(Prototype.psw)],
                Validate = (bool)record[nameof(Prototype.Validate)]

            };
        }
    }
}
