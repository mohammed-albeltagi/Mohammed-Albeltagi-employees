using System;
using System.Collections.Generic;
using System.Linq;

namespace Mohammed_Albeltagi_employees
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetTeamMates();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static void GetTeamMates()
        {
            #region Properties
            List<EmployeeProjects> employeesProjects = new List<EmployeeProjects>();
            List<TeamMates> teamMates = new List<TeamMates>();
            #endregion

            // Read each line of the file into a string array.
            // Each element of the array is one line of the file.
            string[] fileLines = System.IO.File.ReadAllLines("Data//EmployeesProjects.txt");

            foreach (string line in fileLines)
            {
                employeesProjects.Add(new EmployeeProjects(line.Split(',')[0], line.Split(',')[1], line.Split(',')[2], line.Split(',')[3]));
            }

            // Group employees to each project.
            IEnumerable<IGrouping<int, EmployeeProjects>> projectsEmployees = employeesProjects.GroupBy(s => s.ProjectID);

            foreach (IGrouping<int, EmployeeProjects> projectEmployees in projectsEmployees)
            {
                for (int i = 0; i < projectEmployees.Count(); i++)
                {
                    for (int k = i + 1; k < projectEmployees.Count(); k++)
                    {
                        EmployeeProjects employee1 = projectEmployees.ElementAt(i);
                        EmployeeProjects employee2 = projectEmployees.ElementAt(k);

                        // Check if two employees worked with each other at the same time.
                        if ((employee1.DateTo <= employee2.DateTo && employee1.DateTo > employee2.DateFrom)
                            || (employee2.DateTo <= employee1.DateTo && employee2.DateTo > employee1.DateFrom))
                        {
                            // Get the start and end date that employees worked with each other.
                            DateTime startDate = employee1.DateFrom > employee2.DateFrom ? employee1.DateFrom : employee2.DateFrom;
                            DateTime endDate = employee1.DateTo < employee2.DateTo ? employee1.DateTo : employee2.DateTo;

                            // Calculate how many days employees work with each other.
                            int days = (int)Math.Ceiling((endDate - startDate).TotalDays);

                            string employeeIDs = $"{employee1.EmpID}-{employee2.EmpID}";

                            // Check if two employees worked with each other on other projects
                            if (teamMates.Any(a => a.EmployeeIDs == employeeIDs))
                            {
                                TeamMates teamMate = teamMates.Where(a => a.EmployeeIDs == employeeIDs).First();
                                teamMate.UpdateDays(days);
                                teamMate.UpdateProjectID(employee1.ProjectID);

                            }
                            else
                                teamMates.Add(new TeamMates(employee1.ProjectID.ToString(), days, employeeIDs));
                        }
                    }
                }
            }

            // Sort teammates that works with each other  for long time descending.
            teamMates = teamMates.OrderByDescending(a => a.Days).ToList();

            // Display the result on console window.
            Console.WriteLine("EmployeesId\tDays\tProjects");
            foreach (TeamMates item in teamMates)
            {
                Console.WriteLine($"{item.EmployeeIDs}\t\t{item.Days}\t{item.ProjectID}");
            }
        }
    }
}
