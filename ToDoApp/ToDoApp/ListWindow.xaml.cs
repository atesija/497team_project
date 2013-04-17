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
           // ItemModalWindow addItem = new ItemModalWindow();
           // addItem.ShowDialog();

            //TODO: Create dialog box that returns a string or Item
            Item item = new Item("todo", "blerg", 1);

            //Add item to the board
            board.AddItem(item);

            //Add returned board to the list widget
            todoList.Items.Add(item.GetName());
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //open dialog box that returns strings or item
            Item item = new Item("updated", "blerrrrrg", 2);

            ListView curList;
            //eddit currently selected item
            if (todoList.SelectedIndex >= 0)
            {
                board.EditItem(0, todoList.SelectedIndex, item);
                curList = todoList;
                
            }
            else if (doingList.SelectedIndex >= 0)
            {
                board.EditItem(1, doingList.SelectedIndex, item);
                curList = doingList;
            }
            else
            {
                board.EditItem(2, doneList.SelectedIndex, item);
                curList = doneList;
            }
            int curSelected = curList.SelectedIndex;
            curList.Items.RemoveAt(curSelected);
            curList.Items.Insert(curSelected, item.GetName());
            curList.SelectedIndex = curSelected;

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //eddit currently selected item
            if (todoList.SelectedIndex >= 0)
            {
                board.DeleteItemAt(0, todoList.SelectedIndex);
                todoList.Items.RemoveAt(todoList.SelectedIndex);
            }
            else if (doingList.SelectedIndex >= 0)
            {
                board.DeleteItemAt(1, doingList.SelectedIndex);
                doingList.Items.RemoveAt(todoList.SelectedIndex);
            }
            else
            {
                board.DeleteItemAt(2, doneList.SelectedIndex);
                doneList.Items.RemoveAt(todoList.SelectedIndex);
            }

        }

        private void listDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("itemFormat"))
            {
                String item = e.Data.GetData("itemFormat") as String;
                ListView listView = sender as ListView;
                listView.Items.Add(item);
                draggedList.Items.Remove(draggedList.SelectedItem);
                int to = 0;
                int from = 0;
                if (draggedList == doingList)
                    from = 1;
                else if (draggedList == doneList)
                    from = 2;
                if (listView == doingList)
                    to = 1;
                else if (listView == doingList)
                    to = 2;

                board.MoveItem(from, listView.Items.Count - 1, to);
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

        private void listSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView curList = sender as ListView;
            if (curList == todoList)
            {
                //disable selected in doing and done
                doingList.UnselectAll();
                doneList.UnselectAll();
            }
            else if (curList == doingList)
            {
                //disable selected in todo and done
                todoList.UnselectAll();
                doneList.UnselectAll();
            }
            else if (curList == doneList)
            {
                //disable in todo and doing
                todoList.UnselectAll();
                doingList.UnselectAll();
            }
            foreach (string selected in e.AddedItems)
            {
                int forsel = curList.Items.IndexOf(selected);
                curList.SelectedIndex = forsel;
            }            
        }

      
    }
}
