using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    public class HtmlDocument
    {
        string path;
        public HtmlDocument(string path)
        {
            this.path = path + ".html";
        }
        public void Save(ToDoTasks toDoList) 
        {
            StreamWriter sw = new StreamWriter(this.path, false);
            IncludeHeadHtml(sw, "To Do Tasks!");
            IncludeBodyHtml(toDoList, sw); 
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

        private static void IncludeBodyHtml(ToDoTasks toDoList, StreamWriter sw) 
        {
            sw.WriteLine("<body>");
            sw.WriteLine("<table>");

            sw.WriteLine("Here are your exported tasks:");
            sw.WriteLine("<tr><td>ID</td><td>Is Open</td><td>Description</td></tr>");
            foreach (Task task in toDoList)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>{0}</td>", task.ID);
                sw.WriteLine("<td>{0}</td>", task.IsOpen);
                sw.WriteLine("<td>{0}</td>", task.Name);
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
        }


    }
}
