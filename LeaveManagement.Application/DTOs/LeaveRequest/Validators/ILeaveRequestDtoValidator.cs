using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto> 
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("The start date must be less than end date.");
            RuleFor(p => p.EndDate).GreaterThan(p => p.EndDate).WithMessage("The end date must be greater than start date.");
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist.");
            _leaveTypeRepository = leaveTypeRepository;
        }
    }
}
