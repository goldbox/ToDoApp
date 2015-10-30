using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp;
using System.Collections.Generic;
using Should;

namespace UnitTest
{
   

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddOneTask()
        {
            List<string> testList = new List<string>();
            string newLine = "new line";
            ToDoTasks test = new ToDoTasks(testList);
            test.AddTask(newLine);
            testList = test.Get();
            newLine.ShouldBeSameAs(testList[0]);
        }

        [TestMethod]
        public void TestIsEmptyMethod()
        {
            List<string> testList = new List<string>();
            ToDoTasks test = new ToDoTasks(testList);
            bool testIsEmpty = true;

            testIsEmpty.ShouldEqual(test.IsEmpty());

            string newLine = "new line";
            test.AddTask(newLine);
            testIsEmpty = false;
            testIsEmpty.ShouldEqual(test.IsEmpty());
        }

    }
}
