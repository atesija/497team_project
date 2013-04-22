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
    /// Interaction logic for ItemModalWindow.xaml
    /// </summary>
    public partial class ItemModalWindow : Window
    {
        private Item item;
        public ItemModalWindow()
        {
            InitializeComponent();
        }

        public ItemModalWindow(Item item_)
        {
            InitializeComponent();
            for(int i=1; i<6; ++i)
            {
                ratingBox.Items.Add(i);
            }
            item = item_;
            initializeWindow();
        }

        private void initializeWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            itemNameBox.Text = item.GetName();
            itemDescriptionBox.Text = item.GetDetails();
            ratingBox.SelectedValue = item.GetRank();
            itemNameBox.Focus();
            itemNameBox.SelectAll();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (itemNameBox.Text == "")
            {
               MessageBox.Show("Please give this item a name", "Item",
                  MessageBoxButton.OK, MessageBoxImage.Exclamation);
               return;
            }

            item.SetName(itemNameBox.Text);
            item.SetDetails(itemDescriptionBox.Text);
            item.SetRank((int)ratingBox.SelectedItem);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void itemDescriptionBox_KeyDownHandler(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Return)
           {
              add_Click(sender, e);
           }
           else if (e.Key == Key.Escape)
           {
              cancelButton_Click(sender, e);
           } 
        }

        private void itemNameBox_KeyDownHandler(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Return)
           {
              add_Click(sender, e);
           }
           else if (e.Key == Key.Escape)
           {
              cancelButton_Click(sender, e);
           } 
        }
    }
}
