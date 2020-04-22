using Exercise_07.DAL;
using Exercise_07.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Exercise_07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            StudentsDataGrid.ItemsSource = StudentDbService.GetStudents();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // track on selection number of students on datagrid
        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int studentsSelected = StudentsDataGrid.SelectedItems.Count;

            if(studentsSelected > 1)
            {
                ChosenStudents.Content = $"You chose {studentsSelected} students";
            } else if(studentsSelected == 1)
            {
                ChosenStudents.Content = $"You chose 1 student";
            }
            
        }

        // Show add student dialog with update option on double click
        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student studentToUpdate = (Student) StudentsDataGrid.SelectedItem;
            var updateDialog = new AddStudentDialog(ref studentToUpdate, StudentDbService.GetStudies());

            if (updateDialog.ShowDialog() == false)
            {
                Student student = updateDialog.Student;
                //int g = 0;
                if(student != null)
                {
                    StudentDbService.UpdateStudent(student);
                    MessageBox.Show("Student was successfully edited!");
                }
            }
        }

        // Add button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Add generate Id because students are searched through list, so when they added to list directly and not
             * retrieved from db, they don't have id, and you won't be able to find them and update instantly after adding
             */
            var addDialog = new AddStudentDialog(StudentDbService.GetStudies(), StudentDbService.GenerateId());

            if(addDialog.ShowDialog() == false)
            {
                if(addDialog.Student != null)
                {
                    StudentDbService.AddStudent(addDialog.Student);
                    MessageBox.Show("Student was successfully added");
                }
            }
        }

        // Delete button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedStudents = StudentsDataGrid.SelectedItems.Count;
            if(selectedStudents > 1)
            {
                if((MessageBox.Show($"Are you sure you want to delete {selectedStudents} students? ", $"{selectedStudents} students are to be deleted", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    // list is needed because cannot pass selected item of datagrid to the method remove directly as an obj
                    List<Student> studentsToRemove = new List<Student>();
                   
                    for (int i = 0; i < StudentsDataGrid.SelectedItems.Count; i++)
                    {
                        // add each selected student to the list
                        studentsToRemove.Add((Student)StudentsDataGrid.SelectedItems[i]);
                        // StudentDbService.RemoveStudentFromDb((Student) StudentsDataGrid.SelectedItems[i]); --> doesnt work
                    }

                    foreach (Student st in studentsToRemove)
                    {
                        // pass each student to remove method
                        StudentDbService.RemoveStudent(st);
                    }

                    MessageBox.Show("Students were successfully deleted!");
                }
            }
            else if(selectedStudents == 1)
            {
                if ((MessageBox.Show("Are you sure you want to delete ?", $" {StudentsDataGrid.SelectedItem.ToString()} to be deleted", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    StudentDbService.RemoveStudent((Student)StudentsDataGrid.SelectedItem);
                }
                MessageBox.Show("Student was successfully deleted");
            } else if(selectedStudents == 0)
            {
                MessageBox.Show("Please, select at least one student!");
            }
            
        }
    }
}

/*
 * Student studentToUpdate = (Student)StudentsDataGrid.SelectedItem;
            var updateDialog = new AddStudentDialog(studentToUpdate, StudentDbService.GetStudies());
            
            if(updateDialog.ShowDialog() == false)
            {
                Student student = updateDialog.Student;
                //int g = 0;
                StudentDbService.UpdateStudent(studentToUpdate, student);
            }
*/
