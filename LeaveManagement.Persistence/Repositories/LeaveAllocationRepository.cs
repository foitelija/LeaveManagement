using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync()
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(q=>q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations.Include(q=>q.LeaveType).FirstOrDefaultAsync(q=>q.Id == id);
            return leaveAllocation;
        }
    }
}
