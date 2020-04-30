using Core.DomainServices.Interfaces;
using Core.Entities;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DomainServices.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _dataContext;
        public UserRepo(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void CreateUser(User user)
        {
            _dataContext.Users.Attach(user).State = EntityState.Added;
            _dataContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users;
        }

        public User GetUserByEmail(string email)
        {
            return _dataContext.Users.FirstOrDefault(usr => usr.Email.ToLower() == usr.Email.ToLower());
        }
    }
}
