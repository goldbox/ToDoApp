using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    public class TxtWorker
    {
        private string path;

        public TxtWorker (string path)
        {
            this.path = path;
        }

        public void Initialize()
        {
            if (!File.Exists(this.path))
            {
                Stream sr = new FileStream(this.path, FileMode.CreateNew, FileAccess.ReadWrite);
                sr.Close();
            }
            else
                return;
        }

        public void Save (ToDoTasks toDoList)
        {
            StreamWriter sw = new StreamWriter(this.path, false); 
            foreach (Task task in toDoList)
            {
                sw.WriteLine(task.TaskStatus + "," + task.Name.Replace('\n', '#'));
            }
            sw.Close();
        }

        public void SaveHtml (ToDoTasks toDoList)
        {
            string htmlPath = this.path;
            htmlPath = htmlPath.Substring(0, (htmlPath.Length - 3));
            htmlPath += "html";
            StreamWriter sw = new StreamWriter(htmlPath, false);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<title>To Do Tasks!</title>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<p>To Do Task List: </p>");
            sw.WriteLine("<table>");
            sw.WriteLine("<tr><td>Index</td><td>Is Open</td><td>Description</td></tr>");
            toDoList.Reset();
            int i = 0;
            foreach (Task task in toDoList)
            {
                i++;
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>{0}</td>", i);
                sw.WriteLine("<td>{0}</td>", task.TaskStatus);
                sw.WriteLine("<td>{0}</td>", task.Name.Replace('\n', '#'));
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body></html>");
            sw.Close();
        }

        public List<Task> Load()
        {
            List<Task> toDoList = new List<Task>();
            Initialize();
            string line;
            StreamReader sr = new StreamReader(this.path);
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Replace('#', '\n');
                string[] taskSettings = GiveMeTaskSettings(line);
                bool openTask = (taskSettings[0] == "True");
                toDoList.Add(new Task(openTask, taskSettings[1]));
            }
            sr.Close();
            return toDoList;
        }

        private string[] GiveMeTaskSettings(string line)
        {
            return line.Split(',');
        }
    }
}
