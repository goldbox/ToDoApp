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
        bool isOpen;

        public Task (string name)
        {
            this.isOpen = true;
            this.name = name;
        }

        public Task (bool isOpen, string name)
        {
            this.isOpen = isOpen;
            this.name = name;
        }

        public void SetTaskStatus(bool newStatus)
        {
            this.isOpen = newStatus;
        }

        public string Name
        {
            get { return this.name; }
        }

        public bool IsOpen
        {
            get { return this.isOpen; }
        }
    }
}
