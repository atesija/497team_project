using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    class BoardManager
    {
        List<Board> boards;

        public BoardManager()
        {
            boards = new List<Board>();
        }

        //Opens a file and saves the entire tree (Board, List, Item) to the file
        public void SaveToFile()
        {
            StreamWriter file = new StreamWriter("lists.txt");
        }

        //Opens a file and reads the data from it
        public void ReadFromFile()
        {
            StreamReader file = new StreamReader("lists.txt");
        }
    }
}
