using Gestran.VehicleControl.Domain.Notification;
using Xunit.Abstractions;

namespace Gestran.VehicleControl.Tests.Base
{
    public abstract class BaseTest
    {
        private readonly NotificationContext _notificationContext;
        protected readonly ITestOutputHelper _output;

        protected BaseTest(NotificationContext notificationContext, ITestOutputHelper output)
        {
            _notificationContext = notificationContext;
            _output = output;
        }
    }
}
