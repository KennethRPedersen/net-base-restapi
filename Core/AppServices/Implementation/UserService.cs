using Core.AppServices.Interfaces;
using Core.DomainServices.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.AppServices.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public User Authenticate(AuthenticationModel model)
        {
            var user = _userRepo.GetUserByEmail(model.Email);

            if (user.Password == GenerateHash(model.Password + user.Salt))
            {
                return user;
            } else
            {
                throw new Exception("Invalid credentials");
            }
        }

        public void CreateUser(User user)
        {
            ValidateUser(user);
            user.Salt = GenerateSalt();
            user.Password = GenerateHash(user.Password + user.Salt);

            _userRepo.CreateUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        /// <summary>
        /// Generates a random 128bit string.
        /// </summary>
        /// <returns></returns>
        private static string GenerateSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Generates a one-way SHA256 hash from the input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GenerateHash(string input)
        {
            using (var sha = SHA256Managed.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(bytes);
            }
        }

        private bool ValidateUser(User user)
        {
            // Implement validation
            return true;
        }

    }
}
