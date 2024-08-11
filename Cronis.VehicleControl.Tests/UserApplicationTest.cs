using Cronis.VehicleControl.Application;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Tests.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Cronis.VehicleControl.Tests
{
    public class UserApplicationTest : BaseTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IUserApplication _userApplication;
        NotificationContext _notificationContext = new NotificationContext();

        private readonly Guid userId1 = Guid.Parse("8ab7a28f-3526-4abd-8567-7dd42840cbf7");
        private readonly string userName1 = "Usuário 1";

        public UserApplicationTest(ITestOutputHelper output) : base(output)
        {
            _userRepository = new Mock<IUserRepository>();
            _userApplication = new UserApplication(_userRepository.Object, _notificationContext);
        }

        [Fact]
        public void CreateOk()
        {
            var createUserResult = new User(userId1, userName1);

            _userRepository.Setup(x => x
                .CreateAsync(It.IsAny<User>()))
                .Callback((User param) => _output.WriteLine($"Received {param.Id}"))
                .Returns(() => Task.FromResult(createUserResult)
            );

            User userResult = null;
            _userRepository.Setup(x => x
                .GetByNameAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(userResult)
            );

            var param = new User(userId1, userName1);
            var result = _userApplication.CreateAsync(param).Result;
            Assert.True(result.Valid);
        }

        [Fact]
        public void UserNameAlreadyExists()
        {
            var createUserResult = new User(userId1, userName1);

            _userRepository.Setup(x => x
                .CreateAsync(It.IsAny<User>()))
                .Callback((User param) => _output.WriteLine($"Received {param.Id}"))
                .Returns(() => Task.FromResult(createUserResult)
            );

            _userRepository.Setup(x => x
                .GetByNameAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(createUserResult)
            );

            var param = new User(userId1, userName1);
            var result = _userApplication.CreateAsync(param).Result;
            Assert.Null(result);
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == UserMessage.USERNAME_ALREADY_EXISTS));
        }
    }
}
