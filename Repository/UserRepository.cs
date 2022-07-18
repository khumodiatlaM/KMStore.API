using KMStore.API.Data;
using KMStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMStore.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly KMStoreContext _context;
        //private readonly AuthService _auth;

        public UserRepository(IConfiguration configuration,KMStoreContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User> CheckUserWithSameEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Register(User user)
        {
            var userWithExistingEmail = await _context.Users.SingleOrDefaultAsync(u => u.Email == user.Email);

            if(userWithExistingEmail != null)
            {
                var userObj = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    // Hash Password at later stage
                    Password = user.Password,
                    Role = "Users"
                };

                await _context.Users.AddAsync(userObj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
