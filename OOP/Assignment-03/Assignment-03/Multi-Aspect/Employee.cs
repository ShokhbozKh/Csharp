using System;

namespace Assignment_03
{
    abstract partial class Employee : User
    {
        private WorkMode _workMode;
        public WorkMode WorkMode 
        {
            get => _workMode;
            set
            {
                _workMode = value ?? throw new ArgumentNullException();
            }
        }

        public Employee(string login, string password, string firstName, string lastName, WorkMode workMode)
            : base(login, password, firstName, lastName)
        {
            WorkMode = workMode;
        }
    }
}
