﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommandLine;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath("ToDoAppTasksList.txt");
            TxtWorker txtWorker = new TxtWorker(path);
            List<Task> initialList = txtWorker.Load();
            ToDoTasks tasksList = new ToDoTasks(initialList);

            if (IsNotAValidArgument(args))
            {
                Console.WriteLine("Use /? argument for help");
                return;
            }

            switch (args[0])
            {
                case "/?":
                    Console.WriteLine("Please enter one of the following arguments:");
                    Console.WriteLine("/add \"...\"- To add a new task");
                    Console.WriteLine("/done taskID - To set a particular task as done");
                    Console.WriteLine("/list - To see the list with opened tasks");
                    Console.WriteLine("/list done - To see the list with finished tasks");
                    Console.WriteLine("E.g. ToDoApp.exe add \"pay electricity\"");
                    break;

                case "/add":
                    if (args.Length >= 2)
                    {
                        tasksList.AddTask(args[1]);
                        txtWorker.Save(tasksList);
                        txtWorker.SaveHtml(tasksList);
                        Console.WriteLine("Task added successfully.");
                    }
                    break;

                case "/list":
                    int index = 1;
                    if (args.Length == 1)
                    {
                        if (tasksList.IsEmpty())
                        {
                            Console.WriteLine("No Tasks for today.\nEnjoy your day!");
                            break;
                        }
                        Console.WriteLine("Here is the list with your opened tasks:");
                        foreach (Task task in tasksList)
                        {
                            if (task.TaskStatus == true)
                                Console.WriteLine(index + ". " + task.Name);
                            index++;
                        }
                        break;
                    }
                    else
                        switch (args[1])
                        {
                            case "done":
                                Console.WriteLine("Here is the list with the finished tasks:");
                                foreach (Task task in tasksList)
                                {
                                    if (task.TaskStatus == false)
                                        Console.WriteLine(index + ". " + task.Name);
                                    index++;
                                }
                                break;
                            default:
                                Console.WriteLine("/list - To see the list with opened tasks");
                                Console.WriteLine("/list done - To see the list with finished tasks");
                                break;
                        }
                    break;

                case "/done":
                    if (args.Length >= 2)
                    {
                        int i;
                        bool numberValid = Int32.TryParse(args[1], out i);
                        if (numberValid && (i <= initialList.Count) && (i > 0))
                        {
                            tasksList.ChangeTaskStatus(i - 1, false);
                            txtWorker.Save(tasksList);
                            txtWorker.SaveHtml(tasksList);
                            Console.WriteLine("Task " + i + " is set to done!");
                        }
                        else
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

        private static bool IsNotAValidArgument(string[] args)
        {
            return args.Length == 0 || (args[0] != "/add" && args[0] != "/list" && args[0] != "/done" && args[0] != "/?");
        }
    }
}
