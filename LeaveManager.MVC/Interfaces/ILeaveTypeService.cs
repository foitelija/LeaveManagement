using LeaveManager.MVC.Models;
using LeaveManager.MVC.Services.Base;

namespace LeaveManager.MVC.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypesAsync();
        Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int id);
        Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM leaveType);
        Task UpdateLeaveTypeAsync(LeaveTypeVM leaveType);
        Task DeleteLeaveTypeAsync(LeaveTypeVM leaveTypeVM);
    }
}
