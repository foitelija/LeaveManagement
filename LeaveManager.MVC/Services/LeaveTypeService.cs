using AutoMapper;
using LeaveManagement.MVC.Services.Base;
using LeaveManager.MVC.Interfaces;
using LeaveManager.MVC.Models;
using LeaveManager.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManager.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly LeaveManagement.MVC.Services.Base.IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public LeaveTypeService(IMapper mapper, LeaveManagement.MVC.Services.Base.IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);

                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveType);

                if(apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var error in apiResponse.Errors)
                    {
                        response.ValidationErros += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveTypeAsync(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int id)
        {
            try
            {
                var leaveType = await _client.LeaveAllocationsGETAsync(id);
                return _mapper.Map<LeaveTypeVM>(leaveType);
            }
            catch
            {
                return _mapper.Map<LeaveTypeVM>(null);
            }
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypesAsync()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveTypeAsync(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
                await _client.LeaveTypesPUTAsync(id, leaveTypeDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
