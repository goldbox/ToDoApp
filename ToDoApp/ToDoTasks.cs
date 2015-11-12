﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ToDoApp
{
    public class ToDoTasks : IEnumerable, IEnumerator
    {
        private List<Task> tasksList;
        private int position = -1;
        private MyCounter id;

        public ToDoTasks()
        {
            this.id = new MyCounter();
            this.tasksList = new List<Task>();
        }

        public ToDoTasks (List<Task> initialListOfTasks)
        {
            this.tasksList = initialListOfTasks;
            this.id = new MyCounter(GetLastID());
        }
        private int GetLastID()
        {
            int totalTasks = this.tasksList.Count;
            int lastID = this.tasksList[totalTasks - 1].ID;
            return (lastID != 0) ? lastID + 1 : 1;
        }

        public void AddTask (string newTask)
        {
            this.tasksList.Add(new Task(id.NextValue(), newTask));
        }

        public bool IsEmpty()
        {
            return (this.tasksList.Count == 0);
        }

        public void ChangeTaskStatus(int index, bool taskStatus)
        {
            this.tasksList[index].SetTaskStatus(taskStatus);
        }

        public void Find(string element)
        {
            this.tasksList = this.tasksList.FindAll(p => p.Name.Contains(element));
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        
        public bool MoveNext()
        {
            position++;
            return (position < this.tasksList.Count);
        }

        public void Reset()
        {
            position = -1; 
        }

        public object Current
        {
            get { return this.tasksList[position]; }
        }

        public Task GetTask(int index)
        {
            return this.tasksList[index];
        }
    }
}
