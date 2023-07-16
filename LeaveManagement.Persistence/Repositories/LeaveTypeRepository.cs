using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveTypeRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
