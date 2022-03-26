using System;
using System.Collections.Generic;
using System.Windows;

namespace students
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        private Student student;

        public StudentAdd()
        {
            InitializeComponent();
            cbxColor.ItemsSource = new List<string> { Color.Blue.ToString(), Color.Green.ToString(), Color.Red.ToString() };
        }

        public Student Get()
        {
            return student;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Adjon meg nevet");
                return;
            }

            if (string.IsNullOrEmpty(txtYear.Text) || !int.TryParse(txtYear.Text, out int _))
            {
                MessageBox.Show("Adjon meg egy megfelelo evet");
                return;
            }

            if (cbxColor.SelectedIndex == -1)
            {
                MessageBox.Show("Valasszon egy szint");
                return;
            }

            student = new Student
            {
                Id = Guid.NewGuid().ToString(),
                Name = txtName.Text,
                BirthYear = int.Parse(txtYear.Text),
                Boy = cbBoy.IsChecked ?? false, // cbBoy.IsChecked == null ? false : cbBoy.IsChecked
                Color = ColorConvert.FromString((string)cbxColor.SelectedItem)
            };
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
