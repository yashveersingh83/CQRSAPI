using API2.Dto;
using API2.Utils.DAL.Interface;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace API2.Utils.DAL.Implementation
{

   
    public sealed class StudentRepository: IStudentRepository
    {
        private readonly SchoolContext _schoolContext;

        public StudentRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Student GetById(long id)
        {
            return _schoolContext.Students
                .Include(c=> c.Enrollments)
                .FirstOrDefault(x => x.ID == id);
        }

        public IReadOnlyList<Student> GetList(string enrolledIn, int? numberOfCourses)
        {
            IQueryable<Student> query = _schoolContext.Students;

            if (!string.IsNullOrWhiteSpace(enrolledIn))
            {
                query = query.Where(x => x.Enrollments.Any(e => e.Course.Title == enrolledIn));
            }

            List<Student> result = query.ToList();

            if (numberOfCourses != null)
            {
                result = result.Where(x => x.Enrollments.Count == numberOfCourses).ToList();
            }

            return result;
        }

        public List<StudentDto> GetStudentsWithCourseDetails()
        {
            var studentList = new List<StudentDto>();
            //string sql = @"
            //        SELECT s.StudentID Id, s.Name, s.Email,
	           //         s.FirstCourseName Course1, s.FirstCourseCredits Course1Credits, s.FirstCourseGrade Course1Grade,
	           //         s.SecondCourseName Course2, s.SecondCourseCredits Course2Credits, s.SecondCourseGrade Course2Grade
            //        FROM dbo.Students s
                    
            //        ORDER BY s.StudentID ASC";

            //using (SqlConnection connection = new SqlConnection(_schoolContext.Database.GetDbConnection().ConnectionString))
            //{
                List<Student> students = _schoolContext.Students                                   
                                    .Include("Enrollments").Include("Enrollments.Course")           
                
                .ToList();

                foreach (var student in students)
                {
                    studentList.Add(
                        
                        new StudentDto {  
                        
                        FirstName = student.FirstMidName  ,
                        LastName =  student.LastName ,
                        Id = student.ID,
                        Email = student.Email,
                            Course2 = student.Enrollments ?.Count>=2 ? student.Enrollments?.ElementAt(1)?.Course?.Title:string.Empty,
                            Course2Credits = student.Enrollments?.Count >= 2 ?student.Enrollments?.ElementAt(1)?.Course.Credits:default(int?),
                            Course2Grade = student.Enrollments?.Count >= 2  ?student.Enrollments?.ElementAt(1)?.Grade.ToString():string.Empty,
                            Course2ID = student.Enrollments?.Count >= 2 ? student.Enrollments?.ElementAt(1)?.CourseID : default(int?),

                            Course1ID = student.Enrollments?.Count >= 2 ? student.Enrollments?.ElementAt(0)?.CourseID : default(int?),
                            Course1 = student.Enrollments?.Count >= 1 ? student.Enrollments?.ElementAt(0)?.Course?.Title : string.Empty,
                            Course1Credits = student.Enrollments?.Count >= 1 ? student.Enrollments?.ElementAt(0)?.Course.Credits : default(int?),
                            Course1Grade = student.Enrollments?.Count >= 1 ? student.Enrollments?.ElementAt(0)?.Grade.ToString() : string.Empty,

                        }

                        );
                }

                return studentList;
            //}
        }
        public void Update(Student student)
        {
            _schoolContext.Entry(student).State = EntityState.Modified;           

            _schoolContext.SaveChanges();

        }




    }

}
