using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private BoardManager boardManager;

        public LoginWindow()
        {
            InitializeComponent();

            //populate currentFiles
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] TXTFiles = di.GetFiles("*.board");
            if (TXTFiles.Length == 0)
            {
                //log.Info("no files present");
                //create default option?
            }
            foreach (var fi in TXTFiles)
            {
                String name = System.IO.Path.GetFileNameWithoutExtension(fi.Name);
                currentFiles.Items.Add(name);
                currentFiles.SelectedIndex = 0;
            }

        }

        private void loadFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newFile_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
