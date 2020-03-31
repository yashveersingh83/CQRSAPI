using API2.Dto;
using DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API2.Utils.DAL.Interface
{
    public interface ICourseRepository
    {
        public Task<List<Course>> GetAll();
        public Task<Course> GetById(long courseId);
    }

    public interface IEnrollmentRepository
    {
        public List<Enrollment> GetByStudentId(long studentId);
        public List<Enrollment> GetByCourseId(long courseId);
    }

    public interface IStudentRepository
    {
        public Student GetById(long id);
        public IReadOnlyList<Student> GetList(string enrolledIn, int? numberOfCourses);
        public List<StudentDto> GetStudentsWithCourseDetails();

        public void Update(Student student);
    }
}
