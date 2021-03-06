﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    //Holds a bunch of items
    public class ItemList : Base
    {
        //The list of items
        List<Item> items;

        public ItemList()
        {
            items = new List<Item>();
        }

        public ItemList(string name)
        {
            items = new List<Item>();
            this.SetName(name);
        }

        public int GetSize()
        {
            return items.Count;
        }

        public bool Exists(string name)
        {
            return items.Exists(c => c.GetName() == name);
        }

        public bool ExistsLoop(int index, string name)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                if (i != index)
                {
                    Item c = GetItemAt(i);
                    if (name == c.GetName())
                        return true;
                }
            }

            return false;
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

        //Edits an item at the given index
        public void EditItemAt(int at, Item i)
        {
            items[at] = i;
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

        public void DeleteItemAt(int at)
        {
            items.RemoveAt(at);
        }

        public void sortItems()
        {
            items.Sort(new RankComparer());
        }

        public override void SaveToFile(StreamWriter file)
        {
            foreach (Item i in items)
                file.WriteLine(i.GetName() + "|" + i.GetDetails() + "|" + i.GetRank().ToString());
        }

        public override void ReadFromFile(StreamReader file)
        {
        }
    }

    public class RankComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.GetRank() > y.GetRank())
                return 1;
            if (x.GetRank() < y.GetRank())
                return -1;
            else
                return 0;
        }
    }

}
