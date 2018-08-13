using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            fileDialog.DefaultExt = ".dat"; // Required file extension 
            fileDialog.Filter = "DAT file (.dat)|*.dat"; // Optional file extensions

            if (fileDialog.ShowDialog() == true)
            {
                String filePath = fileDialog.FileName;
                String dataValue = null;
                int counter = 0;

                path1.Text = filePath;

                StreamReader objInput = new StreamReader(filePath, System.Text.Encoding.Default);
                string contents = objInput.ReadToEnd().Trim();
                string[] split = System.Text.RegularExpressions.Regex.Split(contents, "\\s+", RegexOptions.None);
                foreach (string s in split)
                {
                    counter++;
                    if(counter == 4)
                    {
                        dataValue = dataValue + s + "\n";
                        Console.WriteLine(s);
                    }else if (counter == 24)
                    {
                        counter = 0;
                    }
                    else
                    {
                        //default 
                    }
                    
                }

                box1.Text = dataValue;



            }
        }

        private void box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false;
        }
    }
}
