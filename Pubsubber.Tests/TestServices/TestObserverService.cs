using Microsoft.Extensions.Logging;

using Pubsubber.Services;
using Pubsubber.Tests.TestModels;

namespace Pubsubber.Tests.TestServices
{
    /// <summary>
    /// A test implementation of
    /// <see cref="ObserverService{ObservationType}"/>.
    /// </summary>
    /// <param name="logger">
    /// A logger required to instantiate the
    /// <see cref="ObserverService{ObservationType}"/>.
    /// </param>
    public class TestObserverService(ILogger<ObserverService<TestObservedModel>> logger) : ObserverService<TestObservedModel>(logger)
    {
        /// <summary>
        /// Updates the provided <paramref name="observed"/>
        /// <see cref="TestObservedModel.Id"/> with a new
        /// <see cref="Guid"/>.
        /// </summary>
        /// <param name="observed">
        /// The model to update when a message is received.
        /// </param>
        public override void OnNext(TestObservedModel observed)
        {
            observed.Id = Guid.NewGuid();
        }
    }
}
