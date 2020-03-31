using API2.Utils.DAL.Interface;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace API2.Utils.DAL.Implementation
{

   
    public sealed class  EnrollmentRepository:IEnrollmentRepository
    {
        private readonly SchoolContext _schoolContext;

        public EnrollmentRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
              

        public List<Enrollment> GetByStudentId(long studentId)
        {
            return _schoolContext.Enrollments.
                Where(x => x.StudentID == studentId)
                .ToList();
        }

        public List<Enrollment> GetByCourseId(long courseId)
        {
            return _schoolContext.Enrollments.
               Where(x => x.StudentID == courseId)
               .ToList();
        }
    }

}
