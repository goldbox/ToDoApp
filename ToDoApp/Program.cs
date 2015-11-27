using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommandLine;

namespace ToDoApp
{
    public class Program
    {
        static string path = Path.GetFullPath("TasksList");
        static TxtDocument txtDocument = new TxtDocument(path);
        static HtmlDocument htmlDocument = new HtmlDocument(path);
        static ToDoTasks tasksList = txtDocument.Load();

        static void Main(string[] args)
        {
            Filter filter = new Filter(tasksList);
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();

            if (parser.ParseArguments(args, cmdOptions))
            {
                ConsoleOutput consoleOutput = new ConsoleOutput();

                //Add
                if (!string.IsNullOrEmpty(cmdOptions.Add))
                {
                    tasksList.AddTask(cmdOptions.Add);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task \"{0}\" added successfully", cmdOptions.Add);
                }

                //Done
                if (tasksList.IDExist(cmdOptions.DoneID))
                {
                    tasksList.ChangeTaskStatus(cmdOptions.DoneID, false);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task {0} set to done", cmdOptions.DoneID);
                }

                //Edit
                if (tasksList.IDExist(cmdOptions.EditID) && cmdOptions.SecondArgument != null)
                {
                    tasksList.ChangeTaskName(cmdOptions.EditID, cmdOptions.SecondArgument);
                    txtDocument.Save(tasksList);
                    Console.WriteLine("Task {0} modified", cmdOptions.EditID);
                } else 
                if (args.Contains("-e") || args.Contains("--edit"))
                {
                    Console.WriteLine("Cannot edit task {0}. Press -h for Help", cmdOptions.EditID);
                }

                //Find
                if (!string.IsNullOrEmpty(cmdOptions.Find))
                {
                    filter.ByStatus(cmdOptions.SecondArgument);
                    tasksList.Filter(cmdOptions.Find);
                    consoleOutput.Print(tasksList);
                }

                //Export
                if (!string.IsNullOrEmpty(cmdOptions.TaskStatusToExport))
                {
                    filter.ByStatus(cmdOptions.TaskStatusToExport);
                    tasksList.Reset();
                    htmlDocument.Save(tasksList);
                    Console.WriteLine("Tasks exported to html");
                }

                //Print
                if (!string.IsNullOrEmpty(cmdOptions.TasksToPrint))
                {
                    filter.ByStatus(cmdOptions.TasksToPrint);
                    consoleOutput.Print(tasksList);
                }

                //Find Tag
                //if (!string.IsNullOrEmpty(cmdOptions.Tag) && cmdOptions.Tag[0] == '#')
                //{
                //    FindTag(cmdOptions.Tag);
                //}

            } else
            {
                Console.WriteLine(cmdOptions.Help());
            }
        }
    }
}
