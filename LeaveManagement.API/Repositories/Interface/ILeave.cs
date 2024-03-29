﻿using LeaveManagement.API.Models.Domain;

namespace LeaveManagement.API.Repositories.Interface
{
    public interface ILeave
    {
        Task<List<Leave>> GetAllAsync();
        Task<List<Leave>>GetByIdAsync(Guid id);
        Task<Leave> CreateAsync(Leave leave);
    }
}
