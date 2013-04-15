using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    //Holds a bunch of items
    class TodoList : Base
    {
        //The list of items
        List<Item> items;

        //Gets a reference to the item in the list
        public Item GetItemAt(int at)
        {
            return items[at];
        }

        //Removes the item from the list and returns it
        public Item TakeItemAt(int at)
        {
            Item i = items[at];
            items.RemoveAt(at);
            return i;
        }

        public override void SaveToFile(StreamWriter file)
        {
            foreach (Item i in items)
                i.SaveToFile(file);
        }

        public override void ReadFromFile(StreamReader file)
        {
        }
    }
}
