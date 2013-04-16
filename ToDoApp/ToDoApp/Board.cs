using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    class Board : Base
    {
        //A list of the different todo lists
        List<TodoList> todoLists;

        //Adds a list to todoLists
        public void AddList(string name)
        {
            TodoList l = new TodoList();
            l.SetName(name);
            todoLists.Add(l);
        }

        //Changes the name of the list at location
        public void EditListAt(string name, int at)
        {
            TodoList l = todoLists[at];
            l.SetName(name);
            todoLists[at] = l;
        }

        //Gets a reference to the item at the location
        public TodoList GetListAt(int at)
        {
            return todoLists[at];
        }

        //Removes the item at the location and returns it
        public TodoList TakeListAt(int at)
        {
            TodoList l = todoLists[at];
            todoLists.RemoveAt(at);
            return l;
        }

        //Opens a file and saves the entire tree (Board, List, Item) to the file
        public void SaveToFile()
        {
            StreamWriter file = new StreamWriter("lists.txt");

            //TODO: save board to file

            //Save each todo list to file
            foreach (TodoList t in todoLists)
                t.SaveToFile(file);
        }

        //Opens a file and reads the data from it
        public void ReadFromFile()
        {
            StreamReader file = new StreamReader("lists.txt");
        }
    }
}
