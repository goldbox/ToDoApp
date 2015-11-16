using System;
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
        private ID id;

        public ToDoTasks()
        {
            this.id = new ID();
            this.tasksList = new List<Task>();
        }

        public ToDoTasks (List<Task> initialListOfTasks)
        {
            this.tasksList = initialListOfTasks;
            this.id = new ID(GetNextID());
        }

        private int GetNextID()
        {
            if (IsEmpty())
                return 1;
            int totalTasks = this.tasksList.Count;
            int lastID = this.tasksList[totalTasks - 1].ID;
            return lastID + 1;
        }

        public void AddTask (string newTask)
        {
            this.tasksList.Add(new Task(id.NextValue(), newTask));
        }

        public bool IsEmpty()
        {
            return (this.tasksList.Count == 0);
        }

        public void ChangeTaskStatus(int id, bool taskStatus)
        {
            int index = this.tasksList.FindIndex(p => p.ID == id);
            this.tasksList[index].ChangeStatus(taskStatus);
        }

        public void ChangeTaskName(int id, string taskName)
        {
            int index = this.tasksList.FindIndex(p => p.ID == id);
            this.tasksList[index].ChangeName(taskName);
        }

        public bool IDExist(int id)
        {
            return this.tasksList.Exists(p => p.ID == id);
        }

        public void Filter(string findElement)
        {
            this.tasksList = this.tasksList.FindAll(p => p.Name.Contains(findElement));
        }

        public void Filter(bool isOpen)
        {
            this.tasksList = this.tasksList.FindAll(p => p.IsOpen.Equals(isOpen));
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
