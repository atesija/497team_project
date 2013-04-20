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

        // Strictly for setting focus
        public TextBox getUsernameBox()
        {
           return usernameBox;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text == "")
            {
               MessageBox.Show("Please enter a Username",
                  "Login Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               usernameBox.Focus();
               return;
            }

            if (passwordInput.Password == "")
            {
               MessageBox.Show("Please enter a Password",
                  "Login Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               passwordInput.Focus();
               return;
            }
            
            /*
             *call constructor for board manager passing in 
             *if doesn't exisit yet it will create a new file
             *not doing this is version 2
             */

            boardManager = new BoardManager(usernameBox.Text, passwordInput.Password);

            //transfer holder to next view
            Content = new BoardWindow(boardManager);
        }

        private void userInput_KeyDown_1(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Return)
           {
              login_Click(sender, e);
           }
        }
    }
}
