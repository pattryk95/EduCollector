using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class CreatedCategoryCommandResponse : BaseResponse
    {
        public int? CategoryId { get; set; }

        public CreatedCategoryCommandResponse(int categoryId)
        {
            CategoryId = categoryId;
        }

        public CreatedCategoryCommandResponse() : base()
        { }

        public CreatedCategoryCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedCategoryCommandResponse(string message)
        : base(message)
        { }

        public CreatedCategoryCommandResponse(string message, bool success)
            : base(message, success)
        { }

    }
}
