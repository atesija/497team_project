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
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Create dialog box that returns a string or board
            Board board = new Board("ToDo");

            //Add returned board to the boardmanager
            boardManager.AddBoard(board);

            //Add returned board to the list widget
            listbox.Items.Add(board.GetName());
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            //pass in currently selected board
            //passes the correct board from the board manager
            if(listbox.SelectedIndex >= 0)
                Content = new ListWindow(boardManager, listbox.SelectedIndex);
            //else
                //error message???
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
           String confirmDeleteMessage = "Are you sure you would like to delete this board and its content?";
           String confirmDeleteCaption = "Delete Board";
           MessageBoxButton confirmDeleteButton = MessageBoxButton.YesNo;
           MessageBoxImage confirmDeleteIcon = MessageBoxImage.Warning;

           MessageBoxResult result = MessageBox.Show(confirmDeleteMessage, confirmDeleteCaption, confirmDeleteButton, confirmDeleteIcon);

           if (result == MessageBoxResult.No)
              return;

           // Remove all data corresponding to Item


           // Remove Item from the list
           listbox.Items.Remove(listbox.SelectedItem);
           listbox.UnselectAll();
        }
    }
}
