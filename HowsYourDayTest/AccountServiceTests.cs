using HowsYourDayAPI.Interfaces;
using HowsYourDayAPI.Models;
using HowsYourDayAPI.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace HowsYourDayTest
{
    public class AccountServiceTests
    {
        private readonly AccountService _sut;
        private readonly Mock<UserManager<AppUser>> _userManagerMock = new Mock<UserManager<AppUser>>();
        private readonly Mock<SignInManager<AppUser>> _signInManagerMock = new Mock<SignInManager<AppUser>>();
        private readonly Mock<ITokenService> _tokenServiceMock = new Mock<ITokenService>();

        public AccountServiceTests()
        {
            _sut = new AccountService(_userManagerMock.Object, _signInManagerMock.Object, _tokenServiceMock.Object);
        }
    }
}