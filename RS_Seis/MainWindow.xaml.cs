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
        //StreamReader objInput = null;
        string contents;

        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.MainWindow.WindowState = WindowState.Maximized;
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
                
                int i = 0, countRow = 0;

                path1.Text = filePath;

                StreamReader objInput = new StreamReader(filePath, System.Text.Encoding.Default);
                contents = objInput.ReadToEnd().Trim();
                string[] split = System.Text.RegularExpressions.Regex.Split(contents, "\\r+", RegexOptions.None);
                foreach (string s in split)
                {
                    
                    //if (i == 4)
                    //{
                    //    dataValue = dataValue + s + "\n";
                    //    Console.WriteLine(s);
                    //}
                    //else if (i == 24)
                    //{
                    //    i = 0;
                    //}
                    //else
                    //{
                    //    //default 
                    //}

                    if ( i < 1)
                    {
                        string[] space = System.Text.RegularExpressions.Regex.Split(s, "\\s+", RegexOptions.None);
                        foreach (string p in space)
                        {
                            countRow++;
                            combo1.Items.Add(countRow);
                            combo1.SelectedIndex = 0;
                        }
                    }

                    i++;
                }

                
            }
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = combo1.SelectedIndex;
            Console.WriteLine(selectedIndex);
            int i = 0;
            String dataValue = null;
            string[] split = System.Text.RegularExpressions.Regex.Split(contents, "\\s+", RegexOptions.None);
            foreach (string s in split)
            {
                if (i == selectedIndex)
                {
                    dataValue = dataValue + s + "\n";
                    Console.WriteLine(s);
                }
                else if (i == 24)
                {
                    i = 0;
                }
                else
                {
                    //default 
                }
                i++;
               
            }

            box1.Text = dataValue;
        }
    }
}
