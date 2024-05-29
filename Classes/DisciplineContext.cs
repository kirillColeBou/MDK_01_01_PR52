using MySql.Data.MySqlClient;
using ReportGeneration_Тепляков.Classes.Common;
using ReportGeneration_Тепляков.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Тепляков.Classes
{
    public class DisciplineContext : Discipline
    {
        public DisciplineContext(int Id, string Name, int IdGroup) : base(Id, Name, IdGroup) { }

        public static List<DisciplineContext> AllDisciplines()
        {
            List<DisciplineContext> allDisciplines = new List<DisciplineContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Disciplines = Connection.Query("Select * From `discipline` Order By `Name`;", connection);
            while (Disciplines.Read())
            {
                allDisciplines.Add(new DisciplineContext(
                    Disciplines.GetInt32(0),
                    Disciplines.GetString(1),
                    Disciplines.GetInt32(2)));
            }
            Connection.CloseConnection(connection);
            return allDisciplines;
        }
    }
}
