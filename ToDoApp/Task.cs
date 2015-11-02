using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Task
    {
        string name;
        bool openTask;

        public Task (string name)
        {
            this.openTask = true;
            this.name = name;
        }

        public Task (bool openTask, string name)
        {
            this.openTask = (openTask) ? true : false;
            this.name = name;
        }

        public void SetTaskStatus(bool newStatus)
        {
            this.openTask = newStatus;
        }

        public string Name
        {
            get { return this.name; }
        }

        public bool TaskStatus
        {
            get { return this.openTask; }
        }
    }
}
