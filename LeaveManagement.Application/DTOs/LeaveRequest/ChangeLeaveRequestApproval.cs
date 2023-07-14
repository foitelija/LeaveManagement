using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApproval : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
