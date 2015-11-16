using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class ID
    {
        private int id;

        public ID (int startValue)
        {
            this.id = startValue;
        }
        
        public ID()
        {
            this.id = 1;
        }

        public int NextValue()
        {
            int temp = this.id;
            this.id++;
            return temp;
        }

    }
}
