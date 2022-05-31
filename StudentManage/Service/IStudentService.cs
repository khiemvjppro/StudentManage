using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManage.Model;
using StudentManage.ViewModel;

namespace StudentManage.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<int> Create(StudentVm student);
        Task<bool> Delete(int id);
    }
}