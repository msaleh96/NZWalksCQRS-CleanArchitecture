using Domain.Common;

namespace Domain.Walks.Events
{
    public abstract class WalkCreated : DomainEvent
    {
        public Guid WalkId { get; set; }
    }
}