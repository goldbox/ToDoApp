using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    public class HtmlWorker
    {
        string path;
        public HtmlWorker(string path)
        {
            this.path = path + ".html";
        }

        public void Save(ToDoTasks toDoList, string taskStatus = "open")
        {
            StreamWriter sw = new StreamWriter(this.path, false);
            IncludeHeadHtml(sw, "To Do Tasks!");
            IncludeBodyHtml(toDoList, sw, taskStatus);
            sw.Close();
        }

        private static void IncludeHeadHtml(StreamWriter sw, string title)
        {
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<title>{0}</title>", title);
            sw.WriteLine("</head>");
        }

        private static void IncludeBodyHtml(ToDoTasks toDoList, StreamWriter sw, string taskStatus)
        {
            sw.WriteLine("<body>");
            sw.WriteLine("<table>");
            int i = 0;
            switch (taskStatus)
            {
                case "done":
                    sw.WriteLine("Here are your finished tasks:");
                    sw.WriteLine("<tr><td>ID</td><td>Description</td></tr>");
                    foreach (Task task in toDoList)
                    {
                        i++;
                        if (!task.IsOpen)
                        {
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td>{0}</td>", i);
                            sw.WriteLine("<td>{0}</td>", task.Name);
                            sw.WriteLine("</tr>");
                        }
                    }
                    break;

                case "all":
                    sw.WriteLine("Here are all your tasks:");
                    sw.WriteLine("<tr><td>ID</td><td>Is Open</td><td>Description</td></tr>");
                    foreach (Task task in toDoList)
                    {
                        i++;
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td>{0}</td>", i);
                        sw.WriteLine("<td>{0}</td>", task.IsOpen);
                        sw.WriteLine("<td>{0}</td>", task.Name);
                        sw.WriteLine("</tr>");
                    }
                    break;

                default:
                    sw.WriteLine("Here are your opened tasks:");
                    sw.WriteLine("<tr><td>ID</td><td>Description</td></tr>");
                    foreach (Task task in toDoList)
                    {
                        i++;
                        if (task.IsOpen)
                        {
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td>{0}</td>", i);
                            sw.WriteLine("<td>{0}</td>", task.Name);
                            sw.WriteLine("</tr>");
                        }
                    }
                    break;
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
        }


    }
}
