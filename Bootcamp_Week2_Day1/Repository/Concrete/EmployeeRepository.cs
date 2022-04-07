using Bootcamp_Week2_Day1.Model;
using Bootcamp_Week2_Day1.Repository.Abstract;

namespace Bootcamp_Week2_Day1.Repository.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee(){Id=1,Name="Eren Tutkan",Address="ABC",City="İstanbul",Country="TR", DateOfBirth=DateTime.Today},
            new Employee(){Id=2,Name="Eren Tutkan",Address="ABC",City="İstanbul",Country="TR", DateOfBirth=DateTime.Today},

        };

        public void Delete(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            _employees.Remove(employee);
            
        }

        public Employee Get(int id)=>_employees.FirstOrDefault(x=>x.Id == id);

        public List<Employee> GetAll()=>_employees;

        public void Save(Employee newEmployee)=>_employees.Add(newEmployee);

        public void Update(Employee updateEmployee)
        {
            var employee = _employees.FindIndex(x => x.Id == updateEmployee.Id);
            _employees[employee]=updateEmployee; 
        }
    }
}
