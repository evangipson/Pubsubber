using Microsoft.Extensions.Logging.Abstractions;
using Moq;

using Pubsubber.Services;
using Pubsubber.Tests.TestModels;
using Pubsubber.Tests.TestServices;

namespace Pubsubber.Tests.Services
{
    public class ObserverServiceTests
    {
        private readonly TestObserverService _testObserverService;
        private readonly Mock<TestObservableService> _mockTestObservableService;

        public ObserverServiceTests()
        {
            _mockTestObservableService = new Mock<TestObservableService>();
            _testObserverService = new TestObserverService(NullLogger<ObserverService<TestObservedModel>>.Instance);
        }

        [Fact]
        public void Subscribe_ShouldInvokeObservableSubscribe_WhenValidServiceProvided()
        {
            _testObserverService.Subscribe(_mockTestObservableService.Object);

            _mockTestObservableService.Verify(observableService => observableService.Subscribe(_testObserverService), Times.Once);
        }

        [Fact]
        public void OnNext_ShouldRunOnce_WhenPublishedMessageSent()
        {
            TestObservedModel observed = new();
            _testObserverService.Subscribe(_mockTestObservableService.Object);

            _testObserverService.OnNext(observed);

            Assert.NotEqual(Guid.Empty, observed.Id);
        }
    }
}
