using Exercise_07.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Exercise_07
{
    /// <summary>
    /// Interaction logic for AddStudentDialog.xaml
    /// </summary>
    public partial class AddStudentDialog : Window
    {
        private readonly int Id;    // for generating a new student
        public AddStudentDialog(List<Study> studiesList, int newId)
        {
            InitializeComponent();
            LoadStudiesData(studiesList);
            this.Id = newId;
        }

        public AddStudentDialog(ref Student student, List<Study> studiesData)
        {
            InitializeComponent();
            LoadStudiesData(studiesData);
            this.Id = student.IdStudent;

            FirstNameTextBox.Text = student.FirstName;
            LastNameTextBox.Text = student.LastName;
            AddressTextBox.Text = student.Address;
            IndexNumberTextBox.Text = student.IndexNumber;
            StudiesListBox.SelectedItem = student.Study;

            AddButton.Content = "Edit";
        }

        public Student Student { get; set; }

        private void LoadStudiesData(List<Study> studiesData)
        {
            StudiesListBox.ItemsSource = studiesData;
        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsNameValid(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                LastNameTextBox.BorderBrush = SystemColors.ControlDarkBrush;
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
            }
            else
            {
                AddressTextBox.BorderBrush = SystemColors.ControlDarkBrush;
            }

        }

        private void StudiesListBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsStudyValid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidation())
            {
                Study study = (Study)StudiesListBox.SelectedItem;
                Student newStudent = new Student
                {
                    IdStudent = this.Id,
                    FirstName = char.ToUpper(FirstNameTextBox.Text[0]) + FirstNameTextBox.Text.Substring(1),
                    LastName = char.ToUpper(LastNameTextBox.Text[0]) + LastNameTextBox.Text.Substring(1),
                    Address = AddressTextBox.Text,
                    IndexNumber = IndexNumberTextBox.Text,
                    IdStudies = study.IdStudies,
                    Study = study
                };

                this.Student = newStudent;

                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Validate fields
        private bool CheckValidation()
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string index = IndexNumberTextBox.Text;
            string address = AddressTextBox.Text;

            if (!IsNameValid(firstName))
            {
                MessageBox.Show("No digits and symbols are allowed", "Please, insert valid first name");
                return false;
            }
            else if (!IsNameValid(lastName))
            {
                MessageBox.Show("No digits and symbols are allowed", "Please, insert valid last name");
                return false;
            }
            else if (!IsAddressValid(address))
            {
                MessageBox.Show("Please, insert valid address"); ;
                return false;
            }
            else if (!IsIndexValid(index))
            {
                MessageBox.Show("example: s12345", "Please, insert a valid index number");
                return false;
            }
            else if (!IsStudyValid())
            {
                MessageBox.Show("Please, select one study academic specialization");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Is name is for first and last names
        private bool IsNameValid(string name)
        {
            if (name.Any(char.IsDigit) || name.Any(char.IsSymbol) || name.Equals(null) || name.Equals(" ") || name.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // index should consist of small letter 's' and 5 digits
        private bool IsIndexValid(string index)
        {
            if (!index.StartsWith("s") || index.Length != 6 || index.Substring(1).Any(char.IsLetter))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsAddressValid(string address)
        {
            if (address.Equals(null) || address.Equals(""))
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
                StudiesListBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                StudiesListBox.BorderBrush = SystemColors.ControlDarkBrush;
                return true;
            }
        }
    }
}
