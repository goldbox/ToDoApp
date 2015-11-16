using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Task
    {
        int id;
        string name;
        bool isOpen;

        public Task (int id, string name)
        {
            this.id = id;
            this.isOpen = true;
            this.name = name;
        }

        public Task (int id, bool isOpen, string name)
        {
            this.id = id;
            this.isOpen = isOpen;
            this.name = name;
        }

        public void ChangeStatus(bool newStatus)
        {
            this.isOpen = newStatus;
        }

        public void ChangeName(string newName)
        {
            this.name = newName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public bool IsOpen
        {
            get { return this.isOpen; }
        }

        public int ID
        {
            get { return this.id; }
        }
    }
}
