using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class CreatedPostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public CreatedPostCommandResponse() : base()
        {

        }

        public CreatedPostCommandResponse(ValidationResult validationResult) : base(validationResult)
        {

        }
        public CreatedPostCommandResponse(string message) : base(message)
        {

        }
        public CreatedPostCommandResponse(string message, bool success) : base(message, success)
        {

        }
        public CreatedPostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
