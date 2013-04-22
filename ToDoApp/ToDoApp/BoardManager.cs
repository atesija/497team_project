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
            fileName = username.GetHashCode().ToString() + password.GetHashCode().ToString();
            boards = new List<Board>();
        }

        public BoardManager(string fileName, bool loadFromFile)
        {
            this.fileName = fileName;
            boards = new List<Board>();

            if (loadFromFile)
            {
                this.ReadFromFile();
            }
        }

        public int GetSize()
        {
            return boards.Count;
        }

        //Opens a file and saves the entire tree (Board, List, Item) to the file
        public void SaveToFile()
        {
            if (this == null)
               return;

            StreamWriter file = new StreamWriter(fileName + ".board");
            foreach (Board b in boards)
                b.SaveToFile(file);
            file.Close();
        }

        //Opens a file and reads the data from it
        public void ReadFromFile()
        {
            //Open the file
            StreamReader file = new StreamReader(fileName + ".board");
            string s;
            Board b;
            while (!file.EndOfStream)
            {
                s = file.ReadLine();

                //If you hit a board marker
                if (s == "#")
                {
                    s = file.ReadLine();
                    b = new Board(s);

                    //populate the board and add it to the manager
                    b.ReadFromFile(file);
                    this.AddBoard(b);
                }
            }
            file.Close();
        }

        //Returns a board from the selected location
        public Board GetBoardAt(int at)
        {
            return boards[at];
        }

        public void SetBoardNameAt(int at, String name)
        {
            if (boards.Exists(c => c.GetName() == name))
                throw new ToDoException("A board with this name already exists");
            boards[at].SetName(name);
        }

        //Adds a board
        public void AddBoard(Board b)
        {
            if (boards.Exists(c => c.GetName() == b.GetName()))
                throw new ToDoException("A board with this name already exists");
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
