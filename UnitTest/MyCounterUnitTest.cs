using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp;
using Should;

namespace UnitTest
{
    [TestClass]
    public class MyCounterUnitTest
    {
        [TestMethod]
        public void CounterStartFrom1()
        {
            MyCounter counter = new MyCounter();
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
            MyCounter counter = new MyCounter(n);
            for (int i = n; i <= (n + 15); i++)
            {
                i.ShouldEqual(counter.NextValue());
            }
        }

    }
}
