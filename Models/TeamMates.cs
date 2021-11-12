
namespace Mohammed_Albeltagi_employees
{
    class TeamMates
    {
        public TeamMates(string projectID,
                         int days,
                         string employeeIDs)
        {
            ProjectID = projectID;
            Days = days;
            EmployeeIDs = employeeIDs;
        }
        public string ProjectID { get; private set; }
        public int Days { get; private set; }
        public string EmployeeIDs { get; private set; }

        public void UpdateDays(int days)
        {
            if (days > 0)
                Days += days;
        }

        public void UpdateProjectID(int projectID)
        {
            if (projectID > 0)
                ProjectID += $", {projectID}";
        }
    }
}
