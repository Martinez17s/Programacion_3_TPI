using Application.DTOs;
using Application.DTOs.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserRequest user);

        Task<UserDto> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> UpdateAsync(UpdateUserRequest request, int id);

        Task DeleteAsync(int id);
    }
}
