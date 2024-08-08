namespace Pubsubber.Models
{
    /// <summary>
    /// Holds the <see cref="Unsubscriber"/> class, which
    /// will be used by anything that is observing or
    /// observable at the time of unsubscription.
    /// </summary>
    /// <typeparam name="ObservationType">
    /// The type of the entity being observed.
    /// </typeparam>
    public interface IUnsubscriber<ObservationType>
    {
        /// <summary>
        /// A class which holds the functionality to dispose
        /// of any unsubscribed observers.
        /// </summary>
        /// <param name="observers">
        /// The list of subscribed observers.
        /// </param>
        /// <param name="observer">
        /// The unsubsribed observer to clean up.
        /// </param>
        public class Unsubscriber(List<IObserver<ObservationType>> observers, IObserver<ObservationType> observer) : IDisposable
        {
            private readonly List<IObserver<ObservationType>> _observers = observers;
            private readonly IObserver<ObservationType> _observer = observer;

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
    }
}
