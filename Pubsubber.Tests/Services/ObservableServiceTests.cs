using Microsoft.Extensions.Logging.Abstractions;
using Moq;

using Pubsubber.Tests.TestServices;

namespace Pubsubber.Tests.Services
{
    public class ObservableServiceTests
    {
        private readonly TestObservableService _testObservableService;
        private readonly Mock<TestObserverService> _mockTestObserverService;

        public ObservableServiceTests()
        {
            _mockTestObserverService = new Mock<TestObserverService>(NullLogger<TestObserverService>.Instance);
            _testObservableService = new();
        }

        [Fact]
        public void Subscribe_ShouldReturnValidObject_WhenValidServiceProvided()
        {
            var expected = _testObservableService.Subscribe(_mockTestObserverService.Object);

            Assert.NotNull(expected);
        }
    }
}
