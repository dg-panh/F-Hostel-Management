﻿using Application.Interfaces;
using Application.Interfaces.IRepository;
using Domain.Entities;
using Domain.Enums;
using FirebaseAdmin.Auth;


namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IGenericRepository<UserEntity> _userRepository;
        private ITokenService _tokenService;

        public AuthenticationService(IGenericRepository<UserEntity> userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserEntity> AuthenticateUser(string token, Role loginType)
        {
            FirebaseToken firebaseToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
            var email = firebaseToken.Claims.GetValueOrDefault("email");
            UserEntity userEntity = await _userRepository.FirstOrDefaultAsync(a => a.Email.Equals(email));
            if (userEntity is null)
            {
                 userEntity = await SignUpNewUser(email.ToString(), loginType);
            }
            return userEntity;
        }

        public string GenerateToken(UserEntity user)
        {
            return _tokenService.GetToken(user);
        }

        public Task<UserEntity> SignUpNewUser(string email, Role role)
        {
            throw new NotImplementedException();
        }
    }
}
