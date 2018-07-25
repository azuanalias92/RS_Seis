using Microsoft.Win32;
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

namespace RS_Seis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            // do something
            OpenDialog();
        }

        private void OpenDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt"; // Required file extension 
            fileDialog.Filter = "Text documents (.txt)|*.txt"; // Optional file extensions

            fileDialog.ShowDialog();


            /*if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(fileDialog.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }*/
        }
    }
}
