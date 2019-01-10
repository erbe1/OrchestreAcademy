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

        internal List<Event> VisaAllaEvent()
        {
            var sql = "SELECT EventId Datum, StadNamn FROM Event";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Event>();


                while (reader.Read())
                {
                    var e = new Event
                    {

                        EventId = reader.GetSqlInt32(0).Value,
                        Datum = reader.GetSqlDateTime(1).Value,
                        StadNamn = reader.GetSqlString(2).Value
                    };
                    list.Add(e);
                }
                return list;
            }

        }

        internal List<Event> VisaAlltIEttEvent(int eventet)
        {
            var sql = "SELECT Bokningar.StyckeNamn, Person.Förnamn, Person.Efternamn, InstrumentNamn FROM Bokningar JOIN Musiker ON Bokningar.MusikerId=Musiker.MusikerId JOIN Person ON Musiker.PersonId=Person.PersonId WHERE Bokningar.EventId = 1";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("EventId", eventet));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Event>();


                while (reader.Read())
                {
                    var e = new Event
                    {

                        EventId = eventet,
                        Stycke = reader.GetSqlString(0).Value,
                        Namn = reader.GetSqlString(1).Value + " " + reader.GetSqlString(2).Value,
                        Instrumet = reader.GetSqlString(3).Value

                    };
                    list.Add(e);
                }
                return list;
            }
        }

        internal List<Person> InstrumentOchNivåFörEnskildaMusiker()
        {
            throw new NotImplementedException();
        }

        internal List<Person> MusikerMedId()
        {
            var sql = "SELECT PersonId, Förnamn, Efternamn FROM Person";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var lista = new List<Person>();

                while (reader.Read())
                {
                    var person = new Person
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Förnamn = reader.GetSqlString(1).Value,
                        Efternamn = reader.GetSqlString(2).Value
                    };
                    lista.Add(person);
                }
                return lista;
            }
        }

        internal List<Person> VisaMusiker()
        {
            var sql = "SELECT Förnamn, Efternamn, TelefonNummer FROM Person JOIN Musiker ON Musiker.PersonId=Person.PersonId";

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
                        Efternamn = reader.GetSqlString(1).Value,
                        Telefonnummer = reader.GetSqlInt32(2).Value
                    };

                    list.Add(person);
                }
                return list;
            }
        }

        internal List<Person> SeEnskildMusiker()
        {
            var sql = "SELECT Bokningar.StyckeNamn, Person.Förnamn, Person.Efternamn, InstrumentNamn FROM Bokningar JOIN Musiker ON Bokningar.MusikerId=Musiker.MusikerId JOIN Person ON Musiker.PersonId=Person.PersonId WHERE Bokningar.EventId = 1";
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
                        InstrumentNamn = reader.GetSqlString(0).Value,
                        Nivå = reader.GetSqlInt32(1).Value
                    };

                    list.Add(person);
                }

                return list;
            }
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
