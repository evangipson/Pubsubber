using Pubsubber.Models;

namespace Pubsubber.Services
{
    /// <summary>
    /// An abstract service meant to be implemented by any service
    /// which will be observable, and publish messages to something
    /// else.
    /// </summary>
    /// <typeparam name="ObservationType">
    /// The type of the entity being observed.
    /// </typeparam>
    public abstract class ObservableService<ObservationType> : IUnsubscriber<ObservationType>, IObservable<ObservationType>
    {
        private readonly List<IObserver<ObservationType>> _observers;

        protected ObservableService()
        {
            _observers = [];
        }

        /// <summary>
        /// Subscribes an <paramref name="observer"/> to the
        /// list of <see cref="_observers"/>.
        /// </summary>
        /// <param name="observer">
        /// The new subscriber to add to the list of
        /// <see cref="_observers"/>, so they get published
        /// messages.
        /// </param>
        /// <returns>
        /// An <see cref="IDisposable"/> for when subscription
        /// ends.
        /// </returns>
        public virtual IDisposable Subscribe(IObserver<ObservationType> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return new IUnsubscriber<ObservationType>.Unsubscriber(_observers, observer);
        }
    }
}
