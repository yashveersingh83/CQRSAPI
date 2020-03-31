using API2.Utils.DAL.Interface;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Utils.DAL.Implementation
{
   
    public sealed class CourseRepository: ICourseRepository
    {
        private readonly SchoolContext _schoolContext;

        public CourseRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        Task<List<Course>> ICourseRepository.GetAll()
        {
            return Task.FromResult (_schoolContext.Courses.ToList());
        }

        Task<Course> ICourseRepository.GetById(long courseId)
        {
            return Task.FromResult(_schoolContext.Courses.FirstOrDefault(x => x.CourseID == courseId));
        }
    }

}
