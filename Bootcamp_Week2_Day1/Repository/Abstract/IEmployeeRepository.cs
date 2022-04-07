using Bootcamp_Week2_Day1.Model;

namespace Bootcamp_Week2_Day1.Repository.Abstract
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee Get(int id);
        void Save(Employee newEmployee);
        void Update(Employee updateEmployee);
        void Delete(int id);
    }
}
