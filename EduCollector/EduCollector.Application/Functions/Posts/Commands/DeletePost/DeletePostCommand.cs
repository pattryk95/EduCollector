using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
