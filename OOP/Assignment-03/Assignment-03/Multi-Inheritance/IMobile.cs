using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03.Multi_Inheritance
{
    interface IMobile
    {
        public abstract void MakeCall(string phoneNumber);
        public abstract string GetSimcardNumber();
        
    }
}
