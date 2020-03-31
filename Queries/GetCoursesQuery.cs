using API2.Dtos;
using API2.Utils.DAL.Interface;
using DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Queries
{
    public class GetCoursesQuery:IRequest<List<Course>>    {       
        
    }
    public class GetCoursesbyIdQuery : IRequest<Course>
    {

    }
}
