using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Filter
    {
        ToDoTasks tasksList;

        public Filter (ToDoTasks taskList)
        {
            this.tasksList = taskList;
        }
     
        public void ByStatus(string taskStatus)
        {
            switch (taskStatus)
            {
                case "open":
                    this.tasksList.Filter(true);
                    break;
                case "done":
                    tasksList.Filter(false);
                    break;
                case "all":
                    break;
                default:
                    tasksList.Filter(true);
                    break;
            }
        }
    }

}
