using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    //Base class for the Board, List, and Item objects so they can be written to a file easily
    class Base
    {
        //The name of the object to be displayed
        string name;

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        //Used to write the object to a file
        //Requires the file to be opened before calling and closed after
        protected virtual void SaveToFile(StreamWriter file)
        {
        }
    }
}
