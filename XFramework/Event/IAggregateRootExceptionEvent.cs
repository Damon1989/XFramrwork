using XFramework.Domain;

namespace XFramework.Event
{
    public interface IAggregateRootExceptionEvent : IAggregateRootEvent, IDomainExceptionEvent
    {
    }
}