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
    public partial class BoardWindow : Window
    {
        public BoardWindow()
        {
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
            ListWindow list = new ListWindow();
            list.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
