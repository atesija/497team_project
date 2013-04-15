using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp
{
    //Holds a bunch of items (basically is the todo list)
    class ItemList : Base
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

        protected override void SaveToFile(System.IO.StreamWriter file)
        {
            base.SaveToFile(file);
        }
    }
}
