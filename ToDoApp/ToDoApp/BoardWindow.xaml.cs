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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class BoardWindow : UserControl
    {
        private BoardManager boardManager;

        public BoardWindow(BoardManager boardManager_)
        {
            boardManager = boardManager_;

            InitializeComponent();
            listbox.Items.Add("Groceries");//REMOVE 
            listbox.Items.Add("Todo");//REMOVE
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            listbox.Items.Add("Another List");//REMOVE 
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            //pass in currently selected board
            //passes the correct board from the board manager
            Content = new ListWindow(boardManager, listbox.SelectedIndex);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           // Check that an Item is selected
           if (listbox.SelectedItem == null)
           {
              MessageBox.Show("Please select a Board to delete", "Delete Board", MessageBoxButton.OK, MessageBoxImage.Error);
              return;
           }

           // Ask user to confirm
           String messageBoxText = "Are you sure you would like to delete this board and its content?";
           String caption = "Delete Board";
           MessageBoxButton button = MessageBoxButton.YesNo;
           MessageBoxImage icon = MessageBoxImage.Warning;

           MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

           if (result == MessageBoxResult.No)
              return;

           // Remove all data corresponding to Item


           // Remove Item from the list
           listbox.Items.Remove(listbox.SelectedItem);
           listbox.UnselectAll();
        }
    }
}
