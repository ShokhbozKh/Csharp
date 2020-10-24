using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Exercise_14
{
    class Task
    {
        private string descr;
        private Task next;

        public Task(string descr) => this.descr = descr;

        public Task(string descr, Task next) : this(descr) => this.next = next;

        public void SetNextTask(Task task) => next = task;
        
        public void PrintTasks()
        {
            Console.Write($"{descr} ");
            
            if(next is not null)
                next.PrintTasks();
        }

        public static void PrintTasks(Task head)
        {
            Console.Write($"{head.descr} ");

            if (head.next is not null)
                head.next.PrintTasks();
        }

        public void PrintTasksRev()
        {
            if (next is not null)
                next.PrintTasks();

            Console.Write($"{descr} ");
        }

        public static void PrintTasksRev(Task head)
        {
            if (head.next is not null)
                head.next.PrintTasksRev();

            Console.Write($"{head.descr} ");
        }
    }
}
