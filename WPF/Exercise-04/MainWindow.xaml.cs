using Exercise_05.DAL;
using Exercise_05.Models;
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

namespace Exercise_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> studentsList = new ObservableCollection<Student>();
        private List<Student> studentsToRemove = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
            LoadDataWithDB();
        }

        private void LoadDataWithDB()
        {
            studentsList = StudentDbService.GetStudents();
            StudentsDataGrid.ItemsSource = studentsList;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a student to delete", "Student not selected!");
            }else
            {
                if(StudentsDataGrid.SelectedItems.Count == 1)
                {
                    if (MessageBox.Show(StudentsDataGrid.SelectedItem.ToString(), "Are you sure you want to delete student?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        //StudentDbService.removeStudent((Student)StudentsDataGrid.SelectedItem);
                        //MessageBox.Show(((Student)(StudentsDataGrid.SelectedItem)).IdStudent.ToString());
                        StudentDbService.RemoveStudentFromDb((Student)StudentsDataGrid.SelectedItem);
                        MessageBox.Show("Student was successfully deleted!");
                    }
                    else
                    {
                        return;
                    }
                }else
                {
                    if(MessageBox.Show("Are you sure you want to delete?", $"{StudentsDataGrid.SelectedItems.Count} students are to be deleted", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        //MessageBox.Show($"{StudentsDataGrid.SelectedItems.Count}");
                        for (int i = 0; i < StudentsDataGrid.SelectedItems.Count; i++)
                        {
                            //MessageBox.Show($"{i}");
                            //MessageBox.Show(StudentsDataGrid.SelectedItems[i].ToString());
                            studentsToRemove.Add((Student) StudentsDataGrid.SelectedItems[i]);
                            //StudentDbService.RemoveStudentFromDb((Student) StudentsDataGrid.SelectedItems[i]);
                        }

                        foreach(Student st in studentsToRemove)
                        {
                            //StudentDbService.RemoveStudentFromDb(st);
                            StudentDbService.removeStudent(st);
                        }

                        studentsToRemove.Clear();

                        MessageBox.Show("Students were successfully deleted!");
                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddStudentDialog().Show();
        }

        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItems.Count != -1)
            {
                ChosenStudents.Content = $"You chose {StudentsDataGrid.SelectedItems.Count} students";
            } else
            {
                ChosenStudents.Content = $"You chose {StudentsDataGrid.SelectedItems.Count + 1} students";
            }
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new AddStudentDialog((Student)StudentsDataGrid.SelectedItem).Show();
        }
    }
}
