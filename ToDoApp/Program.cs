using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TxtWorker txtWorker = new TxtWorker();
            List<string> initialList = txtWorker.Load();
            ToDoTasks tasksList = new ToDoTasks(initialList);

            if (args.Length == 0 || (args[0] != "add" && args[0] != "list"))
            {
                Console.WriteLine("Please enter one of the following arguments:");
                Console.WriteLine("add - To add a new task");
                Console.WriteLine("list - To see the list with opened tasks");
                Console.WriteLine("E.g. ToDoApp.exe add \"pay electricity\"");
                return;
            }

            switch (args[0])
            {
                case "add":
                    if (args.Length >= 2)
                    {
                        tasksList.AddTask(args[1]);
                        txtWorker.Save(tasksList);
                        Console.WriteLine("Task added successfully.");
                    }
                    break;
                case "list":
                    if (tasksList.IsEmpty())
                    {
                        Console.WriteLine("No Tasks for today.\nEnjoy your day!");
                        break;
                    }
                    int i = 1;
                    foreach (string line in tasksList)
                    {
                        Console.WriteLine(line);
                        i++;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
