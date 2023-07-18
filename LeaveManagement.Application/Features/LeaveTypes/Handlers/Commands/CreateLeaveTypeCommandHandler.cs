using AutoMapper;
using FluentValidation;
using LeaveManagement.Application.DTOs.LeaveType.Validators;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.Application.Responses;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation erorr";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
                    leaveType = await _leaveTypeRepository.Add(leaveType);

                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Id = leaveType.Id;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Something went wrong while creation.";
                    response.Errors.Add(ex.Message);
                }
            }

            return response;
        }
    }
}
