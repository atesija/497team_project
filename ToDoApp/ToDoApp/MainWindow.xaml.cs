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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardManager boardManager;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            boardManager = null;
            // This was the only way I could get the focus to work
            LoginWindow loginWindow = new LoginWindow();
            WindowHolder.Content = loginWindow;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            boardManager.SaveToFile();
        }

        public void updateBoardManager(BoardManager boardManager_)
        {
            boardManager = boardManager_;
        }
    }
}
