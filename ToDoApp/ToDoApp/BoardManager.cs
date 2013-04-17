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

        string fileName;

        public BoardManager()
        {
            boards = new List<Board>();
        }

        public BoardManager(string username, string password)
        {
            fileName = username + password;
        }

        //Opens a file and saves the entire tree (Board, List, Item) to the file
        public void SaveToFile()
        {
            StreamWriter file = new StreamWriter(fileName + ".txt");
        }

        //Opens a file and reads the data from it
        public void ReadFromFile()
        {
            StreamReader file = new StreamReader(fileName + ".txt");
        }
    }
}
