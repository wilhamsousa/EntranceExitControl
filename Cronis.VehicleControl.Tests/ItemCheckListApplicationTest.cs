﻿using Cronis.VehicleControl.Application;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Tests.Base;
using Moq;
using Xunit.Abstractions;

namespace Cronis.VehicleControl.Tests
{
    public class ItemCheckListApplicationTest : BaseTest
    {
        private readonly Mock<IItemCheckListRepository> _ItemCheckListRepository;
        private readonly IItemCheckListApplication _ItemCheckListApplication;
        NotificationContext _notificationContext = new NotificationContext();

        private readonly Guid ItemCheckListId1 = Guid.Parse("8ab7a28f-3526-4abd-8567-7dd42840cbf7");
        private readonly string ItemCheckListName1 = "Item 1";
        private readonly string ItemCheckListNote1 = "Nota 1";

        public ItemCheckListApplicationTest(ITestOutputHelper output) : base(output)
        {
            _ItemCheckListRepository = new Mock<IItemCheckListRepository>();
            _ItemCheckListApplication = new ItemCheckListApplication(_ItemCheckListRepository.Object, _notificationContext);
        }

        [Fact]
        public void CreateOk()
        {
            var createItemCheckListResult = new ItemCheckList(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);

            _ItemCheckListRepository.Setup(x => x
                .CreateAsync(It.IsAny<ItemCheckList>()))
                .Callback((ItemCheckList param) => _output.WriteLine($"Received {param.Id}"))
                .Returns(() => Task.FromResult(createItemCheckListResult)
            );

            ItemCheckList ItemCheckListResult = null;
            _ItemCheckListRepository.Setup(x => x
                .GetByNameAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(ItemCheckListResult)
            );

            var param = new ItemCheckList(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);
            var result = _ItemCheckListApplication.CreateAsync(param).Result;
            Assert.True(result.Valid);
        }

        [Fact]
        public void ItemCheckListNameAlreadyExists()
        {
            var createItemCheckListResult = new ItemCheckList(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);

            _ItemCheckListRepository.Setup(x => x
                .CreateAsync(It.IsAny<ItemCheckList>()))
                .Callback((ItemCheckList param) => _output.WriteLine($"Received {param.Id}"))
                .Returns(() => Task.FromResult(createItemCheckListResult)
            );

            _ItemCheckListRepository.Setup(x => x
                .GetByNameAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(createItemCheckListResult)
            );

            var param = new ItemCheckList(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);
            var result = _ItemCheckListApplication.CreateAsync(param).Result;
            Assert.Null(result);
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == ItemCheckListMessage.ITEMCHECKLIST_ALREADY_EXISTS));
        }
    }
}
