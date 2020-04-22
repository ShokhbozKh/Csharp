using Exercise_04.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace Exercise_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public MainWindow()
        {
            InitializeComponent();
            loadDataWithDatabase();
            //loadDataWithItemsSource();
            //loadDataWithItemsCollection();

        }

        private void ShowSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(StudentsListBox.SelectedItem.ToString());
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            students.Add(new Student
            {
                Id = "2",
                FirstName = "Jim",
                LastName = "Jimson"
            });
            
        }

        private void loadDataWithItemsCollection()
        {
            StudentsListBox.Items.Add(new ListBoxItem
            {
                Content = "Student2"
            });

            StudentsListBox.Items.Add(new Student
            {
                FirstName = "First",
                LastName = "Last",
                Id = "5"
            });
        }

        private void loadDataWithItemsSource()
        {
            students.Add(new Student
            {
                Id = "1",
                FirstName = "John",
                LastName = "Johnson",
                Gender = true
            });

            StudentsListBox.ItemsSource = students;
            StudentsDataGrid.ItemsSource = students;
        }
        private void loadDataWithDatabase()
        {
            string connectionString = "Data Source=db-mssql;Initial Catalog=s16333;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM EMP", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader["empno"].ToString(),
                            FirstName = reader["ename"].ToString()
                        });
                    }
                }
            }

            StudentsListBox.ItemsSource = students;
            StudentsDataGrid.ItemsSource = students;

        }
    }
}
