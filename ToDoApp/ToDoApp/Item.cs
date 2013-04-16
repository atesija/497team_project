using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    //A single item in a todo list
    class Item : Base
    {
        //Details (if any) about the item in the list
        string details;

        //A number from 1 to 5 based on how important the task is
        int rank;

        public Item()
        {
            this.SetName(string.Empty);
            details = string.Empty;
            rank = 1;
        }

        public Item(string name, string details, int rank)
        {
            this.SetName(name);
            this.details = details;
            this.rank = rank;
        }

        //Edit the item in one function
        public void Edit(string name, string details, int rank)
        {
            this.SetName(name);
            this.details = details;
            this.rank = rank;
        }

        public void SetDetails(string details)
        {
            this.details = details;
        }

        public string GetDetails()
        {
            return details;
        }

        public void SetRank(int rank)
        {
            if (rank < 1 || rank > 5)
                return;
            this.rank = rank;
        }

        public int GetRank()
        {
            return this.rank;
        }

        public override void SaveToFile(StreamWriter file)
        {
        }

        public override void ReadFromFile(StreamReader file)
        {
        }
    }
}
