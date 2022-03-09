using Common;
using DAL.Handlers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository
{
    public class PrototypeServices : ConnectionBase, IRepository<Prototype>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand()) 
                { 
                    //cmd.CommandText = "DELETE FROM [Prototype] WHERE [id] = @id";

                    cmd.CommandText = "UPDATE [Prototype] SET [login]=NULL, [psw]=NULL, [Validate]=0 WHERE [id]=@id";
                    
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);
                    c.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public Prototype Get(int id)
        {
        using (SqlConnection connection = new SqlConnection(_connString))
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT [id], [lastName], [firstName],[profession], [dateBirthDate], [email], [login] FROM [Protitype] WHERE [Id] = @id";
                //Parameters...
                SqlParameter p_id = new SqlParameter("id", id);
                command.Parameters.Add(p_id);
                connection.Open();
                //Choose Execution method
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) return Mapper.ToProtitype(reader);
                return null;
            }
        }
    }

        public IEnumerable<Prototype> Get()
        {
        using (SqlConnection connection = new SqlConnection(_connString))
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT [id], [lastName], [firstName],[profession], [dateBirthDate], [email], [login] FROM [Protitype]";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) yield return Mapper.ToProtitype(reader);
            }
        }
    }

        public int Insert(Prototype entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    //dans le cas où l'id n'est pas auto-incrémenté 
                    //VALUES((COALESCE((SELECT MAX(idClient) FROM [Client]),0)+1), 
                    cmd.CommandText = "INSERT INTO [Prototype]([id], [lastName], [firstName],[profession], [dateBirthDate], [email], [login], [psw], [Validate]) OUTPUT [inserted].[id] VALUES(@nom, @prenom, @company, @date, @email, @login, @psw, @valid)";
                    SqlParameter p_nom = new SqlParameter("nom", entity.lastName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.firstName);
                    SqlParameter p_company = new SqlParameter("company", entity.profession);
                    SqlParameter p_date = new SqlParameter("date", entity.dateBirthDate);
                    SqlParameter p_email = new SqlParameter("email", entity.email);

                    //sono nullabili per poter mantenere in memoria i dati anche se la società non é più cliente; immagina uno storico dei contratti

                    //SqlParameter p_login = new SqlParameter("login", entity.login);
                    SqlParameter p_login = new SqlParameter("login", (object)entity.login ?? DBNull.Value);

                    /*if (entity.login is null | entity.login == "")
                    {
                        SqlParameter p_login = new SqlParameter("psw", DBNull.Value);
                        cmd.Parameters.Add(p_login);
                    }
                    else
                    {
                        SqlParameter p_login = new SqlParameter("psw", entity.login);
                        cmd.Parameters.Add(p_login);

                    }*/

                    //SqlParameter p_psw = new SqlParameter("psw", entity.CliPassword);
                    SqlParameter p_psw = new SqlParameter("psw", (object)entity.psw ?? DBNull.Value);

                    /*if (entity.psw is null | entity.psw == "")
                    {
                        SqlParameter p_psw = new SqlParameter("psw", DBNull.Value);
                        cmd.Parameters.Add(p_psw);
                    }
                    else
                    {
                        SqlParameter p_psw = new SqlParameter("psw", entity.psw);
                        cmd.Parameters.Add(p_psw);

                    }*/
                    SqlParameter p_valid = new SqlParameter("valid", entity.Validate);


                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_company);
                    cmd.Parameters.Add(p_date);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_login);
                    cmd.Parameters.Add(p_psw);
                    cmd.Parameters.Add(p_valid);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Prototype entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Prototype] SET [lastName]=@nom, [firstName]= @prenom, [profession]= @company, [dateBirthDate]= @date, [email]= @email, [login]=@login, [psw]=@psw ,[Validate]= @valid) " +
                        "WHERE [id] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);

                    SqlParameter p_nom = new SqlParameter("nom", entity.lastName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.firstName);
                    SqlParameter p_company = new SqlParameter("company", entity.profession);
                    SqlParameter p_date = new SqlParameter("date", entity.dateBirthDate);
                    SqlParameter p_email = new SqlParameter("email", entity.email);
                    SqlParameter p_login = new SqlParameter("login", (object)entity.login ?? DBNull.Value);
                    SqlParameter p_psw = new SqlParameter("psw", (object)entity.psw ?? DBNull.Value);
                    SqlParameter p_valid = new SqlParameter("valid", entity.Validate);

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_company);
                    cmd.Parameters.Add(p_date);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_login);
                    cmd.Parameters.Add(p_psw);
                    cmd.Parameters.Add(p_valid);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
