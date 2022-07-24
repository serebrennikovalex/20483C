using System;
using System.Windows;

namespace School
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        #region Predefined code

        public StudentForm()
        {
            InitializeComponent();
        }

        #endregion

        // If the user clicks OK to save the Student details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Exercise 2: Task 2a: Check that the user has provided a first name
            // TODO: Exercise 2: Task 2b: Check that the user has provided a last name
            // TODO: Exercise 2: Task 3a: Check that the user has entered a valid date for the date of birth
            // TODO: Exercise 2: Task 3b: Verify that the student is at least 5 years old
            if (String.IsNullOrEmpty(this.firstName.Text))
            {
                this.ShowErrorMessage("The student must have a first name");
                return;
            }

            if (String.IsNullOrEmpty(this.lastName.Text))
            {
                this.ShowErrorMessage("The student must have a last name");
                return;
            }

            DateTime correctDate;
            if (DateTime.TryParse(this.dateOfBirth.Text, out correctDate))
            {
                TimeSpan difference = DateTime.Now.Subtract(correctDate);
                int ageInYears = (int)(difference.Days / 365.25);

                if (ageInYears < 5)
                {
                    this.ShowErrorMessage("The student must at least 5 years old");
                    return;
                }
            }
            else
            {
                this.ShowErrorMessage("The date of birth must be a valid date");
                return;
            }

            // Indicate that the data is valid
            this.DialogResult = true;
        }

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show(String.Format(error), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
