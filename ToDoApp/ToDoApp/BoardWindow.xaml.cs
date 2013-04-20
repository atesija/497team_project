﻿using System;
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
            InitializeComponent();

            boardManager = boardManager_;

            for (int i = 0; i < boardManager.GetSize(); i++)
            {
                listBox.Items.Add(boardManager.GetBoardAt(i).GetName());
            }
        }

        private void openBoard(object sender, MouseButtonEventArgs e)
        {
           // Checks whether a ListBox Item was double-clicked
           DependencyObject dependencyObject = (DependencyObject) e.OriginalSource;

           while ((dependencyObject != null) && !(dependencyObject is ListBoxItem))
           {
              dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
           }

           if (dependencyObject == null)
              return;

           Board board = boardManager.GetBoardAt(listBox.SelectedIndex);
           Content = new ListWindow(boardManager, board);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
           // Save data
           boardManager.SaveToFile();

           // Direct user to login screen
           Content = new LoginWindow();
        }

        private void addBoard(object sender, RoutedEventArgs e)
        {
           AddBoardDialog addDialog = new AddBoardDialog(false, boardManager, listBox);
           addDialog.ShowDialog();
        }

        private void editBoard(object sender, RoutedEventArgs e)
        {
           if (listBox.SelectedItem == null)
           {
              MessageBox.Show("Please select a Board", "Edit Board",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
              return;
           }

           AddBoardDialog editDialog;

           try
           {
              editDialog = new AddBoardDialog(true, boardManager, listBox);
           }
           catch (ToDoException)
           {
              return;
           }

           editDialog.ShowDialog();
        }

        private void deleteBoard(object sender, RoutedEventArgs e)
        {
           // Check that an Item is selected
           if (listBox.SelectedItem == null)
           {
              MessageBox.Show("Please select a Board to delete", "Delete Board", 
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
              return;
           }

           // Ask user to confirm
           String confirmDeleteMessage = 
              "Are you sure you would like to delete this board and its contents?";
           String confirmDeleteCaption = "Delete Board";
           MessageBoxButton confirmDeleteButton = MessageBoxButton.YesNo;
           MessageBoxImage confirmDeleteIcon = MessageBoxImage.Warning;

           MessageBoxResult result = MessageBox.Show(confirmDeleteMessage, 
              confirmDeleteCaption, confirmDeleteButton, confirmDeleteIcon);

           if (result == MessageBoxResult.No)
              return;

           // Remove all data corresponding to Item
           boardManager.DeleteBoardAt(listBox.SelectedIndex);

           // Remove Item from the list
           listBox.Items.Remove(listBox.SelectedItem);
           listBox.UnselectAll();
        }
    }
}
