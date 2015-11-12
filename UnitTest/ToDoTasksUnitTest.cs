using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp;
using System.Collections.Generic;
using Should;

namespace UnitTest
{
    [TestClass]
    public class ToDoTasksUnitTest
    {
        [TestMethod]
        public void AddOneTask()
        {
            List<Task> emptyList = new List<Task>();
            ToDoTasks test = new ToDoTasks(emptyList);
            string newLine = "new line";
            test.AddTask(newLine);
            newLine.ShouldEqual(test.GetTask(0).Name);
        }

        [TestMethod]
        public void IsEmptyMethod()
        {
            List<Task> emptyList = new List<Task>();
            ToDoTasks test = new ToDoTasks(emptyList);
            bool testIsEmpty = true;

            testIsEmpty.ShouldEqual(test.IsEmpty());

            string newLine = "new line";
            test.AddTask(newLine);
            testIsEmpty = false;
            testIsEmpty.ShouldEqual(test.IsEmpty());
        }

        [TestMethod]
        public void ChangeTaskStatus()
        {
            List<Task> emptyList = new List<Task>();
            ToDoTasks test = new ToDoTasks(emptyList);
            string newLine = "new line";
            test.AddTask(newLine);
            test.ChangeTaskStatus(0, false);
            false.ShouldEqual(test.GetTask(0).IsOpen);
        }

        [TestMethod]
        public void Find()
        {
            List<Task> emptyList = new List<Task>();
            ToDoTasks test = new ToDoTasks(emptyList);
            string newLine = "new line";
            test.AddTask(newLine);
            newLine = "another line";
            test.AddTask(newLine);
            test.Find("new");

        }


    }
}
