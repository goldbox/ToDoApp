using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    class TxtWorker
    {
        private string path = "ToDoAppTasksList.txt";
        public string Path
        {
            get { return this.path; }
        }
        public void Initialize()
        {
            if (!File.Exists(Path))
            {
                Stream sr = new FileStream(Path, FileMode.CreateNew, FileAccess.ReadWrite);
                sr.Close();
            }
            else
                return;
        }
        public void Save (ToDoTasks toDoList)
        {
            StreamWriter sw = new StreamWriter(Path); //?true
            foreach (Task task in toDoList)
            {
                sw.WriteLine(task.TaskStatus + "," + task.Name);
            }

            sw.Close();
        }

        public List<Task> Load()
        {
            List<Task> toDoList = new List<Task>();
            Initialize();
            string line;
            StreamReader sr = new StreamReader(Path);
            while ((line = sr.ReadLine()) != null)
            {
                string[] taskSettings = GiveMeTaskSettings(line);
                bool openTask = (taskSettings[0] == "True") ? true : false;
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
