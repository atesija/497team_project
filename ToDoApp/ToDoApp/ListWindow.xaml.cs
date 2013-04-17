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

        private ListView draggedList;

        private Board board;

        private BoardManager boardManager;

        public ListWindow(BoardManager boardManager_, Board board_)
        {
            boardManager = boardManager_;
            board = board_;
            
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ItemModalWindow addItem = new ItemModalWindow();
            addItem.ShowDialog();
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
                draggedList.Items.Remove(draggedList.SelectedItem);
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
                    draggedList = listView;

                    String item = (String)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                    DataObject dragData = new DataObject("itemFormat", item);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);

                    
                    //listView.Items.Remove(listView.SelectedItem);

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
