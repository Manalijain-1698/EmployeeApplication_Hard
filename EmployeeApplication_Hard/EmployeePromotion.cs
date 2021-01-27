using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication_Hard
{
    class EmployeePromotion
    {
        Employee emp = new Employee();                          //Object creation   
        List<Employee> emplist = new List<Employee>();          //empty emplist


        public void AddEmployee()                               // addemployee is a method for addinge employees details into emplist
                                                                  

        {
            int num = 1;

            while (num == 1)
            {

                emp.TakeEmployeeDetailsFromUser();
                emplist.Add(new Employee() { Id = emp.Id, Name = emp.Name, Age = emp.Age, Salary = emp.Salary });
                Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                num = Convert.ToInt32(Console.ReadLine());

            }

        }

        public void PrintAllEmployees()                           //Prints all employee details
        { 
            foreach (var i in emplist)                      
            {
                Console.WriteLine(i);
            }

        }

        public void ModifyEmployee(int EmpID,string empname,int empage,double empsalary)    //Updates employee details
        {
            var modify = emplist.Where(e => e.Id == EmpID);
            foreach(var i in modify)
            {
                
                i.Name = empname;
                i.Age = empage;
                i.Salary = empsalary;

            }
            

        }

        public List<Employee> PrintAnEmployeeDetail(int EmpId, List<Employee> emplist)    //Prints a paricular employee detail
        {
            return emplist.Where(e => e.Id == EmpId).ToList();

        }
        public void DisplayMenu()
        {
            bool value = true;
            while (value==true)
            {
                Console.WriteLine("Please enter the option");
                Console.WriteLine("1.Add an employee");
                Console.WriteLine("2. Modify an employee detail");
                Console.WriteLine("3. Print all employee's details");
                Console.WriteLine("4.Print an employee detail");
                Console.WriteLine("5.Exit");
                
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        Console.WriteLine("Please enter the employee ID");
                        int Empid = Convert.ToInt32(Console.ReadLine());
                        var employeedata = PrintAnEmployeeDetail(Empid, emplist);
                        employeedata.ForEach(x => Console.WriteLine(x + " "));
                        Console.WriteLine("Please enter the updated employee details");
                        Console.WriteLine("Please enter the employee name");
                        string empname = Console.ReadLine();
                        Console.WriteLine("Please enter the employee age");
                        int empage = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter the employee salary");
                        double empsalary = Convert.ToDouble(Console.ReadLine());

                        ModifyEmployee(Empid, empname, empage, empsalary);
                        break;
                    case 3:
                        PrintAllEmployees();
                        break;
                    case 4:
                        Console.WriteLine("Please enter the employee ID");
                        int EmpId = Convert.ToInt32(Console.ReadLine());
                        var empdata = PrintAnEmployeeDetail(EmpId, emplist);
                        empdata.ForEach(x => Console.WriteLine(x + " "));
                        break;
                    case 5:
                        value= false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;


                }
            }
        }

    

            static void Main(string[] args)
            {
                EmployeePromotion p1 = new EmployeePromotion();
                p1.DisplayMenu();


            }




        }
    }



