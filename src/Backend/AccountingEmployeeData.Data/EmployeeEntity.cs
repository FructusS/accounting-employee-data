using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccountingEmployeeData.Data
{
    public class EmployeeEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Date Birthday { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }
    }
}