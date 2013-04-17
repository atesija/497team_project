using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoApp
{
    public class Board : Base
    {
        const int NUM_LISTS = 3;

        //A list of the different todo lists
        ItemList[] todoLists;

        public Board()
        {
            todoLists = new ItemList[NUM_LISTS];
            for (int i = 0; i < NUM_LISTS; ++i)
                todoLists[i] = new ItemList();
            this.SetNames();
        }

        public Board(string name)
        {
            todoLists = new ItemList[NUM_LISTS];
            for (int i = 0; i < NUM_LISTS; ++i)
                todoLists[i] = new ItemList();
            this.SetNames();
            this.SetName(name);
        }

        public int GetSize(int list)
        {
            return todoLists[list].GetSize();
        }

        private void SetNames()
        {
            todoLists[0].SetName("To Do");
            todoLists[1].SetName("Doing");
            todoLists[2].SetName("Done");
        }

        public void AddItem(Item i)
        {
            for (int j = 0; j < NUM_LISTS; j++)
            {
                if (todoLists[j].Exists(i.GetName()))
                    throw new ToDoException("An item with this name already exists");
            }
            todoLists[0].AddItem(i);
        }

        public void MoveItem(int fromList, int fromItem, int toList)
        {
            Item i = todoLists[fromList].TakeItemAt(fromItem);
            todoLists[toList].AddItem(i);
        }

        public void EditItem(int listIndex, int itemIndex, Item i)
        {
            for (int j = 0; j < NUM_LISTS; j++)
            {
                if (todoLists[j].Exists(i.GetName()))
                    throw new ToDoException("An item with this name already exists");
            }
            todoLists[listIndex].EditItemAt(itemIndex, i);
        }

        public Item GetItemAt(int listIndex, int itemIndex)
        {
            return todoLists[listIndex].GetItemAt(itemIndex);
        }

        public void DeleteItemAt(int listIndex, int itemIndex)
        {
            todoLists[listIndex].DeleteItemAt(itemIndex);
        }

        public override void SaveToFile(StreamWriter file)
        {
            //TODO: save board to file

            //Save each todo list to file
            foreach (ItemList i in todoLists)
                i.SaveToFile(file);
        }

        public override void ReadFromFile(StreamReader file)
        {
        }
    }
}
