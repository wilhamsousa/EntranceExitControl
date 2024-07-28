using Gestran.VehicleControl.Application;
using Gestran.VehicleControl.Domain.Model.DTOs.CheckList;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Moq;

namespace Gestran.VehicleControl.Tests
{
    public class CheckListApplicationTest
    {
        private readonly ICheckListApplication _application;
        NotificationContext _notificationContext = new NotificationContext();
        Mock<ICheckListRepository> _checkListRepository;
        Mock<ICheckListItemRepository> _checkListItemRepository;
        Mock<IUserRepository> _userRepository;
        Mock<IItemCheckListRepository> _itemCheckListRepository;
        List<ItemCheckList> _itemCheckList;
        public CheckListApplicationTest()
        {
            _checkListRepository = new Mock<ICheckListRepository>();
            _checkListItemRepository = new Mock<ICheckListItemRepository>();
            _userRepository = new Mock<IUserRepository>();
            _itemCheckListRepository = new Mock<IItemCheckListRepository>();            

            _itemCheckList = new List<ItemCheckList>();
            _itemCheckList.Add(new ItemCheckList(Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"), "Item 1", "Observação 1"));
        }

        //[Theory]
        //[InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "ABC-1234", true)]
        //[InlineData("00000000-0000-0000-0000-000000000000", "ABC-1234", false)]
        //[InlineData("182deb7b-54b9-4b4d-ba20-0d6248d3de5e", "", false)]
        //public void CheckListValidator(string userId, string vehiclePlate, bool result)
        //{
        //    var newUserId = Guid.Parse(userId);
        //    CheckList checkList = new CheckList(newUserId, vehiclePlate, _itemCheckList);
        //    Assert.Equal(result, checkList.Valid);
        //}

        [Fact]
        public void CreateOK()
        {
            _checkListRepository.Setup(x => x.CreateAsync(It.IsAny<CheckList>()))
                .Callback<CheckList>(x => new CheckList(Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"), "ABC-1234", _itemCheckList));

            _checkListItemRepository.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .Callback(() => 
                    new CheckListItem
                    (
                        Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"),
                        Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"),
                        true,
                        DateTime.Now
                    )
                );

            _checkListItemRepository.Setup(x =>
                x.UpdateAsync(It.IsAny<CheckListItem>()))
                .Verifiable();

            _itemCheckListRepository.Setup(x => x.GetAsync())
                .Callback(() => new List<ItemCheckList>() 
                    { 
                        new ItemCheckList(Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"), "Item1", "Observação"),
                        new ItemCheckList(Guid.Parse("fe50ee15-a5fe-49fa-8742-8007e80e650c"), "Item2", "Observação2")
                    }
                );

            var application = new CheckListApplication(_notificationContext, _checkListRepository.Object, _checkListItemRepository.Object, _userRepository.Object, _itemCheckListRepository.Object);

            CheckListCreateDTO param = new CheckListCreateDTO()
            {
                UserId = Guid.Parse("182deb7b-54b9-4b4d-ba20-0d6248d3de5e"),
                VehiclePlate = "ABC-1234"
            };
            var result = application.CreateAsync(param).Result;
            Assert.Equal(result.Valid, true);
        }
    }
}