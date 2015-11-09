using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ToDoApp;
using Should;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TxtWorkerUnitTest
    {
        [TestMethod]
        public void InitialiseMethod()
        {
            string path = Path.GetFullPath("ToDoAppTaskListTest");
            TxtWorker testTxtWorker = new TxtWorker(path);
            path += ".txt";
            File.Delete(path);
            testTxtWorker.Initialize();
            
            true.ShouldEqual(File.Exists(path));
            File.Delete(path);
        }

        [TestMethod]
        public void SaveLoadMethods()
        {
            List<Task> appList;
            ToDoTasks appTaskList;
            GetDataFromMainDatabaseFile(out appList, out appTaskList);

            List<Task> actualAppList = GetListUsingSaveAndLoad(appTaskList);

            int n = appList.Count;
            for (int i = 0; i < n; i++)
                CollectionAssert.Equals(appList[i], actualAppList[i]);
        }

        private static List<Task> GetListUsingSaveAndLoad(ToDoTasks appTaskList)
        {
            string path = Path.GetFullPath("ToDoAppListSaveLoadTest");
            TxtWorker testTxtWorker = new TxtWorker(path);
            path += ".txt";
            File.Delete(path);
            testTxtWorker.Save(appTaskList);
            List<Task> actualAppList = testTxtWorker.Load();
            return actualAppList;
        }

        private static void GetDataFromMainDatabaseFile(out List<Task> appList, out ToDoTasks appTaskList)
        {
            string appPath = Path.GetFullPath("appPath");
            appPath = appPath.Substring(0, appPath.Length - 26);
            appPath += @"ToDoApp\bin\Debug\ToDoAppTasksList";
            TxtWorker appTxtWorker = new TxtWorker(appPath);
            appList = appTxtWorker.Load();
            appTaskList = new ToDoTasks(appList);
        }
    }
}
