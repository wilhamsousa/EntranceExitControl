using Cronis.VehicleControl.Application.Services;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Tests.Base;
using Moq;
using Xunit.Abstractions;

namespace Cronis.VehicleControl.Tests
{
    public class CheckListOptionApplicationTest : BaseTest
    {
        private readonly Mock<ICheckListOptionRepositoryAsync> _checkListOptionRepository;
        private readonly ICheckListOptionServiceAsync _checkListOptionApplication;
        NotificationContext _notificationContext = new NotificationContext();

        private readonly Guid ItemCheckListId1 = Guid.Parse("8ab7a28f-3526-4abd-8567-7dd42840cbf7");
        private readonly string ItemCheckListName1 = "Item 1";
        private readonly string ItemCheckListNote1 = "Nota 1";

        public CheckListOptionApplicationTest(ITestOutputHelper output) : base(output)
        {
            _checkListOptionRepository = new Mock<ICheckListOptionRepositoryAsync>();
            _checkListOptionApplication = new CheckListOptionServiceAsync(_checkListOptionRepository.Object, _notificationContext);
        }

        private void CreateSetup(
            CheckListOption createResult,
            CheckListOption getByNameResult
        )
        {
            _checkListOptionRepository.Setup(x => x
                .CreateAsync(It.IsAny<CheckListOption>()))
                .Callback((CheckListOption param) => _output.WriteLine($"Received {param.Id}"))
                .Returns(() => Task.FromResult(createResult)
            );

            
            _checkListOptionRepository.Setup(x => x
                .GetByNameAsync(It.IsAny<string>()))
                .Callback((string param) => _output.WriteLine($"Received {param}"))
                .Returns(() => Task.FromResult(getByNameResult)
            );
        }

        [Fact]
        public void CreateOk()
        {
            CreateSetup(
                createResult: new CheckListOption(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1), 
                getByNameResult: null
            );

            var param = new CheckListOption(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);
            var result = _checkListOptionApplication.CreateAsync(param).Result;
            Assert.True(result.Valid);
        }

        [Fact]
        public void ItemCheckListNameAlreadyExists()
        {
            CreateSetup(
                createResult: new CheckListOption(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1), 
                getByNameResult: new CheckListOption(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1)
            );

            var param = new CheckListOption(ItemCheckListId1, ItemCheckListName1, ItemCheckListNote1);
            var result = _checkListOptionApplication.CreateAsync(param).Result;
            Assert.Null(result);
            Assert.True(_notificationContext.Notifications.Any(x => x.Message == CheckListOptionMessage.CHECKLISTPTION_ALREADY_EXISTS));
        }
    }
}
