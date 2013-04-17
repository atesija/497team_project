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
    /// Interaction logic for AddBoardDialog.xaml
    /// </summary>
    public partial class AddBoardDialog : Window
    {
       BoardManager boardManager;
       ListBox listBox;

       public AddBoardDialog(BoardManager boardManager_, ListBox listBox_)
       {
          boardManager = boardManager_;
          listBox = listBox_;
          InitializeComponent();
          WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
       }

       private void confirm_Click(object sender, RoutedEventArgs e)
       {
          if (titleTextBox.Text == "")
          {
             MessageBox.Show("Please give your new Board a title", 
                "Add Board", MessageBoxButton.OK, MessageBoxImage.Exclamation);
             return;
          }

          Board board = new Board(titleTextBox.Text);

          try
          {
             //Add returned board to the boardmanager
             boardManager.AddBoard(board);

             //Add returned board to the list widget
             listBox.Items.Add(board.GetName());

             this.Close();
          }
          catch (ToDoException exception)
          {
             MessageBox.Show(exception.getMessage(), "Add Board", 
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
          }
       }

       private void cancel_Click(object sender, RoutedEventArgs e)
       {
          this.Close();
       }
    }
}
