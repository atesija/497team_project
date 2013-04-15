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

        void SetDetails(string details)
        {
            this.details = details;
        }

        string GetDetails()
        {
            return details;
        }

        void SetRank(int rank)
        {
            if (rank < 1 || rank > 5)
                return;
            this.rank = rank;
        }

        int GetRank()
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
