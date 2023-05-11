using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine($"The sum of all your numbers is {numbers.Sum()}");

            //TODO: Print the Average of numbers

            Console.WriteLine($"The average number is {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console

            var sortedUp = numbers.OrderBy(x => x);

            Console.WriteLine($"Here is a list of your numbers in ascending order");
            foreach (int num in sortedUp)
            {
                Console.WriteLine($"{num}");
            }

            //TODO: Order numbers in decsending order and print to the console
            var sortedDown = numbers.OrderByDescending(num => num);

            Console.WriteLine("Below the list of numbers will be sorted in a decending order");
            foreach (int num in sortedDown)
            {
                Console.WriteLine($"{num}");
            }

            //Jeremy's lecture
            Console.WriteLine("The same thing but done smarter");
           numbers.OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);


            //TODO: Print to the console only the numbers greater than 6

            var greaterThan6 = numbers.OrderBy(x => x);

            Console.WriteLine("These numbers are lower then 6");
            numbers.Where(x => x > 6).ToList().ForEach(Console.WriteLine);


            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var any4 = numbers.OrderByDescending(num => num);

            Console.WriteLine("Below the list of numbers will be sorted in a decending order");

            foreach (int num in any4.Take(4))
            {
                Console.WriteLine($"{num}");
            }


            //TODO: Change the value at index 4 to your age then print the numbers in decsending order
            numbers.SetValue(30, 4);

            Console.WriteLine("4 to Age");
            numbers.ToList().ForEach(Console.WriteLine);


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            //If is a selction statement, not a loop statement.
            Console.WriteLine("These are the employees with names that start with C and S");

            employees.Where(emp => emp.FirstName[0] == 'C' || emp.FirstName[0] == 'S')
                .OrderBy(emp => emp.FirstName)
                .ToList()
                .ForEach(emp => Console.WriteLine(emp.FullName));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("These are the employees with that are older then 26");

            employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age)
                .ThenBy(emp => emp.FirstName)
                .ToList().ForEach(emp => Console.WriteLine($"{emp.FirstName} is {emp.Age}"));

            //
            //Jeremy's lecture
            var twentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            Console.WriteLine(">26");
            foreach (var emp in twentySix)
            {
                Console.WriteLine($"{emp.FullName} Age: {emp.Age}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("These are the employees that have been working for 10 tto 35 years.");

            employees.Where(emp => emp.YearsOfExperience <= 10 || emp.YearsOfExperience > 35).ToList().ForEach(emp => Console.WriteLine($"{emp.FullName} has been working for {emp.YearsOfExperience}") );

            //
            //Jeremy's Lecture
            var sumAndYOE = employees.Where(emp => emp.YearsOfExperience <= 10 || emp.Age > 35);

            Console.WriteLine($"Total YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine("$Ave YOE: { sumAndYOE.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jeremy", "Huddleston", 30, 10)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
