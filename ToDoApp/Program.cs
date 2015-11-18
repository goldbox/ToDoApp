using System;
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
        static string path = Path.GetFullPath("TasksList");
        static TxtDocument txtDocument = new TxtDocument(path);
        static HtmlDocument htmlDocument = new HtmlDocument(path);
        static ToDoTasks tasksList = txtDocument.Load();

        static void Main(string[] args)
        {
            
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();

            if (parser.ParseArguments(args, cmdOptions))
            {
                //Add
                if (!string.IsNullOrEmpty(cmdOptions.Add))
                {
                    tasksList.AddTask(cmdOptions.Add);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task \"{0}\" added successfully", cmdOptions.Add);
                }

                //Done
                if (tasksList.IDExist(cmdOptions.Done))
                {
                    tasksList.ChangeTaskStatus(cmdOptions.Done, false);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task {0} set to done", cmdOptions.Done);
                }
                else if(cmdOptions.Done > 0)
                    Console.WriteLine("ID {0} is not valid", cmdOptions.Done);
                
                //Edit
                if (!string.IsNullOrEmpty(cmdOptions.EditText) && tasksList.IDExist(cmdOptions.EditIndex))
                {
                    tasksList.ChangeTaskName(cmdOptions.EditIndex, cmdOptions.EditText);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task {0} modified", cmdOptions.EditIndex);
                }
                else if (cmdOptions.EditIndex > 0)
                    Console.WriteLine("ID {0} is not valid", cmdOptions.EditIndex);
                
                //Find
                if (!string.IsNullOrEmpty(cmdOptions.FindString))
                {
                    FindTasks(cmdOptions.FindString, cmdOptions.FindTarget);
                }

                //Find Tag
                if (!string.IsNullOrEmpty(cmdOptions.Tag) && cmdOptions.Tag[0] == '#')
                {
                    FindTag(cmdOptions.Tag);
                }

                //Export
                if (!string.IsNullOrEmpty(cmdOptions.Export))
                {
                    ExportTasks(cmdOptions.Export);
                    Console.WriteLine("Tasks exported to html");
                }

                //Print
                if (!string.IsNullOrEmpty(cmdOptions.Print))
                    PrintTasks(cmdOptions.Print);

            }
            else
                Console.WriteLine(cmdOptions.Help());
        }

        static void PrintTasks(string taskStatus)
        {
            Filter(taskStatus);
            tasksList.PrintConsole();
        }

        static void ExportTasks(string taskStatus)
        {
            Filter(taskStatus);
            tasksList.Reset();
            htmlDocument.Save(tasksList);
        }

        static void FindTasks(string searchAftername, string taskStatus)
        {
            Filter(taskStatus);
            tasksList.Filter(searchAftername);
            tasksList.PrintConsole();
        }

        static void FindTag(string tag)
        {
            tasksList.FilterTag(tag);
            tasksList.PrintConsole();
        }

        private static void Filter(string taskStatus)
        {
            switch (taskStatus)
            {
                case "open":
                    tasksList.Filter(true);
                    break;
                case "done":
                    tasksList.Filter(false);
                    break;
                default:
                    break;
            }
        }
    }
}
