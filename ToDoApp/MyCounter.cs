using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class MyCounter
    {
        private int counter;

        public MyCounter (int startValue)
        {
            this.counter = startValue;
        }
        
        public MyCounter()
        {
            this.counter = 1;
        }

        public int NextValue()
        {
            int temp = this.counter;
            this.counter++;
            return temp;
        }

    }
}
