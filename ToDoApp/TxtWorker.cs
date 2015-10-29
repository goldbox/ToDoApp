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
            foreach (string line in toDoList)
            {
                sw.WriteLine(line);
            }

            sw.Close();
        }

        public List<string> Load()
        {
            List<string> toDoList = new List<string>();
            Initialize();
            string line;
            StreamReader sr = new StreamReader(Path);
            while ((line = sr.ReadLine()) != null)
            {
                toDoList.Add(line);
            }
            sr.Close();
            return toDoList;
        }

    }
}
