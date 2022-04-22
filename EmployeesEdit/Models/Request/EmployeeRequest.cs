namespace EmployeesEdit.Models.Request
{
    public class EmployeeRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdEmployee { get; set; }
        public int IdProfile { get; set; }
        public bool Status { get; set; }
        public string Login { get; set; }
    }
}
