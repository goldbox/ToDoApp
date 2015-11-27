using System;
using ToDoApp;
using Should;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class FilterUnitTest
    {
        [TestMethod]
        public void FilterOpen()
        {
            ToDoTasks test = new ToDoTasks();
            test.AddTask("first task open");
            test.AddTask("second task done");
            test.ChangeTaskStatus(2, false);

            Filter filter = new Filter(test);
            filter.ByStatus("open");
            false.ShouldEqual(test.IDExist(2));
        }

        [TestMethod]
        public void FilterNull()
        {
            ToDoTasks test = new ToDoTasks();
            test.AddTask("first task open");
            test.AddTask("second task done");
            test.ChangeTaskStatus(2, false);

            Filter filter = new Filter(test);
            filter.ByStatus("");
            false.ShouldEqual(test.IDExist(2));
        }

        [TestMethod]
        public void FilterDone()
        {
            ToDoTasks test = new ToDoTasks();
            test.AddTask("first task open");
            test.AddTask("second task done");
            test.ChangeTaskStatus(2, false);

            Filter filter = new Filter(test);
            filter.ByStatus("done");
            false.ShouldEqual(test.IDExist(1));
        }

        [TestMethod]
        public void FilterAll()
        {
            ToDoTasks test = new ToDoTasks();
            test.AddTask("first task open");
            test.AddTask("second task done");
            test.ChangeTaskStatus(2, false);

            Filter filter = new Filter(test);
            filter.ByStatus("all");
            true.ShouldEqual(test.IDExist(1));
            true.ShouldEqual(test.IDExist(2));
        }
    }
}
