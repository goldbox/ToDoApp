using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp;
using Should;

namespace UnitTest
{
    [TestClass]
    public class IDUnitTest
    {
        [TestMethod]
        public void CounterStartFrom1()
        {
            ID counter = new ID();
            int index = 15;
            for (int i = 1; i<= index; i++)
            {
                i.ShouldEqual(counter.NextValue());
            }
        }

        [TestMethod]
        public void CounterStartFromN()
        {
            int n = 976;
            ID counter = new ID(n);
            for (int i = n; i <= (n + 15); i++)
            {
                i.ShouldEqual(counter.NextValue());
            }
        }

    }
}
