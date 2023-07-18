using LeaveManager.MVC.Models;
using LeaveManager.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace LeaveManager.MVC.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypesAsync();
        Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int id);
        Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM leaveType);
        Task<Response<int>> UpdateLeaveTypeAsync(int id, LeaveTypeVM leaveType);
        Task<Response<int>> DeleteLeaveTypeAsync(int id);
    }
}
