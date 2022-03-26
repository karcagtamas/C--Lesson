using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; } = new List<Student>();
        string fileUri = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Students", "src.txt");
        string folderUri = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Students");

        public MainWindow()
        {
            InitializeComponent();
            SrcRead();
            /*Students.Add(
                new Student
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Gandalf",
                    BirthYear = 1578,
                    Boy = true,
                    Color = Color.Blue
                });
            */

            dgStudents.CanUserAddRows = false;
            dgStudents.IsReadOnly = true;
            dgStudents.SelectionMode = DataGridSelectionMode.Single;
            dgStudents.SelectionChanged += SelectionChanged;
            dgStudents.ItemsSource = Students;
        }

        private void SrcRead() 
        {
            if (!File.Exists(fileUri))
            {
                Directory.CreateDirectory(folderUri); 
                File.AppendAllLines(fileUri, new List<string> { "Id;Name;BirthYear;Boy;Color" });
                return;
            }

            var sr = new StreamReader(fileUri);

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string[] row = sr.ReadLine().Split(';');

                Student student = new Student
                {
                    Id = row[0],
                    Name = row[1],
                    BirthYear = int.Parse(row[2]),
                    Boy = bool.Parse(row[3]),
                    Color = ColorConvert.FromString(row[4]),
                };

                Students.Add(student);
            }

            sr.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Add
            StudentAdd window = new StudentAdd();
            if (window.ShowDialog() ?? false)
            {
                var student = window.Get();
                
                // Table
                Students.Add(student);
                dgStudents.ItemsSource = null;
                dgStudents.ItemsSource = Students;

                // Save to file
                File.AppendAllLines(fileUri, new List<string> { $"{student.Id};{student.Name};{student.BirthYear};{student.Boy};{student.Color}" });
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete
            if (dgStudents.SelectedItem != null)
            {
                var student = (Student)dgStudents.SelectedItem;
                Students.Remove(student);
                dgStudents.ItemsSource = null;
                dgStudents.ItemsSource = Students;

                // Delete from file
                List<string> rows = new List<string>();
                StreamReader sr = new StreamReader(fileUri);
                while (!sr.EndOfStream)
                {
                    string l = sr.ReadLine();

                    if (rows.Count == 0 || l.Split(';')[0] != student.Id)
                    {
                        rows.Add(l);
                    }
                }
                sr.Close();

                File.WriteAllLines(fileUri, rows);

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var f = new FolderBrowserDialog();

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var folder = f.SelectedPath;


            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = dgStudents.SelectedItem != null;
        }
    }
}
