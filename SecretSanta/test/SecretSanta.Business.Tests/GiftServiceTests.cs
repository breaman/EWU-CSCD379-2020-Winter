using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Business.Dtos;
using SecretSanta.Business.Services;
using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class GiftServiceTests : TestBase
    {
        [TestMethod]
        public async Task AddGiftViaService()
        {
            // Arrange
            Dtos.Gift? savedGift = null;
            Dtos.User? savedUser = null;
            using (var dbContext = new ApplicationDbContext(Options))
            {
                IUserService userService = new UserService(dbContext, Mapper);
                IGiftService giftService = new GiftService(dbContext, Mapper);
                
                UserInput userInput = new UserInput { FirstName = "Inigo", LastName = "Montoya" };
                savedUser = await userService.AddUser(userInput);

                GiftInput giftInput = new GiftInput { Title = "Ring", Description = "Great doorbell", Url = "www.ring.com", UserId = savedUser.Id };
                savedGift = await giftService.AddGift(giftInput);
            }

            // Act
            // Assert
            Assert.AreEqual(1, savedGift.Id);
        }
    }
}
