using Exercise03.Models;
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

namespace Exercise03
{
    /// <summary>
    /// Interaction logic for Task3i4.xaml
    /// </summary>
    public partial class Task3i4 : Window
    {
        //private Student student;
        public Task3i4()
        {
            InitializeComponent();
            loadStudents();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isNameValid(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please, do not use numbers for name");
            }
            else if (!isNameValid(LastNameTextBox.Text))
            {
                MessageBox.Show("Please, do not use numbers for last name");
            }
            else if (!isIndexValid(IndexNumberTextBox.Text))
            {
                MessageBox.Show("Please, insert valid index number");
            }
            else
            {
                Student student = new Student
                {
                    FirstName = Char.ToUpper(FirstNameTextBox.Text[0]) + FirstNameTextBox.Text.Substring(1),
                    LastName = Char.ToUpper(LastNameTextBox.Text[0]) + LastNameTextBox.Text.Substring(1),
                    IndexNumber = IndexNumberTextBox.Text
                };
                
                StudentsDataGrid.Items.Add(student);
                
                MessageBox.Show(student.ToString(), "Student added!");
                
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                IndexNumberTextBox.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show(StudentsDataGrid.SelectedItem.ToString(), "Are you sure you want to delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show(StudentsDataGrid.SelectedItem.ToString(), "Student deleted!");
                StudentsDataGrid.Items.Remove(StudentsDataGrid.SelectedItem);
            }
        }

        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (isNameValid(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                FirstNameTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }

        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (isNameValid(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                LastNameTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }

        }

        private void IndexNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (isIndexValid(IndexNumberTextBox.Text))
            {
                IndexNumberTextBox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                IndexNumberTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        private bool isNameValid(string name)
        {
            if (name.Any(char.IsDigit) || name.Equals(null) || name.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }

            /* TODO validate uppercase
          if(Char.IsUpper(Convert.ToChar(FirstNameTextBox.Text[0])))
          {
              return;
          } else
          {
              string firstNameText = FirstNameTextBox.Text;
              FirstNameTextBox.Text = firstNameText.ToUpper() + firstNameText.Substring(1);
          }   */
        }

        private bool isIndexValid(string index)
        {
            string indexText = IndexNumberTextBox.Text;
            if (!indexText.StartsWith("s") || indexText.Length > 6 || indexText.Length < 6 || indexText.Substring(1).Any(char.IsLetter))
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        private void loadStudents()
        {
            Student student = new Student
            {
                FirstName = "Robert",
                LastName = "Robertson",
                IndexNumber = "s12342"
            };
            Student student1 = new Student
            {
                FirstName = "John",
                LastName = "Done",
                IndexNumber = "s12341"
            };
            StudentsDataGrid.Items.Add(student);
            StudentsDataGrid.Items.Add(student1);
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new EditStudentDialog((sender as DataGrid).SelectedItem).Show();
        }
    }
}
