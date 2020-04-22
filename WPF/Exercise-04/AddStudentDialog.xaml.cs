using Exercise_05.DAL;
using Exercise_05.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Exercise_05
{
    /// <summary>
    /// Interaction logic for AddStudentDialog.xaml
    /// </summary>
    public partial class AddStudentDialog : Window
    {
        private ObservableCollection<Studies> studiesList;
        private Student student = null;
        public AddStudentDialog()
        {
            InitializeComponent();
            LoadStudiesDataFromDb();
        }

        public AddStudentDialog(Object student)
        {
            InitializeComponent();
            LoadStudiesDataFromDb();
            this.student = (Student)student;
            LoadStudentData();
            AddButton.Content = "Edit";
        }

        private void LoadStudentData()
        {
            FirstNameTextBox.Text = this.student.FirstName;
            LastNameTextBox.Text = this.student.LastName;
            AddressTextBox.Text = this.student.Address;
            IndexNumberTextBox.Text = this.student.IndexNumber;

            Studies study = GetStudyElement();

            // set selected item
            StudiesListBox.SelectedItem = study;
        }

        // Get study element according to IdStudy of passed student
        private Studies GetStudyElement()
        {
            foreach(Studies studies in studiesList)
            {
                if(studies.IdStudies == this.student.IdStudies)
                {
                    return studies;
                }
            }
            return null;
        }

        private void LoadStudiesDataFromDb()
        {
            studiesList = StudentDbService.GetStudiesList();
            StudiesListBox.ItemsSource = studiesList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidation())
            {
                Studies studies = (Studies)(StudiesListBox.SelectedItem);
                Student student = new Student
                {
                    FirstName = char.ToUpper(FirstNameTextBox.Text[0]) + FirstNameTextBox.Text.Substring(1),
                    LastName = char.ToUpper(LastNameTextBox.Text[0]) + LastNameTextBox.Text.Substring(1),
                    IndexNumber = char.ToLower(IndexNumberTextBox.Text[0]) + IndexNumberTextBox.Text.Substring(1),
                    Address = AddressTextBox.Text,
                    IdStudies = studies.IdStudies,
                    StudyName = studies.StudyName
                };

                if (AddButton.Content.Equals("Add"))
                {
                    StudentDbService.AddStudent(student);
                    MessageBox.Show("Student added successfully!");
                }
                else if (AddButton.Content.Equals("Edit"))
                {
                    StudentDbService.EditStudent(student, this.student);
                    MessageBox.Show("Student was successfully updated!");
                }
                
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool CheckValidation()
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string index = IndexNumberTextBox.Text;
            string address = AddressTextBox.Text;

            if (!IsNameValid(firstName))
            {
                MessageBox.Show("Please, insert valid first name");
                return false;
            }else if (!IsNameValid(lastName))
            {
                MessageBox.Show("Please, insert valid last name");
                return false;
            } else if (!IsAddressValid(address))
            {
                MessageBox.Show("Please, insert valid address"); ;
                return false;
            } else if (!IsIndexValid(index))
            {
                MessageBox.Show("Please, insert a valid index number");
                return false;
            } else if (!IsStudyValid())
            {
                MessageBox.Show("Please, select one study academic specialization");
                return false;
            } else
            {
                return true;
            }
        }

        private bool IsNameValid(string name)
        {
            if (name.Any(char.IsDigit) || name.Any(char.IsSymbol) || name.Equals(null) || name.Equals(" "))
            {
                return false;
            } else
            {
                return true;
            }
        }

        private bool IsIndexValid(string index)
        {
            if (!index.StartsWith("s") || index.Length != 6 || index.Substring(1).Any(char.IsLetter))
            {
                return false;
            } else
            {
                return true;
            }
        }

        private bool IsAddressValid(string address)
        {
            if(address.Equals(null) || address.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsStudyValid()
        {
            if (StudiesListBox.SelectedItems.Count != 1)
            {
                return false;
            }else
            {
                return true;
            }
        }


        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsNameValid(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                FirstNameTextBox.BorderBrush = SystemColors.ControlDarkBrush;
            }
        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsNameValid(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            } else
            {
                LastNameTextBox.BorderBrush = SystemColors.ControlDarkBrush;
            }
        }

        private void IndexNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsIndexValid(IndexNumberTextBox.Text))
            {
                IndexNumberTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                IndexNumberTextBox.BorderBrush = SystemColors.ControlDarkBrush;
            }
        }

        private void AddressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsAddressValid(AddressTextBox.Text))
            {
                AddressTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            } else
            {
                AddressTextBox.BorderBrush = SystemColors.ControlDarkBrush;
            }
        }

        private void StudiesListBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsStudyValid())
            {
                StudiesListBox.BorderBrush = new SolidColorBrush(Colors.Red);
            } else
            {
                StudiesListBox.BorderBrush = SystemColors.ControlDarkBrush;
            }
        }
    }
}
