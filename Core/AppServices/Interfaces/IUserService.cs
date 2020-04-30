using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppServices.Interfaces
{
    public interface IUserService
    {
        User Authenticate(AuthenticationModel model);
        void CreateUser(User user);
        IEnumerable<User> GetAll();
    }
}
