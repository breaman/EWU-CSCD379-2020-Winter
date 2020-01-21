using AutoMapper;
using SecretSanta.Business.Dtos;
using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Business.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }
        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
        public async Task<Dtos.User> AddUser(UserInput userInput)
        {
            var user = Mapper.Map<Data.User>(userInput);
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();

            return Mapper.Map<Dtos.User>(user);
        }
    }
}
