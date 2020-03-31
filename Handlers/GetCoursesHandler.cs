using API2.Dtos;
using API2.Queries;
using API2.Utils.DAL.Interface;
using DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API2.Handlers
{
    public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, List<Course>>
    {
        ICourseRepository _courseRepository;
        public GetCoursesHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Task<List<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
           return  _courseRepository.GetAll();
        }
    }

    public class GetCourseByIdHandler : IRequestHandler<GetCoursesbyIdQuery, Course>
    {
        ICourseRepository _courseRepository;
        private int _CourseId;
        public GetCourseByIdHandler(ICourseRepository courseRepository , int CourseId)
        {
            _courseRepository = courseRepository;
            _CourseId = CourseId;
        }
        public Task<Course> Handle(GetCoursesbyIdQuery request, CancellationToken cancellationToken)
        {
            return _courseRepository.GetById(_CourseId);
        }
       
    }


}
