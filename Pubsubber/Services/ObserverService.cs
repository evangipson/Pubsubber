using Microsoft.Extensions.Logging;

using Pubsubber.Models;

namespace Pubsubber.Services
{
    /// <summary>
    /// An abstract service meant to be implemented by any service
    /// which will be observing something.
    /// </summary>
    /// <typeparam name="ObservationType">
    /// The type of the entity being observed.
    /// </typeparam>
    public abstract class ObserverService<ObservationType>(ILogger<ObserverService<ObservationType>> logger)
        : IUnsubscriber<ObservationType>, IObserver<ObservationType>
    {
        private readonly ILogger<ObserverService<ObservationType>> _logger = logger;
        private IDisposable? _unsubscriber;

        /// <summary>
        /// Subscribes a <paramref name="provider"/>
        /// to this service.
        /// </summary>
        /// <param name="provider">
        /// The <see cref="IObservable{T}"/> that will be
        /// subscribed as a result.
        /// </param>
        public virtual void Subscribe(IObservable<ObservationType> provider)
        {
            _logger.LogInformation($"{nameof(Subscribe)}: {GetType().Name} subscribed to the \"{provider.GetType().Name}\" provider.");
            _unsubscriber = provider.Subscribe(this);
        }

        /// <summary>
        /// Removes the subscription of the provider.
        /// </summary>
        public virtual void Unsubscribe()
        {
            _logger.LogInformation($"{nameof(Subscribe)}: {GetType().Name} unsubscribed to the \"{_unsubscriber?.GetType().Name}\" provider.");
            _unsubscriber?.Dispose();
        }

        /// <summary>
        /// The behavior which runs when the subscription
        /// encounters an error.
        /// </summary>
        /// <param name="error">
        /// The <see cref="Exception"/> to be thrown.
        /// </param>
        public virtual void OnError(Exception error) => throw error;

        /// <summary>
        /// The behavior which runs when the subscription
        /// is comiplete.
        /// </summary>
        public virtual void OnCompleted()
        {
            _logger.LogInformation($"{nameof(Subscribe)}: {GetType().Name} completed it's subscription.");
        }

        /// <summary>
        /// The behavior which runs whenever this observer
        /// gets a message from the provider.
        /// </summary>
        /// <param name="subscriber">
        /// The <typeparamref name="ObservationType"/> which is provided
        /// and monitored by this observer.
        /// </param>
        public virtual void OnNext(ObservationType subscriber)
        {
            _logger.LogInformation($"{nameof(Subscribe)}: {GetType().Name} recieved a published message from the \"{_unsubscriber?.GetType().Name}\" provider.");
        }
    }
}
