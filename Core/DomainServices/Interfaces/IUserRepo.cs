using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices.Interfaces
{
    public interface IUserRepo
    {
        User GetUserByEmail(string email);
        void CreateUser(User user);
        IEnumerable<User> GetAll();
    }
}
