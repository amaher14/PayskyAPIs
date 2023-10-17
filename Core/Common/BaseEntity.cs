namespace Core.Common
{
    [Serializable]
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
