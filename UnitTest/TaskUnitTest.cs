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
            Task testNewTask = new Task(testString);

            testString.ShouldEqual(testNewTask.Name);
        }

        [TestMethod]
        public void AddANewTaskStatus()
        {
            string testString = "This is a test!";
            bool defaultStatus = true;
            Task testNewTask = new Task(testString);

            defaultStatus.ShouldEqual(testNewTask.TaskStatus);
        }

        [TestMethod]
        public void AddANewTaskWithStatusInput()
        {
            string testString = "This is a test!";
            bool inputStatus = false;
            Task testNewTask = new Task(inputStatus, testString);

            inputStatus.ShouldEqual(testNewTask.TaskStatus);
        }

        [TestMethod]
        public void SetTaskStatus()
        {
            string testString = "This is a test!";
            bool testStatus = false;
            Task testNewTask = new Task(testString);
            testNewTask.SetTaskStatus(testStatus);

            testStatus.ShouldEqual(testNewTask.TaskStatus);
        }


    }
}
