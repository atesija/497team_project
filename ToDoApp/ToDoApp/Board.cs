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
