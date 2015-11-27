using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandLine;
using ToDoApp;
using Should;
using CommandLine.Text;

namespace UnitTest
{
    [TestClass]
    public class CommandOptionsUnitTest
    {
        [TestMethod]
        public void Add()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-a", "task one" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.Add.ShouldEqual("task one");
        }

        [TestMethod]
        public void Done()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-d", "1" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.DoneID.ShouldEqual(1);
        }

        [TestMethod]
        public void Find()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-f", "new task" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.Find.ShouldEqual("new task");
        }

        [TestMethod]
        public void FindWithTarget()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-f", "new task", "all" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.Find.ShouldEqual("new task");
            cmdOptions.SecondArgument.ShouldEqual("all");
        }

        [TestMethod]
        public void Edit()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-e", "1", "new task" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.SecondArgument.ShouldEqual("new task");
        }

        [TestMethod]
        public void Export()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-x", "done"};
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.TaskStatusToExport.ShouldEqual("done");
        }

        [TestMethod]
        public void MultipleArguments()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-a", "some task", "-d", "1", "-e", "1", "edited task", "-p", "done" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.Add.ShouldEqual("some task");
            cmdOptions.DoneID.ShouldEqual(1);
            cmdOptions.EditID.ShouldEqual(1);
            cmdOptions.SecondArgument.ShouldEqual("edited task");
            cmdOptions.TasksToPrint.ShouldEqual("done");
        }

        [TestMethod]
        public void MutualyExclusive()
        {
            CommandOptions cmdOptions = new CommandOptions();
            var parser = new Parser();
            string[] args = new string[] { "-e", "1", "edited task", "-f", "done" };
            true.ShouldEqual(parser.ParseArguments(args, cmdOptions));
            cmdOptions.EditID.ShouldEqual(1);
            cmdOptions.SecondArgument.ShouldEqual("edited task");
            cmdOptions.Find.ShouldEqual("done");
        }

    }
}
