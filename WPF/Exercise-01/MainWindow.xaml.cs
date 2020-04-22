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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TreeViewItem students = new TreeViewItem { Header = "Students" };

            TreeViewItem employee = new TreeViewItem { Header = "Employee" };

            TreeViewItem fullTime = new TreeViewItem { Header = "Stationary" };
            TreeViewItem partTime = new TreeViewItem { Header = "Part time" };
            TreeViewItem online = new TreeViewItem { Header = "Online" };

            TreeViewItem teachers = new TreeViewItem { Header = "Teachers" };
            TreeViewItem administration = new TreeViewItem { Header = "Administration" };
            TreeViewItem security = new TreeViewItem { Header = "Security" };
            TreeViewItem technicians = new TreeViewItem { Header = "Technicians" };

            TreeViewItem fullTime_design = new TreeViewItem { Header = "3D Design" };
            TreeViewItem fullTime_management = new TreeViewItem { Header = "Management" };
            TreeViewItem fullTime_japaneseCultuer = new TreeViewItem { Header = "Japanese Culture" };
            TreeViewItem fullTime_computerScience = new TreeViewItem { Header = "Computer Science" };
            TreeViewItem partTime_design = new TreeViewItem { Header = "3D Design" };
            TreeViewItem partTime_management = new TreeViewItem { Header = "Management" };
            TreeViewItem partTime_japaneseCultuer = new TreeViewItem { Header = "Japanese Culture" };
            TreeViewItem partTime_computerScience = new TreeViewItem { Header = "Computer Science" };
            TreeViewItem online_design = new TreeViewItem { Header = "3D Design" };
            TreeViewItem online_management = new TreeViewItem { Header = "Management" };
            TreeViewItem online_japaneseCultuer = new TreeViewItem { Header = "Japanese Culture" };
            TreeViewItem online_computerScience = new TreeViewItem { Header = "Computer Science" };           

            fullTime.Items.Add(fullTime_design);
            fullTime.Items.Add(fullTime_management);
            fullTime.Items.Add(fullTime_japaneseCultuer);
            fullTime.Items.Add(fullTime_computerScience);

            partTime.Items.Add(partTime_design);
            partTime.Items.Add(partTime_management);
            partTime.Items.Add(partTime_japaneseCultuer);
            partTime.Items.Add(partTime_computerScience);

            online.Items.Add(online_design);
            online.Items.Add(online_management);
            online.Items.Add(online_japaneseCultuer);
            online.Items.Add(online_computerScience);

            students.Items.Add(fullTime);
            students.Items.Add(partTime);
            students.Items.Add(online);

            employee.Items.Add(teachers);
            employee.Items.Add(security);
            employee.Items.Add(technicians);
            employee.Items.Add(administration);

            PersonTypeTreeView.Items.Add(students);
            PersonTypeTreeView.Items.Add(employee);

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

            StudentsDataGrid.ItemsSource = list;
        }

        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
