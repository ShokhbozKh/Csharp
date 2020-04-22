using Exercise_06.Models;
using System.Linq;
using System.Data.Entity;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Exercise_06.Models1;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Exercise_06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Emp> Emps { get; set; }
        public List<Dept> Depts { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //GetStudents();
            //Example3LazyLoadingWithN1Problem();
            //Example2LazyLoading();
            //LoadData();
            //Example();
            Example10UpdatingElement();
        }

        public void Example2LazyLoading()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var result = context.Students;

            foreach (var i in result)
            {
                string tmp = i.LastName;
            }
        }

        public void Example3LazyLoadingWithN1Problem()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var result = context
                        .Students
                        .Include(s => s.Study).Take(10);

            foreach (var i in result)
            {
                if (i.Study.Name == null)
                {
                    //...
                }
            }
        }

        public void Example4Collection()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var result = context.Studies.ToList();
            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example5Collection()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var result = context.Students
                .Where(s => s.LastName.StartsWith("K")) //LIKE K%
                .Include(s => s.Study)
                .ToList();

        }

        public void Example6SplitQuery()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var query = context.Students //Expr tree
                .Include(s => s.Study)
                .Where(s => s.LastName.StartsWith("K"));

            var query2 = query.OrderBy(s => s.LastName);

            var result = query2.ToList();
        }

        public void Example7SplitQueryWorsePerformance()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            IEnumerable<Student> query = context.Students.ToList();

            var query2 = query.Where(s => s.LastName.StartsWith("K"));

            var result = query2.ToList();
        }

        public void Example7AddingNewElement()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var newStudent = new Student()
                {
                    FirstName = "Someone",
                    LastName = "Someone",
                    Address = "Warsaw, ul. Koszykowa 86",
                    IdStudies = 1
                };

                context.Students.Add(newStudent);

                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example8AddingNewElement()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var newStudent = new Student()
                {
                    FirstName = "Andrzej2",
                    LastName = "Kowalski3",
                    Address = "Warsaw, ul. Koszykowa 86",
                    IdStudies = 1
                };


                var newStudies = new Study()
                {
                    IdStudies = 1
                };
                context.Studies.Attach(newStudies);

                newStudent.Study = newStudies;

                context.Students.Add(newStudent);
                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }

        }

        public void Example9RemovingElement()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var student = new Student
                {
                    IdStudent = 1,
                    LastName = "Sth"
                };

                context.Students.Attach(student);
                context.Entry<Student>(student).State = EntityState.Modified;
                context.SaveChanges(); //

            }
            catch (Exception exc)
            {
                int g = 0;
            }
        }

        public void Example10RemovingElement()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var stToRemove = new Student
                {
                    IdStudent = 1
                };

                context.Students.Attach(stToRemove);
                context.Students.Remove(stToRemove);

                context.SaveChanges();
            }
            catch (Exception exc)
            {
                int g = 0;
            }

        }

        public void Example10UpdatingElement()
        {
            try
            {
                var context = new DbModel();
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var stToRemove = new Student
                {
                    IdStudent = 3,
                    FirstName = "Changed",
                    LastName = "Changed",
                    IdStudies = 1,
                    Address = "a"
                };

                context.Students.Attach(stToRemove);
                var entry = context.Entry<Student>(stToRemove);
                entry.State = EntityState.Modified;

                context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                int g = 0;
            }

        }

        public void Example11AddingMultipleElements()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var newSt = new Study
            {
                Name = "NOWY"
            };

            var newStudent = new Student
            {
                FirstName = "A",
                LastName = "B",
                Address = "C",
                Study = newSt
            };

            context.Students.Add(newStudent);
            context.SaveChanges();
        }

        public void Example12AExplicitLoading()
        {
            var context = new DbModel();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var student = context.Students.First();

            context.Entry(student).Reference(s => s.Study).Load();

            int g = 0;
        }

        public void LoadData()
        {
            Emps = new List<Emp>();
            Depts = new List<Dept>();

            Emps.Add(new Emp
            {
                Empno = 7369,
                Ename = "SMITH",
                Job = "CLERK",
                Mgr = 7902,
                HireDate = new DateTime(1980, 12, 17),
                Sal = 800,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7499,
                Ename = "ALLEN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 20),
                Sal = 1600,
                Comm = 300,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7521,
                Ename = "WARD",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 22),
                Sal = 1250,
                Comm = 500,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7566,
                Ename = "JONES",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 4, 2),
                Sal = 2975,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7654,
                Ename = "MARTIN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 28),
                Sal = 1250,
                Comm = 1400,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7698,
                Ename = "BLAKE",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 5, 1),
                Sal = 2850,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7782,
                Ename = "CLARK",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 6, 9),
                Sal = 2450,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7788,
                Ename = "SCOTT",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1982, 12, 9),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7839,
                Ename = "KING",
                Job = "PRESIDENT",
                Mgr = null,
                HireDate = new DateTime(1981, 11, 17),
                Sal = 5000,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7844,
                Ename = "TURNER",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 8),
                Sal = 1500,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7876,
                Ename = "ADAMS",
                Job = "CLERK",
                Mgr = 7788,
                HireDate = new DateTime(1983, 1, 12),
                Sal = 1100,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7900,
                Ename = "JAMES",
                Job = "CLERK",
                Mgr = 7698,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 950,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7902,
                Ename = "FORD",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7934,
                Ename = "MILLER",
                Job = "CLERK",
                Mgr = 7782,
                HireDate = new DateTime(1982, 1, 23),
                Sal = 1300,
                Comm = 0,
                Deptno = 10
            });

            Depts.Add(new Dept
            {
                Deptno = 10,
                Dname = "ACCOUNTING",
                Loc = "NEW YORK"
            });

            Depts.Add(new Dept
            {
                Deptno = 20,
                Dname = "RESEARCH",
                Loc = "DALLAS"
            });

            Depts.Add(new Dept
            {
                Deptno = 30,
                Dname = "SALES",
                Loc = "CHICAGO"
            });

            Depts.Add(new Dept
            {
                Deptno = 40,
                Dname = "OPERATIONS",
                Loc = "BOSTON"
            });
        }

        private void Example()
        {
            //Query syntax
            var result = from e in Emps
                         where e.Ename.StartsWith("K")
                         select e;

            //Lambda and Extension methods syntax
            var result2 = Emps.Where(e => e.Ename.StartsWith("K"));


            DataGrid.ItemsSource = result.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = Emps.OrderBy(s => s.Ename);

            var result1 = (from emp in Emps
                           orderby emp.Ename
                           select emp).ToList();


            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .OrderBy(s => s.Deptno)
                .OrderByDescending(s => s.Sal);

            var result1 = (from emp in Emps
                          orderby emp.Deptno
                          orderby emp.Sal
                          descending
                          select emp).ToList();

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Select(s => new { s.Ename, s.Job, s.Empno, s.Deptno })
                .Where(s => s.Job.Equals("CLERK"));

            var result1 = (from emp in Emps
                           where emp.Job.Equals("CLERK")
                           select new
                           {
                               emp.Ename,
                               emp.Job,
                               emp.Empno
                           });

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Ename.StartsWith("S"));

            var result1 = from emp in Emps
                          where emp.Ename.StartsWith("S")
                          select emp;

            DataGrid.ItemsSource = result1;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Mgr is null);

            var result1 = from emp in Emps
                          where emp.Mgr is null
                          select emp;

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => (s.Sal < 1000) || (s.Sal > 2000))
                .OrderBy(s => s.Sal);

            var result1 = from emp in Emps
                          where (emp.Sal < 1000) || (emp.Sal > 2000)
                          orderby emp.Sal
                          select emp;

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Select(s => new { result = $"{s.Ename} works for department {s.Deptno}" });

            var result1 = from emp in Emps
                          select new
                          {
                              result = $"{emp.Ename} works for department {emp.Deptno}"
                          };

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Job.Equals("CLERK") && (s.Sal < 2000 && s.Sal > 1000));

            var result1 = from emp in Emps
                          where emp.Job.Equals("CLERK") && emp.Sal < 2000 && emp.Sal > 1000
                          select emp;

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Job.Equals("CLERK") || (s.Sal < 2000 && s.Sal > 1000))
                .OrderBy(s => s.Job)
                .ThenBy(s => s.Sal);

            var result1 = from emp in Emps
                          where emp.Job.Equals("CLERK") || (emp.Sal < 2000 && emp.Sal > 1000)
                          orderby emp.Job, emp.Sal
                          select emp;


            DataGrid.ItemsSource = result;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => (s.Job.Equals("MANAGER") && s.Sal > 1500) || (s.Job.Equals("SALESMAN")))
                .OrderBy(s => s.Job)
                .ThenBy(s => s.Sal);

            var result1 = from emp in Emps
                         where (emp.Job.Equals("MANAGER") && emp.Sal > 1500) || emp.Job.Equals("SALESMAN")
                         orderby emp.Job, emp.Sal
                         select emp;

            DataGrid.ItemsSource = result1;

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Join(Depts, s => s.Deptno, r => r.Deptno, (s, r) => new 
                { 
                    s.Ename, s.Job, s.Sal, s.Deptno, s.Mgr, s.Comm, r.Dname, r.Loc 
                })
                .OrderBy(s => s.Deptno)
                .ThenBy(s => s.Sal);

            var result1 = from emp in Emps
                          join dept in Depts on emp.Deptno equals dept.Deptno
                          orderby emp.Deptno, emp.Sal
                          select new
                          {
                              emp.Empno,
                              emp.Ename,
                              emp.Mgr,
                              emp.Sal,
                              emp.Comm,
                              emp.Deptno,
                              dept.Dname,
                              dept.Loc
                          };
                          


            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Join(Depts, s => s.Deptno, r => r.Deptno, (s, r) => new { s.Ename, r.Deptno, r.Dname })
                .OrderBy(s => s.Deptno)
                .ThenBy(s => s.Ename);

            var result1 = from emp in Emps
                          join dept in Depts on emp.Deptno equals dept.Deptno
                          orderby dept.Deptno, emp.Ename
                          select new
                          {
                              emp.Ename,
                              dept.Deptno,
                              dept.Dname
                          };

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Sal > 1500)
                .Join(Depts, s => s.Deptno, d => d.Deptno, (s, d) => new
                {
                    s.Ename,
                    d.Loc,
                    d.Dname
                });

            var result1 = from emp in Emps
                          where emp.Sal > 1500
                          join dept in Depts on emp.Deptno equals dept.Deptno
                          orderby emp.Ename, dept.Dname
                          select new
                          {
                              emp.Ename,
                              dept.Loc,
                              dept.Dname
                          };

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            var result = Depts
                .Where(d => d.Loc.Equals("DALLAS"))
                .Join(Emps, d => d.Deptno, s => s.Deptno, (d, s) => new
                {
                    s.Ename,
                    s.Empno,
                    s.Sal,
                    s.Comm,
                    s.Mgr,
                    s.Deptno,
                    d.Loc
                })
                .OrderBy(s => s.Ename)
                .ThenBy(s => s.Loc);

            var result1 = from emp in Emps
                          join dept in Depts on emp.Deptno equals dept.Deptno
                          where dept.Loc.Equals("DALLAS")
                          orderby emp.Ename, dept.Loc
                          select new
                          {
                              emp.Ename,
                              emp.Empno,
                              emp.Sal,
                              emp.Comm,
                              emp.Mgr,
                              emp.Deptno,
                              dept.Loc
                          };

            DataGrid.ItemsSource = result1;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Average(s => s.Sal).ToString();

            DataGrid.ItemsSource = result;
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Job.Equals("CLERK"))
                .GroupBy(s => s.Job)
                .Select(r => new
                {
                    Job = r.Key,
                    MinSal = r.Min(s => s.Sal)
                }).ToList();


            DataGrid.ItemsSource = result;
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Deptno == 20)
                .GroupBy(s => s.Deptno)
                .Select(r => new
                {
                    department = r.Key,
                    employees = r.Count()
                }).ToList();

            DataGrid.ItemsSource = result;
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .GroupBy(s => s.Job)
                .Select(r => new
                {
                    job = r.Key,
                    sal = r.Average(s => s.Sal)
                }).ToList();

            DataGrid.ItemsSource = result;
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .GroupBy(s => s.Job)
                .Select(s => new
                {
                    average = s.Average(r => r.Sal)
                }).ToList();



            DataGrid.ItemsSource = result;
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(d => !d.Job.Equals("MANAGER"))
                .GroupBy(s => s.Job)
                .Select(r => new
                {
                    g = r.Key,
                    average = r.Average(s => s.Sal)
                }).ToList();

            DataGrid.ItemsSource = result;
        }
        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .Where(s => s.Sal == Emps.Min(r => r.Sal))
                .Select(s => new
                {
                    empno = s.Empno,
                    name = s.Ename,
                    mgr = s.Mgr,
                    job = s.Job,
                    deptno = s.Deptno,
                    salary = s.Sal
                }).ToList();

            var result1 = (from emp in Emps
                           where emp.Sal == ((from emp1 in Emps
                                              select emp1.Sal).Min())
                           select emp).ToList();

           DataGrid.ItemsSource = result1;
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            var job = Emps
                .Where(s => s.Ename.Equals("BLAKE"))
                .Select(r => r.Job)
                .First();

            var result = Emps
                .Where(s => s.Job.Equals(job))
                .ToList();


            var result1 = (from emp in Emps
                           where emp.Job.Equals ( (from emp1 in Emps
                                                   where emp1.Ename.Equals("BLAKE")
                                                   select emp1.Job).First()
                                                   )
                           select emp)
                           .ToList();

            DataGrid.ItemsSource = result1.ToList();
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            var result = Emps
                .GroupBy(g => g.Deptno)
                .Select(r => new
                {
                    Department = r.Key,
                    Salary = r.Min(s => s.Sal)
                }).ToList();

            var result1 = (from emp in Emps
                           group emp by emp.Deptno into g
                           select new
                           {
                               Deptno = g.Key,
                               Sal = g.Min(ms => ms.Sal)
                           }).ToList();


            DataGrid.ItemsSource = result1;

        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {

        }
    }
}
