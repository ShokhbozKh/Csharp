using System;

namespace Exercise_14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            Task t2 = new Task("Wash the dishes!");
            Task t1 = new Task("Walk the dog!", t2);
            t2.SetNextTask(new Task("Clean the room!"));
            Task head = new Task("Get rest!", t1);

            head.PrintTasks();
            Console.WriteLine();
            head.PrintTasksRev();
            Console.WriteLine();

            Console.WriteLine();
            Task.PrintTasks(head);
            Console.WriteLine();
            Task.PrintTasksRev(head);
            Console.WriteLine();

            #endregion
        }
    }
}
