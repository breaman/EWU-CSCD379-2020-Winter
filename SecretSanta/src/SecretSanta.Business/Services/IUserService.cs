using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Business.Services
{
    public interface IUserService
    {
        Task<Dtos.User> AddUser(Dtos.UserInput userInput);
    }
}
