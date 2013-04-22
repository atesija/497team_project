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
using System.Windows.Shapes;
using System.IO;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for LoginFileDialog.xaml
    /// </summary>
    public partial class LoginFileDialog : Window
    {
        BoardManager boardManager;
        MainWindow mainWindow;

        public LoginFileDialog(MainWindow mainWindow_, BoardManager boardManager_)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            boardManager = boardManager_;
            mainWindow = mainWindow_;
            titleTextBox.Focus();
            titleTextBox.SelectAll();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (titleTextBox.Text != "")
            {
                String newName = titleTextBox.Text;
                string path = Directory.GetCurrentDirectory();
                String filename = path + "\\" + newName + ".board";
                if (!File.Exists(filename))
                {
                    boardManager = new BoardManager(newName, false);
                    this.Close();
                    mainWindow.Content = new BoardWindow(boardManager);
                    mainWindow.updateBoardManager(boardManager);
                }
                else
                {
                    titleTextBox.Clear();
                    MessageBox.Show("Profile name already exists.",
                    "New File", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {

                MessageBox.Show("Please enter a name.",
                "New File", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void titleTextBox_KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                confirm_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                cancel_Click(sender, e);
            }
        }
    }
}
