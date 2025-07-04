using FluentValidation;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(CategoryNameExist).WithMessage("A category With The same name already exists.")
                .MaximumLength(50).WithMessage("{Property Name} Must be eceed 50 characters.");
        }

        private async Task<bool> CategoryNameExist(string name, CancellationToken c)
        {
            return await _categoryRepository.CategoryNameExist(name);

        }

    }
}
