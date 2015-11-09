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
            this.path = path + ".txt";
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
                sw.WriteLine(task.IsOpen + "," + task.Name.Replace('\n', '#'));
            }
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
