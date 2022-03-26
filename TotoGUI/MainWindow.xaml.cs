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

namespace TotoGUI
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

        private void txtResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            var res = txtResult.Text;

            cbInvalidL.IsChecked = res.Length != 14;
            cbInvalidL.Content = $"Nem megfeleo a karakter szam ({res.Length})";

            List<char> invalid = new();
            List<char> valid = new()
            {
                '1', '2', 'X'
            };

            for (int i = 0; i < res.Length; i++)
            {
                if (!valid.Contains(res[i]))
                {
                    invalid.Add(res[i]);
                }
            }

            cbInvalidC.IsChecked = invalid.Count > 0;
            cbInvalidC.Content = $"Helytelen karakter az eredmenyekben ({string.Join(';', invalid)})";

            btnSave.IsEnabled = !(cbInvalidL.IsChecked ?? false) && !(cbInvalidC.IsChecked ?? false);
        }
    }
}
