using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("Number of days must be greater than 0.");
            RuleFor(p => p.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Must be greater or equal than current year.");
            RuleFor(p => p.LeaveTypeId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("Does not exist.");
        }
    }
}
