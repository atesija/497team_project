using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        protected override void SaveToFile(System.IO.StreamWriter file)
        {
            base.SaveToFile(file);
        }
    }
}
