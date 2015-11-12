using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp;
using Should;

namespace UnitTest
{
    [TestClass]
    public class TaskUnitTest
    {
        [TestMethod]
        public void AddANewTaskName()
        {
            string testString = "This is a test!";
            Task testNewTask = new Task(1, testString);

            testString.ShouldEqual(testNewTask.Name);
        }

        [TestMethod]
        public void AddANewTaskStatus()
        {
            string testString = "This is a test!";
            bool defaultStatus = true;
            Task testNewTask = new Task(1, testString);

            defaultStatus.ShouldEqual(testNewTask.IsOpen);
        }

        [TestMethod]
        public void AddANewTaskWithStatusInput()
        {
            string testString = "This is a test!";
            bool inputStatus = false;
            Task testNewTask = new Task(1, inputStatus, testString);

            inputStatus.ShouldEqual(testNewTask.IsOpen);
        }

        [TestMethod]
        public void SetTaskStatus()
        {
            string testString = "This is a test!";
            bool testStatus = false;
            Task testNewTask = new Task(1, testString);
            testNewTask.SetTaskStatus(testStatus);

            testStatus.ShouldEqual(testNewTask.IsOpen);
        }


    }
}
