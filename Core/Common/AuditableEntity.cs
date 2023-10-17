
using Core.Common;

namespace Core

{
    [Serializable]
    public abstract class AuditableEntity<T> : BaseEntity<T>, ICreationAudited, IModificationAudited
    {
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastModificationAt { get; set; }
        public Guid? LastModificationBy { get; set; }
    }
}
