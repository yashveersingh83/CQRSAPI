using API2.Utils;
using API2.Utils.DAL.Implementation;
using API2.Utils.DAL.Interface;
using DAL;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using API2.Queries;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ICourseRepository _courseRepository;
        IMediator _mediator;
        public CourseController(ICourseRepository courseRepository, IMediator mediator)
        {
            _courseRepository = courseRepository;
            _mediator = mediator;
        }        
      
        [HttpGet]
        [Route("Courses")]
        public IActionResult GetList()
        {
            var result =  _mediator.Send(new GetCoursesQuery()).Result;
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(long courseId)
        {
            var result = _courseRepository.GetById(courseId);
            return Ok(result);
        }




    }
}