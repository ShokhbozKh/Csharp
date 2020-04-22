using DeansOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        public StudentView()
        {
            
        }
       
        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

/*
var student = new Student
{
    IdStudent = 1,
    FirstName = "John",
    LastName = "Done",
    StudentNumber = "s12341",
    Status = "Student",
    Year = 2019,
    Semester = "2019/2020 summer",
    Specialization = "Databases",
    Information = "Blank"
};
var student1 = new Student
{
    IdStudent = 2,
    FirstName = "John",
    LastName = "Jones",
    StudentNumber = "s12342",
    Status = "Student",
    Year = 2019,
    Semester = "2019/2020 summer",
    Specialization = "Databases",
    Information = "Blank"
};
var student2 = new Student
{
    IdStudent = 3,
    FirstName = "Daniel",
    LastName = "Kormie",
    StudentNumber = "s12343",
    Status = "Student",
    Year = 2019,
    Semester = "2019/2020 summer",
    Specialization = "Game development",
    Information = "Blank"
};
var student3 = new Student
{
    IdStudent = 4,
    FirstName = "Michael",
    LastName = "Bisping",
    StudentNumber = "s12344",
    Status = "Student",
    Year = 2019,
    Semester = "2019/2020 summer",
    Specialization = "Bussiness application",
    Information = "Blank"
};
var student4 = new Student
{
    IdStudent = 4,
    FirstName = "James",
    LastName = "Bond",
    StudentNumber = "s12345",
    Status = "Student",
    Year = 2019,
    Semester = "2019/2020 summer",
    Specialization = "Network programming",
    Information = "Blank"
};

var list = new List<Student>();
list.Add(student);
            list.Add(student1);
            list.Add(student2);
            list.Add(student3);
            list.Add(student4);
*/