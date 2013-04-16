﻿using System;
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

        public TodoList()
        {
            items = new List<Item>();
        }

        public TodoList(string name)
        {
            items = new List<Item>();
            this.SetName(name);
        }

        //Adds an item to the todo list
        public void AddItem(Item i)
        {
            items.Add(i);
        }

        //Edits an item at the given index
        public void EditItemAt(int at, string name, string details, int rank)
        {
            items[at].Edit(name, details, rank);
        }

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
