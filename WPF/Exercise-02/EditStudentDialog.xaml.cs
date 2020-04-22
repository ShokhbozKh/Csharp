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
    /// Interaction logic for EditStudentDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        private Student student;
        public EditStudentDialog()
        {
            InitializeComponent();
        }
        public EditStudentDialog(Object st)
        {
            InitializeComponent();
            this.student = st as Student;
            FirstNameTextBox.Text = this.student.FirstName;
            LastNameTextBox.Text = this.student.LastName;
            IndexNumberTextBox.Text = this.student.IndexNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isNameValid(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please, insert valid name");
            }
            else if (!isNameValid(LastNameTextBox.Text))
            {
                MessageBox.Show("Please, insert valid last name");
            }
            else if (!isIndexValid(IndexNumberTextBox.Text))
            {
                MessageBox.Show("Please, insert valid index number");
            }
            else
            {
                this.student = new Student
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    IndexNumber = IndexNumberTextBox.Text
                };
                MessageBox.Show(student.ToString(), "Student edited");

                Close();
            }
        }

        private bool isNameValid(string name)
        {
            if (name.Any(char.IsDigit))
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
            if (!index.StartsWith("s") || index.Length > 6 || index.Length < 6 || index.Substring(1).Any(char.IsLetter))
            {
                return false;
            }
            else
            {
                return true;
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
            if (isNameValid(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                FirstNameTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
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

    }
}
