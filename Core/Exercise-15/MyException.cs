using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_15
{
    [Serializable()]
    class MyException : Exception
    {

        public MyException(string message) : base(message)
        {
        }

        public void CountWords()
        {
        }
    }
}
