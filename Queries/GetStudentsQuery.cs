using DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Queries
{
    public class GetStudentsQuery:IRequest<List<Student>>
    {
    }
}
