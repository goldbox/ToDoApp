using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    public class TxtDocument
    {
        private string path;

        public TxtDocument (string path)
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
                sw.WriteLine(task.ID + "," + task.IsOpen + "," + task.Name.Replace('\n', '#'));
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
                int id = Int32.Parse(taskSettings[0]);
                bool openTask = (taskSettings[1] == "True");
                toDoList.Add(new Task(id, openTask, taskSettings[2]));
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
