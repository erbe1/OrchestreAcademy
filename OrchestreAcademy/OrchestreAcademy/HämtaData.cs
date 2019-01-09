using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
    }
}
