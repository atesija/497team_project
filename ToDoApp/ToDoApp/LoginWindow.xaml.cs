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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private BoardManager boardManager;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            /*
             *call constructor for board manager passing in 
             *if doesn't exisit yet it will create a new file
             *not doing this is version 2
             */
            boardManager = new BoardManager(userInput.Text, passwordInput.GetValue().ToString());

            //transfer holder to next view
            Content = new BoardWindow(boardManager);

        }
    }
}
