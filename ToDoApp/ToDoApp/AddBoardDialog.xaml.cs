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
       bool edit;

       public AddBoardDialog(bool edit_, BoardManager boardManager_, ListBox listBox_)
       {
          boardManager = boardManager_;
          listBox = listBox_;
          InitializeComponent();
          WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
          edit = edit_;

          if (edit)
          {
             titleTextBox.Text = listBox.SelectedItem.ToString();
          }

          titleTextBox.Focus();
          titleTextBox.SelectAll();
       }

       private void confirm_Click(object sender, RoutedEventArgs e)
       {
          if (titleTextBox.Text == "")
          {
             MessageBox.Show("Please give your Board a title", 
                "Confirmation Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
             return;
          }

          if (edit)
          {
             if (titleTextBox.Text == boardManager.GetBoardAt(listBox.SelectedIndex).GetName())
             {
                this.Close();
                return;
             }

             try
             {
                boardManager.SetBoardNameAt(listBox.SelectedIndex, titleTextBox.Text);
             }
             catch (ToDoException exception)
             {
                MessageBox.Show(exception.getMessage(),
                   "Confirmation Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                titleTextBox.Focus();
                titleTextBox.SelectAll();
                return;
             }

             listBox.Items[listBox.SelectedIndex] = titleTextBox.Text;
             this.Close();
          }
          else
          {
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
          else if(e.Key == Key.Escape)
          {
             cancel_Click(sender, e);
          } 
       }
    }
}
