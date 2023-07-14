using LeaveManagement.Domain;

namespace LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
        Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetailsAsync();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
