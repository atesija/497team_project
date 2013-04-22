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

        private const String toolTip = "Drag and Drop to move Items from one list to another.\n" +
                                       "Double click to Edit an Item.";

        public ListWindow(BoardManager boardManager_, Board board_)
        {
            InitializeComponent();

            boardManager = boardManager_;
            board = board_;

            todoList.ToolTip = toolTip;
            doingList.ToolTip = toolTip;
            doneList.ToolTip = toolTip;
            loadData(todoList, 0);
            loadData(doingList, 1);
            loadData(doneList, 2);

            boardLabel.Content = board.GetName();
        }

        private void loadData(ListView list, int listNum)
        {
            for (int i = 0; i < board.GetSize(listNum); i++)
            {
                list.Items.Add(board.GetItemAt(listNum, i).GetName());
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item();

            ItemModalWindow addItem = new ItemModalWindow(item);
            addItem.ShowDialog();

            //try catch should be in dialog box but leaving it here for now
            try
            {
                if (item.GetName() == string.Empty && item.GetDetails() == string.Empty)
                {
                }
                else
                {
                    //Add item to the board
                    board.AddItem(item);

                    //Add returned board to the list widget
                    todoList.Items.Add(item.GetName());
                }
            }
            catch (ToDoException exception)
            {
                MessageBox.Show(exception.getMessage(), "Add Item",
                   MessageBoxButton.OK, MessageBoxImage.Exclamation);
                add_Click(sender, e);
            }

            sortList(todoList, 0);
        }

        private void editDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //checks to see if a listViewItem was actually clicked
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            //if a listViewItem has been clicked handle the editing
            ListView curList = (ListView)sender;
            if (curList == null || !curList.HasItems || curList.SelectedIndex == -1)
                return;
            int listIndex = -1;
            if (curList.Name == "todoList")
            {
                listIndex = 0;
            }
            else if (curList.Name == "doingList")
            {
                listIndex = 1;
            }
            else if (curList.Name == "doneList")
            {
                listIndex = 2;
            }

            if (listIndex >= 0)
            {

                Item item = new Item();
                int curSelected = curList.SelectedIndex;
                item = board.GetItemAt(listIndex, curSelected);
                Item newItem = new Item(item.GetName(), item.GetDetails(), item.GetRank());

                ItemModalWindow addItem = new ItemModalWindow(newItem);
                addItem.ShowDialog();

                try
                {
                    board.EditItem(listIndex, curSelected, newItem);
                }
                catch (ToDoException exception)
                {
                    MessageBox.Show(exception.getMessage(), "Edit Item",
                       MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    editDoubleClick(sender, e);
                } 

                curList.Items.RemoveAt(curSelected);
                curList.Items.Insert(curSelected, item.GetName());
                curList.SelectedIndex = curSelected;
                sortList(curList, listIndex);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //open dialog box that returns strings or item
            int listIndex = -1;

            //try catch should be in diaglog box but leaving it here

            ListView curList = null;
            //edit currently selected item
            if (todoList.SelectedIndex >= 0)
            {
                //Add item to the board
                curList = todoList;
                listIndex = 0;                               
            }
            else if (doingList.SelectedIndex >= 0)
            {
                //Add item to the board
                curList = doingList;
                listIndex = 1;
            }
            else if (doneList.SelectedIndex >= 0)
            {
                //Add item to the board
                curList = doneList;
                listIndex = 2;
            }

            if (curList != null)
            {
               int curSelected = curList.SelectedIndex;
               Item item = board.GetItemAt(listIndex, curSelected);
               Item newItem = new Item(item.GetName(), item.GetDetails(), item.GetRank());
               ItemModalWindow addItem = new ItemModalWindow(newItem);
               addItem.ShowDialog();

               try
               {
                  board.EditItem(listIndex, curSelected, newItem);
               }
               catch (ToDoException exception)
               {
                  MessageBox.Show(exception.getMessage(), "Edit Item",
                     MessageBoxButton.OK, MessageBoxImage.Exclamation);
                  edit_Click(sender, e);
               }
               curList.Items.RemoveAt(curSelected);
               curList.Items.Insert(curSelected, item.GetName());
               curList.SelectedIndex = curSelected;

               sortList(curList, listIndex);
            }
            else
            {
               // No item selected
               MessageBox.Show("Please select an item", "Edit Item",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
               return;
            }
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
                doingList.Items.RemoveAt(doingList.SelectedIndex);
            }
            else if (doneList.SelectedIndex >= 0)
            {
                board.DeleteItemAt(2, doneList.SelectedIndex);
                doneList.Items.RemoveAt(doneList.SelectedIndex);
            }
            else
            {
               // No item selected
               MessageBox.Show("Please select an item", "Delete Item",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
               return;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new BoardWindow(boardManager);
        }

        private void sortList(ListView listToSort, int listIndex)
        {
            listToSort.Items.Clear();

            board.sortList(listIndex);

            for (int i = 0; i < board.GetSize(listIndex); i++)
            {
                listToSort.Items.Add(board.GetItemAt(listIndex, i).GetName());
            }
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

        private void listPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void listMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                draggedList = sender as ListView;
                
                if (draggedList.SelectedIndex >= 0)
                {
                    String item = draggedList.SelectedItems[0].ToString();

                    ListViewItem listViewItem = FindAnsestor((DependencyObject)e.OriginalSource);
                    if (listViewItem != null)
                    {
                        DataObject dragData = new DataObject("itemFormat", item);
                        DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                    }
                }


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

        private void listDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("itemFormat"))
            {
                String item = e.Data.GetData("itemFormat") as String;
                ListView listView = sender as ListView;
                if (listView != draggedList)
                {
                    listView.Items.Add(item);
                    int to = -1;
                    int from = -1;

                    if (draggedList == todoList)
                        from = 0;
                    else if (draggedList == doingList)
                        from = 1;
                    else if (draggedList == doneList)
                        from = 2;

                    if (listView == todoList)
                        to = 0;
                    else if (listView == doingList)
                        to = 1;
                    else if (listView == doneList)
                        to = 2;

                    if (to >= 0 && from >= 0 && draggedList.SelectedIndex >= 0)
                    {
                        board.MoveItem(from, draggedList.SelectedIndex, to);
                        draggedList.Items.Remove(draggedList.SelectedItem);
                        sortList(listView, to);
                    }
                }
            }
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
