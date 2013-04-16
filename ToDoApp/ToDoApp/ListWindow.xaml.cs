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

//dragging and dropping functions were assisted in being written by this website: http://wpftutorial.net/DragAndDrop.html

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow :  UserControl
    {
        private Point startPoint;

        public ListWindow()
        {
           
            InitializeComponent();
            todoList.Items.Add("Potatos");
            todoList.Items.Add("Carrots");
            todoList.Items.Add("Capers");
            todoList.Items.Add("Beer");
            todoList.Items.Add("Anchovies");
            todoList.Items.Add("Beer");
            todoList.Items.Add("Flour");
            todoList.Items.Add("Green Peppers");
            todoList.Items.Add("Cabbage");
            todoList.Items.Add("Jalapenos");
            todoList.Items.Add("Pizza");
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ItemModalWindow addItem = new ItemModalWindow();
            addItem.ShowDialog();
            todoList.Items.Add("Beer");
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("itemFormat"))
            {
                String item = e.Data.GetData("itemFormat") as String;
                ListView listView = sender as ListView;
                listView.Items.Add(item);
            }
        }

        private void listDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("itemFormat") ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void listMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAnsestor((DependencyObject)e.OriginalSource);

                if (listViewItem != null)
                {

                    String item = (String)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                    DataObject dragData = new DataObject("itemFormat", item);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);

                    listView.Items.Remove(listView.SelectedItem);

                }
            }
        }

        private void listPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null) ;
        }

        private ListViewItem FindAnsestor(DependencyObject current)
        {
            do
            {
                if (current is ListViewItem)
                {
                    return (ListViewItem)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;

        }

      
    }
}
