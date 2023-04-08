// See https://aka.ms/new-console-template for more information
using HRAdministration;
using static Program;

internal class Program
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    private static void Main(string[] args)
    {
        decimal totalSalaries = 0;

        List<IEmployee> employees = new List<IEmployee>();

        SeedData(employees);

        //foreach (IEmployee employee in employees)
        //{
        //    totalSalaries += employee.Salary;
        //}
        //Console.WriteLine($" Total Annual Salaries (including bonus): {totalSalaries}");

        Console.WriteLine($" Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)}");

        Console.ReadKey();

    }
    public static void SeedData(List<IEmployee> employees)
    {
        IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1,"Aysha", "Seck", 40000);

        employees.Add(teacher1);

        IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Assia", "Seck", 40000);

        employees.Add(teacher2);

        IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Dado", "Konte", 50000);

        employees.Add(headOfDepartment);

        IEmployee DeputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Babacar", "Seck", 50000);

        employees.Add(DeputyHeadMaster);

        IEmployee HeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);

        employees.Add(HeadMaster);
    }



    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }


    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }


    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.43m); }
    }


    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }

    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee? employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    //    new Teacher
                    //{
                    //    Id = id,
                    //    FirstName = firstName,
                    //    LastName = lastName,
                    //    Salary = salary
                    //};
                    break;

                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    // new HeadOfDepartment
                    //{
                    //    Id = id,
                    //    FirstName = firstName,
                    //    LastName = lastName,
                    //    Salary = salary
                    //};
                    break;

                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    // new DeputyHeadMaster
                    //{
                    //    Id = id,
                    //    FirstName = firstName,
                    //    LastName = lastName,
                    //    Salary = salary
                    //};
                    break;

                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    //    new HeadMaster
                    //{
                    //    Id = id,
                    //    FirstName = firstName,
                    //    LastName = lastName,
                    //    Salary = salary
                    //}; ;
                    break;

            }

            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName; 
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return employee;
        }
    }

}


