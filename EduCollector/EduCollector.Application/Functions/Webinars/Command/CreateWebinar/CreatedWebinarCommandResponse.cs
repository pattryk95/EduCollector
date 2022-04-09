using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class CreatedWebinarCommandResponse : BaseResponse
    {
        public int? Id { get; set; }
        public CreatedWebinarCommandResponse() : base()
        {

        }

        public CreatedWebinarCommandResponse(ValidationResult validationResult) : base(validationResult)
        {

        }

        public CreatedWebinarCommandResponse(string message) : base(message)
        {

        }

        public CreatedWebinarCommandResponse(string message, bool success) : base(message, success)
        {

        }

        public CreatedWebinarCommandResponse(int webinarId)
        {
            Id = webinarId;
        }
    }
}
