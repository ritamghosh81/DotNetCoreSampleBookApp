﻿using Login.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Login.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
