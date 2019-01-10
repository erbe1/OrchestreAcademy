using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using OrchestreAcademy.Domän;

namespace OrchestreAcademy
{
    public class HämtaData
    {
        private string conString = "Server=(localdb)\\mssqllocaldb; Database=OrchesterAcademy";

        internal List<string> VisaInstrument()
        {
            var sql = "SELECT InstrumentNamn FROM Instrument";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader.GetSqlString(0).Value);
                }
                return list;
            }
        }

        internal List<Person> VisaMusiker()
        {
            var sql = "SELECT Förnamn, Efternamn FROM Person JOIN Musiker ON Musiker.PersonId=Person.PersonId";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Person>();


                while (reader.Read())
                {
                    var person = new Person
                    {
                        Förnamn = reader.GetSqlString(0).Value,
                        Efternamn = reader.GetSqlString(1).Value
                    };

                    list.Add(person);
                }
                return list;
            }
        }

        internal List<string> SeEnskildMusiker()
        {
            throw new NotImplementedException();
        }

        internal List<string> SeTillgängligaInstrument()
        {
            var sql = "SELECT InstrumentNamn FROM Instrument";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader.GetSqlString(0).Value);
                }
                return list;
            }
        }
    }
}