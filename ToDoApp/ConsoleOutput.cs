using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class ConsoleOutput
    {
        public void Print(ToDoTasks tasksList)
        {
            tasksList.Reset();
            Console.WriteLine("ID. Is Open. Task");
            foreach (Task task in tasksList)
                Console.WriteLine(task.ID + ". " + task.IsOpen + "     " + task.Name);
        }
    }
}
