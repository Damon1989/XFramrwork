namespace XFramework.Event
{
    public interface IDomainExceptionEvent : IEvent
    {
        object ErrorCode { get; set; }
    }
}