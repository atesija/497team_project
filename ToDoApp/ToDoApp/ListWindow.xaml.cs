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
    public partial class ListWindow :  UserControl
    {

        public ListWindow()
        {
           
            InitializeComponent();
            itemlist.Items.Add("Potatos");
            itemlist.Items.Add("Carrots");
            itemlist.Items.Add("Capers");
            itemlist.Items.Add("Beer");
            itemlist.Items.Add("Anchovies");
            itemlist.Items.Add("Beer");
            itemlist.Items.Add("Flour");
            itemlist.Items.Add("Green Peppers");
            itemlist.Items.Add("Cabbage");
            itemlist.Items.Add("Jalapenos");
            itemlist.Items.Add("Pizza");
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ItemModalWindow addItem = new ItemModalWindow();
            addItem.ShowDialog();
            itemlist.Items.Add("Beer");
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
