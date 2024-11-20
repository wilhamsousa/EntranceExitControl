using Cronis.VehicleControl.Application.Services;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Tests.Base;
using Moq;
using Xunit.Abstractions;

namespace Cronis.VehicleControl.Tests
{
    public class CheckListApplicationTest : BaseTest
    {
        private readonly ICheckListServiceAsync _application;
        private readonly NotificationContext _notificationContext = new NotificationContext();
        private readonly Mock<ICheckListRepositoryAsync> _checkListRepository;
        private readonly Mock<ICheckListItemRepositoryAsync> _checkListItemRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<ICheckListOptionRepository> _checkListOptionRepository;
        private readonly List<CheckListOption> _checkListOption = new List<CheckListOption>();

        private readonly Guid itemId1 = Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e");
        private readonly Guid itemId2 = Guid.Parse("1fd17098-9af1-4976-ade1-635f9ff27812");
        private readonly string vehiclePlate = "ABC-1234";
        private readonly Guid userId1 = Guid.Parse("8ab7a28f-3526-4abd-8567-7dd42840cbf7");
        private readonly Guid userId2 = Guid.Parse("a33b5c0e-5111-4f8b-85eb-d329a185e245");
        private readonly Guid checkListId = Guid.Parse("ed4f7bad-0fb9-4ef8-9e92-483b5e688036");
        private readonly Guid checkListItemId = Guid.Parse("223f3c36-34ab-4829-af00-de8bd1f35343");

        public CheckListApplicationTest(ITestOutputHelper output) : base(output)
        {
            _checkListRepository = new Mock<ICheckListRepositoryAsync>();
            _checkListItemRepository = new Mock<ICheckListItemRepositoryAsync>();
            _userRepository = new Mock<IUserRepository>();
            _checkListOptionRepository = new Mock<ICheckListOptionRepository>();            

            _checkListOption.Add(new CheckListOption(Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"), "Item 1", "Observação 1"));
            _application = new CheckListServiceAsync(
                _notificationContext,
                _checkListRepository.Object,
                _checkListItemRepository.Object,
                _userRepository.Object,
                _checkListOptionRepository.Object
            );
        }

        private void CreateSetup(
            CheckList createCheckListResult,
            CheckList getStartedByVehiclePlateResult,
            CheckListItem getCheckListItemResult,
            List<CheckListOption> getCheckListOptionResult,
            User getUserAsyncResult)
        {
            _checkListRepository.Setup(x => x
                .CreateAsync(It.IsAny<CheckList>()))
                .Callback((CheckList param) => _output.WriteLine($"Received {param.VehiclePlate}"))
                .Returns(() => Task.FromResult(createCheckListResult));

            _checkListRepository.Setup(x => x
                .GetStartedByVehiclePlateAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(getStartedByVehiclePlateResult));

            _checkListItemRepository.Setup(x => x
                .GetAsync(It.IsAny<Guid>()))
                .Callback((Guid param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(getCheckListItemResult));

            _checkListItemRepository.Setup(x => x
                .UpdateAsync(It.IsAny<CheckListItem>()))
                .Callback((CheckListItem param) => _output.WriteLine($"Received {param.Id}"));

            _checkListOptionRepository.Setup(x => x
                .GetAsync())
                .Returns(() => Task.FromResult(getCheckListOptionResult));

            _userRepository.Setup(x => x
                .GetAsync(It.IsAny<Guid>()))
                .Returns(() => Task.FromResult(getUserAsyncResult));
        }

        [Theory]
        [InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "ABC-1234", true)]
        [InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "", false)]
        [InlineData("00000000-0000-0000-0000-000000000000", "ABC-1234", false)]
        public void CheckListValidator(string userId, string vehiclePlate, bool result)
        {
            var newUserId = Guid.Parse(userId);
            CheckList checkList = new CheckList(newUserId, vehiclePlate, _checkListOption);
            Assert.Equal(result, checkList.Valid);
        }

        [Fact]
        public void CreateOK()
        {
            CreateSetup(
                createCheckListResult: new CheckList(userId1, vehiclePlate, _checkListOption),
                getStartedByVehiclePlateResult: new CheckList(userId1, vehiclePlate, _checkListOption),
                getCheckListItemResult: new CheckListItem(itemId1, itemId2, true, DateTime.Now),
                getCheckListOptionResult: new List<CheckListOption>()
                {
                    new CheckListOption(itemId1, "Item1", "Observação"),
                    new CheckListOption(itemId2, "Item2", "Observação2")
                },
                getUserAsyncResult: new User(userId1, "Usuário 1")
            );

            CheckListCreateRequest param = new CheckListCreateRequest()
            {
                UserId = userId1,
                VehiclePlate = vehiclePlate
            };
            var result = _application.CreateAsync(param).Result;
            Assert.True(result.Valid);
        }

        [Fact]
        public void CheckListAlreadyExists()
        {
            CreateSetup(
                createCheckListResult: new CheckList(userId1, vehiclePlate, _checkListOption),
                getStartedByVehiclePlateResult: new CheckList(userId2, vehiclePlate, _checkListOption),
                getCheckListItemResult: new CheckListItem(itemId1, itemId2, true, DateTime.Now),
                getCheckListOptionResult: new List<CheckListOption>()
                    {
                        new CheckListOption(itemId1, "Item1", "Observação"),
                        new CheckListOption(itemId2, "Item2", "Observação2")
                    },
                getUserAsyncResult: new User(userId1, "Usuário 1")
            );

            CheckListCreateRequest param = new CheckListCreateRequest()
            {
                UserId = userId1,
                VehiclePlate = vehiclePlate
            };
            var result = _application.CreateAsync(param).Result;
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == CheckListMessage.CHECKLIST_ALREADY_EXISTS));
        }

        [Fact]
        public void UserNotFound()
        {
            CreateSetup(
                createCheckListResult: new CheckList(userId1, vehiclePlate, _checkListOption),
                getStartedByVehiclePlateResult: new CheckList(userId2, vehiclePlate, _checkListOption),
                getCheckListItemResult: new CheckListItem(itemId1, itemId2, true, DateTime.Now),
                getCheckListOptionResult: new List<CheckListOption>()
                    {
                        new CheckListOption(itemId1, "Item1", "Observação"),
                        new CheckListOption(itemId2, "Item2", "Observação2")
                    },
                getUserAsyncResult: null
            );

            CheckListCreateRequest param = new CheckListCreateRequest()
            {
                UserId = userId1,
                VehiclePlate = vehiclePlate
            };
            var result = _application.CreateAsync(param).Result;
            Assert.Null(result);
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == CheckListMessage.CHECKLIST_USER_NOTFOUND));
        }        

        [Fact]
        public async void AproveItem()
        {
            var checkListItemResult = new CheckListItem(checkListId, itemId1, false, DateTime.Now);

            _checkListItemRepository.Setup(x => x
                .GetAsync(It.IsAny<Guid>()))
                .Callback((Guid param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(checkListItemResult));

            _checkListItemRepository.Setup(x => x
                .UpdateAsync(It.IsAny<CheckListItem>()))
                .Callback((CheckListItem param) => _output.WriteLine($"Received {param.Id}"));

            await _application.ApproveItemAsync(new CheckListItemUpdateRequest(checkListItemId));
            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async void CheckListItemNotFound()
        {
            CheckListItem checkListItemResult = null;

            _checkListItemRepository.Setup(x => x
                .GetAsync(It.IsAny<Guid>()))
                .Callback((Guid param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(checkListItemResult));

            Guid checkListItemId = Guid.NewGuid();
            await _application.ApproveItemAsync(new CheckListItemUpdateRequest(checkListItemId));
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == CheckListMessage.CHECKLISTITEM_NOTFOUND));
        }
    }
}