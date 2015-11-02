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
            List<Task> initialList = txtWorker.Load();
            ToDoTasks tasksList = new ToDoTasks(initialList);

            if (args.Length == 0 || (args[0] != "/add" && args[0] != "/list" && args[0] != "/done"))
            {
                Console.WriteLine("Please enter one of the following arguments:");
                Console.WriteLine("/add \"...\"- To add a new task");
                Console.WriteLine("/list - To see the list with opened tasks");
                Console.WriteLine("/done \"...\" - To set a particular task as done");
                Console.WriteLine("E.g. ToDoApp.exe add \"pay electricity\"");
                return;
            }

            switch (args[0])
            {
                case "/add":
                    if (args.Length >= 2)
                    {
                        tasksList.AddTask(args[1]);
                        txtWorker.Save(tasksList);
                        Console.WriteLine("Task added successfully.");
                    }
                    break;
                case "/list":
                    if (tasksList.IsEmpty())
                    {
                        Console.WriteLine("No Tasks for today.\nEnjoy your day!");
                        break;
                    }
                    int index = 1;
                    foreach (Task task in tasksList)
                    {
                        if (task.TaskStatus == true)
                            Console.WriteLine(index + ". " + task.Name);
                        index++;
                    }
                    break;
                case "/done":
                    if(args.Length >= 2)
                    {
                        int i = -1;
                        bool numberValid = Int32.TryParse(args[1], out i);
                        if (numberValid && (i < initialList.Count))
                        {
                            tasksList.ChangeTaskStatus(i - 1, false);
                            txtWorker.Save(tasksList);
                            Console.WriteLine("Task " + i + " set to done!");
                        } else   
                        {
                            Console.WriteLine("Please write the valid number of the finished task.");
                            Console.WriteLine("E.g. /done 1");
                        }
                    }

                    break;
                default:
                    break;
            }

        }
    }
}
