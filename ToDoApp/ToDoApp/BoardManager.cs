using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    public class BoardManager
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

        //Returns a board from the selected location
        public Board GetBoardAt(int at)
        {
            return boards[at];
        }

        //Adds a board
        public void AddBoard(Board b)
        {
            boards.Add(b);
        }

        public void EditBoardAt(int at, Board b)
        {
            boards[at] = b;
        }

        public void EditBoardAt(int at, string name)
        {
            boards[at].SetName(name);
        }

        public void DeleteBoardAt(int at)
        {
            boards.RemoveAt(at);
        }
    }
}
