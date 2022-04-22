namespace EmployeesEdit.Models.Request
{
    public class EmployeeEditRequest
    {
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public int IdProfile { get; set; }
    }
}
