﻿using System.Threading.Tasks;

namespace Consensus.Backend.User
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<Models.User> GetByIdAsync(string userId);
    }
}