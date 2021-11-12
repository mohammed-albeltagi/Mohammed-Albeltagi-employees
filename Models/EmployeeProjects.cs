using System;

namespace Mohammed_Albeltagi_employees
{
    class EmployeeProjects
    {
        public EmployeeProjects(string empID, string projectID, string dateFrom, string dateTo)
        {
            EmpID = int.Parse(empID);
            ProjectID = int.Parse(projectID);
            DateFrom = Helper.ConvertToDateTime(dateFrom);
            DateTo = dateTo.ToLower().Contains("null") ? DateTime.Now: Helper.ConvertToDateTime(dateTo); ;
        }
        public int EmpID { get; private set; }
        public int ProjectID { get; private set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
    }
}
