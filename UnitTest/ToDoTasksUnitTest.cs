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
            test.GetEnumerator();
            test.MoveNext();
            newLine.ShouldEqual(test.Current);
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

    }
}
