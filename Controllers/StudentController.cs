using API2.Dto;
using API2.Dtos;
using API2.Utils;
using API2.Utils.DAL.Implementation;
using API2.Utils.DAL.Interface;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : BaseController
    {

        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentController(IStudentRepository studentRepository , ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;

            _courseRepository= courseRepository;
        }

        [HttpGet]
        [Route("CourseDetails")]
        public IActionResult GetList(string courseName, int? studentId)
        {
            var result = _studentRepository.GetList(courseName, studentId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Courses")]
        public IActionResult Get()
        {
           var result = _studentRepository.GetStudentsWithCourseDetails();
            return Ok(result);
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult GetById(long studentId)
        {
            var result = _studentRepository.GetById(studentId);
            return Ok(result);
        }

        [HttpPut()]
        [Route("updatestudentInfo")]
        public IActionResult EditPersonalInfo([FromBody] StudentPersonalInfoDto studentDto)
        {
            var student = _studentRepository.GetById(studentDto.StudentId);
            if (student == null)
                return Error($"Student not present");
            student.FirstMidName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            _studentRepository.Update(student);
            return Ok($" Student information successfully updated ");

        }

        [HttpPost]
        [Route("enrollments/unregistercourse")]
        public IActionResult DisEnroll([FromBody] StudentDisenrollmentDto studentDto)
        {

            var student = _studentRepository.GetById(studentDto.StudentId);
            if (student == null)
                return Error($"Student not present");
            var enrollment = student.Enrollments.FirstOrDefault(e => e.EnrollmentID == studentDto.EnrollmentNumber);
            if(enrollment==null)
                return Error($"Student not enrollent to this course");
            student.Enrollments.Remove(enrollment);
            _studentRepository.Update(student);
            return Ok($" Student disenrolled successfully from this course. " );
        }

        [HttpPost]
        [Route("editpersonalinformation")]
        public IActionResult UpdateInformation([FromBody] StudentPersonalInfoDto studentDto)
        {

            var student = _studentRepository.GetById(studentDto.StudentId);
            if (student == null)
                return Error($"Student not present");
            student.FirstMidName = studentDto.FirstName;
            student.LastName = studentDto.LastName;           
            _studentRepository.Update(student);
            return Ok($" Student personal inforamtion editted successfully from this course. ");
        }

        [HttpPost]
        [Route("transferCourse")]
        public IActionResult UpdateStudentCourse([FromBody] StudentCourseTransferDto studentDto)
        {

            var student = _studentRepository.GetById(studentDto.StudentId);
            if (student == null)
                return Error($"Student not present");
           var enrollment = student.Enrollments.FirstOrDefault(e => e.CourseID == studentDto.CurrentCourseID);
            if (enrollment == null)
                return Error($"Student not enrollent to this course");
            enrollment.CourseID = studentDto.NewCourseID;
            _studentRepository.Update(student);
            return Ok($" Student personal inforamtion editted successfully from this course. ");
        }





    }
}