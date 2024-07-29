using Gestran.VehicleControl.Application;
using Gestran.VehicleControl.Domain.Model.DTOs.CheckList;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Tests.Base;
using Moq;
using Xunit.Abstractions;

namespace Gestran.VehicleControl.Tests
{
    public class CheckListApplicationTest : BaseTest
    {
        private readonly ICheckListApplication _application;
        NotificationContext _notificationContext = new NotificationContext();
        Mock<ICheckListRepository> _checkListRepository;
        Mock<ICheckListItemRepository> _checkListItemRepository;
        Mock<IUserRepository> _userRepository;
        Mock<IItemCheckListRepository> _itemCheckListRepository;
        List<ItemCheckList> _itemCheckList = new List<ItemCheckList>();

        Guid item1 = Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e");
        Guid item2 = Guid.Parse("1fd17098-9af1-4976-ade1-635f9ff27812");
        string vehiclePlate = "ABC-1234";
        Guid user1 = Guid.Parse("8ab7a28f-3526-4abd-8567-7dd42840cbf7");
        Guid user2 = Guid.Parse("a33b5c0e-5111-4f8b-85eb-d329a185e245");

        public CheckListApplicationTest(ITestOutputHelper output) : base(output)
        {
            _checkListRepository = new Mock<ICheckListRepository>();
            _checkListItemRepository = new Mock<ICheckListItemRepository>();
            _userRepository = new Mock<IUserRepository>();
            _itemCheckListRepository = new Mock<IItemCheckListRepository>();            

            _itemCheckList.Add(new ItemCheckList(Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"), "Item 1", "Observação 1"));            
        }

        [Theory]
        [InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "ABC-1234", true)]
        [InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "", false)]
        [InlineData("00000000-0000-0000-0000-000000000000", "ABC-1234", false)]
        public void CheckListValidator(string userId, string vehiclePlate, bool result)
        {
            var newUserId = Guid.Parse(userId);
            CheckList checkList = new CheckList(newUserId, vehiclePlate, _itemCheckList);
            Assert.Equal(result, checkList.Valid);
        }

        [Fact]
        public void CreateOK()
        {
            _checkListRepository.Setup(x => x.CreateAsync(It.IsAny<CheckList>()))
                .Callback((CheckList param) => _output.WriteLine($"Received {param.VehiclePlate}"))
                .Returns(() =>
                    Task.FromResult(new CheckList(
                        user1, 
                        vehiclePlate, 
                        _itemCheckList
                    ))
                );

            _checkListRepository.Setup(x => x.GetStartedByVehiclePlate(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() =>
                    Task.FromResult(new CheckList(
                        user1,
                        vehiclePlate,
                        _itemCheckList
                    ))
                );

            _checkListItemRepository.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .Callback((Guid param) => _output.WriteLine($"Received {param}"))
                .Returns(() => 
                    Task.FromResult(new CheckListItem
                    (
                        item1,
                        item2,
                        true,
                        DateTime.Now
                    ))
                );

            _checkListItemRepository.Setup(x => x.UpdateAsync(It.IsAny<CheckListItem>()))
                .Callback((CheckListItem param) => _output.WriteLine($"Received {param.Id}"));

            _itemCheckListRepository.Setup(x => x.GetAsync())
                .Returns(() => Task.FromResult(new List<ItemCheckList>() 
                    { 
                        new ItemCheckList(item1, "Item1", "Observação"),
                        new ItemCheckList(item2, "Item2", "Observação2")
                    }
                ));

            var application = new CheckListApplication(_notificationContext, _checkListRepository.Object, _checkListItemRepository.Object, _userRepository.Object, _itemCheckListRepository.Object);

            CheckListCreateDTO param = new CheckListCreateDTO()
            {
                UserId = user1,
                VehiclePlate = vehiclePlate
            };
            var result = application.CreateAsync(param).Result;
            Assert.Equal(result.Valid, true);
        }

        [Fact]
        public void CreateUserError()
        {
            _checkListRepository.Setup(x => x.CreateAsync(It.IsAny<CheckList>()))
                .Callback((CheckList param) => _output.WriteLine($"Received {param.VehiclePlate}"))
                .Returns(() =>
                    Task.FromResult(new CheckList(
                        user1,
                        vehiclePlate,
                        _itemCheckList
                    ))
                );

            _checkListRepository.Setup(x => x.GetStartedByVehiclePlate(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() =>
                    Task.FromResult(new CheckList(
                        user2,
                        vehiclePlate,
                        _itemCheckList
                    ))
                );


            _checkListItemRepository.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .Callback((Guid param) => _output.WriteLine($"Received {param}"))
                .Returns(() =>
                    Task.FromResult(new CheckListItem
                    (
                        item1,
                        item2,
                        true,
                        DateTime.Now
                    ))
                );

            _checkListItemRepository.Setup(x => x.UpdateAsync(It.IsAny<CheckListItem>()))
                .Callback((CheckListItem param) => _output.WriteLine($"Received {param.Id}"));

            _itemCheckListRepository.Setup(x => x.GetAsync())
                .Returns(() => Task.FromResult(new List<ItemCheckList>()
                    {
                        new ItemCheckList(item1, "Item1", "Observação"),
                        new ItemCheckList(item2, "Item2", "Observação2")
                    }
                ));

            var application = new CheckListApplication(_notificationContext, _checkListRepository.Object, _checkListItemRepository.Object, _userRepository.Object, _itemCheckListRepository.Object);

            CheckListCreateDTO param = new CheckListCreateDTO()
            {
                UserId = user1,
                VehiclePlate = vehiclePlate
            };
            var result = application.CreateAsync(param).Result;
            Assert.Null(result);
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == CheckListMessage.CHECKLIST_JA_EXISTE));
        }
    }
}