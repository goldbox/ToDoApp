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
        private List<Task> tasksList = new List<Task>();
        private int position = -1;

        public ToDoTasks (List<Task> initialListOfTasks)
        {
            this.tasksList = initialListOfTasks;
        }

        public void AddTask (string newTask)
        {
            this.tasksList.Add(new Task(newTask));
        }

        public bool IsEmpty()
        {
            return (this.tasksList.Count == 0);
        }

        public void ChangeTaskStatus(int index, bool taskStatus)
        {
            this.tasksList[index].SetTaskStatus(taskStatus);
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
