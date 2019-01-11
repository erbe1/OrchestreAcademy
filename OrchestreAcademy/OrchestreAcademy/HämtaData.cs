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
            var sql = "SELECT EventId, Datum, StadNamn FROM Event";
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
                list = list.OrderByDescending(x => x.Stycke).ToList();
                return list;
            }
        }

        internal List<Person> InstrumentOchNivåFörEnskildaMusiker(int musiker)
        {
            var sql = "SELECT Istrumentnamn, Nivå FROM Musikerinstrument WHERE MusikerId=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", musiker));

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


        internal List<Person> MusikerMedId()
        {
            var sql = "SELECT MusikerId, Förnamn, Efternamn FROM Person JOIN Musiker ON Musiker.PersonId=Person.PersonId";
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
            var sql = "SELECT MusikerId, Förnamn, Efternamn, TelefonNummer FROM Person JOIN Musiker ON Musiker.PersonId=Person.PersonId";

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
                        Id = reader.GetSqlInt32(0).Value,
                        Förnamn = reader.GetSqlString(1).Value,
                        Efternamn = reader.GetSqlString(2).Value,
                        Telefonnummer = reader.GetSqlInt32(3).Value
                    };

                    list.Add(person);
                }
                return list;
            }
        }

        internal List<Person> MusikerNamn(int musikerId)
        {
            var sql = "SELECT Förnamn, Efternamn FROM Person JOIN Musiker ON Musiker.PersonId=Person.PersonId WHERE MusikerId=@musikerId";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("musikerId", musikerId));
                SqlDataReader reader = command.ExecuteReader();

                var lista = new List<Person>();

                while (reader.Read())
                {
                    var person = new Person
                    {
                        Förnamn = reader.GetSqlString(0).Value,
                        Efternamn = reader.GetSqlString(1).Value,
                    };

                    lista.Add(person);
                }
                return lista;
            }
        }

        internal bool FinnsInstrument(string valavinstrument, int musiker)
        {
            var sql = "SELECT Istrumentnamn FROM MusikerInstrument WHERE MusikerId=@musikerId AND Istrumentnamn=@val";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("musikerId", musiker));
                command.Parameters.Add(new SqlParameter("val", valavinstrument));

                SqlDataReader reader = command.ExecuteReader();

                bool finninstrument = reader.Read();
                return finninstrument;
            }
        }

        internal void UppdateraNivå(int nivå, int musiker, string valavinstrument)
        {
            var sql = "UPDATE MusikerInstrument SET Nivå=@Nivå WHERE MusikerId=@MusikerId AND Istrumentnamn=@val";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Nivå", nivå));
                command.Parameters.Add(new SqlParameter("MusikerId", musiker));
                command.Parameters.Add(new SqlParameter("val", valavinstrument));
                command.ExecuteNonQuery();
            }
        }

        internal List<Person> Musikerinstrument(int musiker)
        {
            var sql = "SELECT Istrumentnamn FROM MusikerInstrument WHERE MusikerId=@musikerId";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("musikerId", musiker));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Person>();

                while (reader.Read())
                {
                    var person = new Person
                    {
                        InstrumentNamn = reader.GetSqlString(0).Value
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
internal string HämtaRubrikFörEttEvent(int nummer)
        {
            string s = "";
            
            var sql = "SELECT EventId, Datum, StadNamn FROM Event WHERE EventId=@EventId";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("EventId", nummer));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Event>();


                while (reader.Read())
                {
                    var e = new Event
                    {                        
                        Datum = reader.GetSqlDateTime(1).Value,
                        StadNamn = reader.GetSqlString(2).Value
                    };
                    list.Add(e);
                s = e.StadNamn + " " + e.Datum.ToString();
                }
            }
            return s;
        }
    }
}
