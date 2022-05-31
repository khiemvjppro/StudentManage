using System.Threading.Tasks;
using StudentManage.Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentManage.ViewModel;

namespace StudentManage.Service
{
    public class StudentService : IStudentService
    {
        private readonly demoapiContext _context;
        public StudentService(demoapiContext context)
        {
            _context = context;
        }

        public async Task<int> Create(StudentVm student)
        {
            var studentCreate = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Gender = student.Gender,
                Phone = student.Phone,
                Course = student.Courses
            };
            await _context.Students.AddAsync(studentCreate);
            await _context.SaveChangesAsync();
            return studentCreate.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Student>> GetAll()
        {
            var query = await (from s in _context.Students
                               join c in _context.Courses on s.Course equals c.Id
                               select new Student()
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Age = s.Age,
                                   Gender = s.Gender,
                                   Phone = s.Phone,
                                   Course = c.Id
                               }).ToListAsync();
            return query;
        }
    }
}