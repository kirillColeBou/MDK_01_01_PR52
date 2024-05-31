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
    public class StudentContext : Student
    {
        public StudentContext(int Id, string Firstname, string Lastname, int IdGroup, bool Expelled, DateTime DateExpelled) : base(Id, Firstname, Lastname, IdGroup, Expelled, DateExpelled) { }

        public static List<StudentContext> AllStudents()
        {
            List<StudentContext> allStudents = new List<StudentContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Student = Connection.Query("Select * From Student Order By `LastName`;", connection);
            while (Student.Read())
            {
                allStudents.Add(new StudentContext(
                    Student.GetInt32(0),
                    Student.GetString(1),
                    Student.GetString(2),
                    Student.GetInt32(3),
                    Student.GetBoolean(4),
                    Student.IsDBNull(5) ? DateTime.Now : Student.GetDateTime(5)));
            }
            Connection.CloseConnection(connection);
            return allStudents;
        }
    }
}
