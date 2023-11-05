﻿namespace GADistribuidora.Domain.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
