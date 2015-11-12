using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath("ToDoAppTasksList");
            TxtDocument txtDocument = new TxtDocument(path);
            HtmlDocument htmlDocument = new HtmlDocument(path);
            List<Task> initialList = txtDocument.Load();
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
                    Console.WriteLine("/export - To export All Tasks in html");
                    Console.WriteLine("/find \"string\" - To find some specific Tasks");
                    Console.WriteLine("E.g. ToDoApp.exe add \"pay electricity\"");
                    break;

                case "/add":
                    if (args.Length >= 2)
                    {
                        tasksList.AddTask(args[1]);
                        txtDocument.Save(tasksList);
                        Console.WriteLine("Task added successfully.");
                    }
                    break;

                case "/list":
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
                            if (task.IsOpen == true)
                                Console.WriteLine(task.ID + ". " + task.Name);
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
                                    if (task.IsOpen == false)
                                        Console.WriteLine(task.ID + ". " + task.Name);
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
                        int id;
                        bool numberValid = Int32.TryParse(args[1], out id);
                        if (numberValid && (id <= initialList.Count) && (id > 0))
                        {
                            tasksList.ChangeTaskStatus(id - 1, false);
                            txtDocument.Save(tasksList);
                            Console.WriteLine("Task " + id + " is set to done!");
                        }
                        else
                        {
                            Console.WriteLine("Please write the valid number of the finished task.");
                            Console.WriteLine("E.g. /done 1");
                        }
                    }
                    break;

                case "/export":
                    if (args.Length >= 2)
                    {
                        switch (args[1])
                        {
                            case "done":
                                htmlDocument.Save(tasksList, "done");
                                Console.WriteLine("Finished Tasks exported successfully to html!");
                                break;
                            case "all":
                                htmlDocument.Save(tasksList, "all");
                                Console.WriteLine("All Tasks exported successfully to html!");
                                break;
                            default:
                                Console.WriteLine("/export - To export opened tasks to html");
                                Console.WriteLine("/export done - To export finished tasks to html");
                                Console.WriteLine("/export all - To export all tasks to html");
                                break;
                        }
                        break;
                    }
                    htmlDocument.Save(tasksList);
                    Console.WriteLine("To DO Tasks exported successfully to html!");
                    break;

                case "/find":
                    if (args.Length >= 2)
                    {
                        tasksList.Find(args[1]);
                        if (tasksList.IsEmpty())
                        {
                            Console.WriteLine("No results for: {0}", args[1]);
                        } else
                        {
                            Console.WriteLine("Tasks containing \"{0}\":", args[1]);
                            foreach (Task task in tasksList)
                            {
                                    Console.WriteLine(task.ID + ". " + task.Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please write the string you want to search for.");
                        Console.WriteLine("E.g. /find \"go to\"");
                    }
                    break;
                default:
                    break;
            }
        }

        private static bool IsNotAValidArgument(string[] args)
        {
            return args.Length == 0 || (args[0] != "/add" && 
                                        args[0] != "/list" && 
                                        args[0] != "/done" && 
                                        args[0] != "/?" &&
                                        args[0] != "/export" &&
                                        args[0] != "/find");
        }
    }
}
