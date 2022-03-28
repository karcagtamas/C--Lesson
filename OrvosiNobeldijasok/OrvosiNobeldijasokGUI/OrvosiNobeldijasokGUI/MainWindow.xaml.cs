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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace OrvosiNobeldijasokGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (txtNév.Text == "" || txtÉv.Text == "" || txtOrszag.Text =="" || txtSZH.Text =="")
            {
                MessageBox.Show("Töltsön ki minden mezőt!");
                return;
            }
            if (int.Parse(txtÉv.Text) < 1989)
            {
                MessageBox.Show("HIBA! Az évszám nem megfelelő!");
                return;
            }
            try
            {
                StreamWriter sw = new StreamWriter("uj_dijazott.txt", false);              
                sw.WriteLine($"{txtÉv.Text};{txtNév.Text};{txtSZH.Text};{txtOrszag.Text}");               
                sw.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba az állomány írásánál!");
                throw;
            }
            txtNév.Text = "";
            txtÉv.Text = "";
            txtSZH.Text = "";
            txtOrszag.Text = "";
        }
    }
}
