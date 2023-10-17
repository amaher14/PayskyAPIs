

namespace Core.Common
{
    public abstract class CreationAuditableEntity<T> : BaseEntity<T>, ICreationAudited
    {
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}