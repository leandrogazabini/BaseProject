using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DllModels.Models.ModelsValidators
{
    public class ObjectTestValidator : AbstractValidator<ObjectTest>
    {
        public ObjectTestValidator()
        {
            RuleFor(obj => obj.Atrib1).NotNull();
            RuleFor(obj => obj.Atrib2).NotNull();

        }
    }
}
