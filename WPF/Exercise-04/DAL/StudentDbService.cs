using Exercise_05.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.DAL
{
    class StudentDbService
    {
        private static string connectionString = "Data Source=db-mssql;Initial Catalog=s16333;Integrated Security=True";
        private static ObservableCollection<Student> studentsList = new ObservableCollection<Student>();
        private static ObservableCollection<Studies> studiesList = new ObservableCollection<Studies>();

        public static ObservableCollection<Student> GetStudents()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT idstudent, firstname, lastname, address, indexnumber, apbd.Studies.IdStudies, apbd.Studies.Name FROM apbd.student, apbd.Studies where apbd.student.idstudies=apbd.studies.idstudies", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new Student
                            {
                                IdStudent = (int)reader["IdStudent"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                IndexNumber = reader["IndexNumber"].ToString(),
                                StudyName = reader["Name"].ToString(),
                                IdStudies = (int)reader["IdStudies"]
                            });
                        }
                    }

                    con.Close();
                }

                return studentsList;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void removeStudent(Student student)
        {
            studentsList.Remove(student);
        }

        public static void RemoveStudentFromDb(Student student)
        {
            Console.WriteLine(student.IdStudent);
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM apbd.Student WHERE IdStudent={student.IdStudent}", con))
                    {
                        cmd.Parameters.AddWithValue("@IdStudent", student.IdStudent);
                        int affectedRows = cmd.ExecuteNonQuery();
                    };
                    con.Close();
                };
                studentsList.Remove(student);
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AddStudent(Student student)
        {
                studentsList.Add(student);
        }

        

        private static void AddStudentToDb(Student student)
        {
            // TODO
        }

        public static void EditStudent(Student student, Student studentToEdit)
        {
            int index = studentsList.IndexOf(studentToEdit);
            studentsList[index] = student;
            //EditStudentDb(student, studentToEdit);
        }

        private static void EditStudentDb(Student student)
        {
            // TODO
        }

        private static void LoadStudiesDataFromDb()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT IdStudies, Name FROM apbd.Studies", con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studiesList.Add(new Studies
                            {
                                IdStudies = (int) reader["IdStudies"],
                                StudyName = reader["Name"].ToString()
                            });
                        }
                    }

                    con.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static ObservableCollection<Studies> GetStudiesList()
        {
            studiesList.Clear();
            LoadStudiesDataFromDb();
            return studiesList;
        }
    }
}
