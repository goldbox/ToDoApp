using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ToDoApp;
using Should;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TxtDocumentUnitTest
    {
        [TestMethod]
        public void InitialiseMethod()
        {
            string path = Path.GetFullPath("TaskListTest");
            TxtDocument testTxtWorker = new TxtDocument(path);
            path += ".txt";
            File.Delete(path);
            testTxtWorker.Initialize();
            
            true.ShouldEqual(File.Exists(path));
            File.Delete(path);
        }

        [TestMethod]
        public void SaveLoadMethods()
        {
            ToDoTasks appTaskList = GetDataFromMainDatabaseFile();

            ToDoTasks actualAppList = GetListUsingSaveAndLoad(appTaskList);

            int n = appTaskList.GetCounth();
            for (int i = 0; i < n; i++)
                CollectionAssert.Equals(appTaskList.GetTask(i), actualAppList.GetTask(i));
        }

        private static ToDoTasks GetListUsingSaveAndLoad(ToDoTasks appTaskList)
        {
            string path = Path.GetFullPath("TaskListTest");
            TxtDocument testTxtWorker = new TxtDocument(path);
            path += ".txt";
            File.Delete(path);
            testTxtWorker.Save(appTaskList);
            ToDoTasks actualAppList = testTxtWorker.Load();
            return actualAppList;
        }

        private static ToDoTasks GetDataFromMainDatabaseFile() 
        {
            string appPath = Path.GetFullPath("appPath");
            appPath = appPath.Substring(0, appPath.Length - 26);
            appPath += @"ToDoApp\bin\Debug\ToDoAppTasksList";
            TxtDocument appTxtWorker = new TxtDocument(appPath);
            ToDoTasks appList = appTxtWorker.Load();
            return appList;
        }
    }
}
